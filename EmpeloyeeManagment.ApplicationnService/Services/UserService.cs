using EmployeeManagment.Domain.IRpositories;
using EmployeeManagment.Domain.Models;
using EployeeManagment.ApplicationService.Contract.Dtos.User;
using EployeeManagment.ApplicationService.Contract.IService;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EmpeloyeeManagment.ApplicationnService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IWorkHourRepository workHourRepository;
        private readonly ISalaryRepository salaryRepository;
        public TimeSpan betweenHours;
        TimeSpan total = TimeSpan.Zero;
        List<TimeSpan> times = new List<TimeSpan>();
        List<UserDto> dto = new List<UserDto>();
        UserDto user = new UserDto();
        long hour = new long();
        float salaryPerWeek = new float();
        public UserService(IUserRepository repository, IWorkHourRepository workHourRepository, ISalaryRepository salaryRepository)
        {
            this.repository = repository;
            this.workHourRepository = workHourRepository;
            this.salaryRepository = salaryRepository;
        }

        public bool AddUser(AddUserDto dto)
        {
            bool result = false;
            var user = repository.GetAll().Where(x => x.Name == dto.Name).FirstOrDefault();
            if (CheckUserExist(dto.Name, dto.Family) is true)
            {
                dto.Message = "نام و نام خانوادگی وارد شده موجود میباشد";
                dto.HttpStatusCode = System.Net.HttpStatusCode.Found;
                result = false;
            }
            else
            {
                var addUser = new User()
                {
                    Name = dto.Name,
                    Family = dto.Family
                };
                repository.Add(addUser);
                repository.SaveChanges();
                dto.Message = "ثبت کارمند جدید با موفقیت انجام شد";
                dto.HttpStatusCode = HttpStatusCode.OK;
                result = true;
            }
            return result;

        }

        public bool CheckUserExist(string name, string family)
        {
            var check = repository.GetAll().Where(x => x.Name == name && x.Family == family).Any();
            return check;
        }

        public IList<UserDto> GetAll()
        {
            var users = repository.GetAll().Include(x=> x.Salaries).ToList();
            for (int i = 0; i < users.Count(); i++)
            {
                var userHoues = workHourRepository.GetAll().Where(x => x.UserId == users[i].Id).Include(x => x.User).ToList();
                for (int j = 0; j < userHoues.Count(); j++)
                {
                    betweenHours = userHoues[j].Endtworkhour - userHoues[j].Startworkhour;
                    times.Add(betweenHours);
                    total = new TimeSpan(times.Sum(x => x.Hours));
                     hour = total.Ticks;
                    user.TotalWorkingHours = hour;
                }
                times = new List<TimeSpan>();
                user.Name = users[i].Name;
                user.Family = users[i].Family;
                user.UserId = users[i].Id;
                var userSalary = salaryRepository.GetAll().Where(x => x.UserId == users[i].Id).FirstOrDefault();
                if (users[i].Salaries.Count > 0) 
                {
                    user.Salary = (float)userSalary.Amount;
                    user.SalaryPerWeek = (float)userSalary.Amount * hour;
                    user.SalaryPerMonth = user.SalaryPerWeek * 4;
                }
                dto.Add(user);
                user = new UserDto();
                dto.Select(x => new UserDto()
                {
                    Family = x.Family,
                    Name = x.Name,
                    TotalWorkingHours = x.TotalWorkingHours,
                    UserId = x.UserId,
                    Salary = user.Salary
                }).ToList();
            }
            return dto;
        }
    }
}
