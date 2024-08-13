using EmployeeManagment.Domain.IRpositories;
using EmployeeManagment.Domain.Models;
using EployeeManagment.ApplicationService.Contract.Dtos.WorkHour;
using EployeeManagment.ApplicationService.Contract.IService;

namespace EmpeloyeeManagment.ApplicationnService.Services
{
    public class WorkHourService : IWorkHourService
    {
        private readonly IWorkHourRepository repository;
        private readonly IUserRepository userRepository;
        public WorkHourService(IWorkHourRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
        }

        public bool Add(AddWorkHourDto dto,long userId)
        {
            bool result = false;
            var user = userRepository.GetAll().Where(x => x.Id == userId).FirstOrDefault();
            if(CheckUserHour(userId) is true)
            {
                WorkHour workHour = new()
                {
                    DayOfWeek = dto.DayOfWeek,
                    Startworkhour = dto.Startworkhour,
                    UserId = user.Id,
                    Endtworkhour = dto.Endtworkhour,
                };
                repository.Add(workHour);
                repository.SaveChanges();
                dto.HttpStatusCode = System.Net.HttpStatusCode.OK;
                dto.Message = $"ساعت کاری با موفقیت برای {user.Name} ثبت شد";
                result = true;
            }
            else
            {
                dto.HttpStatusCode = System.Net.HttpStatusCode.Found;
                dto.Message = $"شما برای {user.Name} 7 روز کاری ساعت کاری ست کرده اید";
                result = false;
            }
            return result;
        }

        public bool CheckUserHour(long userId)
        {
            bool result = false;
            var user = userRepository.GetAll().Where(x => x.Id == userId).FirstOrDefault();
            var userWorkHour = repository.GetAll().Where(x => x.UserId == userId).Select(x => new WorkHourDto()
            {
                DayOfWeek = x.DayOfWeek,
                Endtworkhour = x.Endtworkhour,
                Startworkhour = x.Startworkhour,
                UserId = user.Id,
            }).ToList();
            if (userWorkHour.Count > 7 )
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }
    }
}
