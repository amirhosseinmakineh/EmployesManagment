using EmployeeManagment.Domain.IRpositories;
using EmployeeManagment.Domain.Models;
using EployeeManagment.ApplicationService.Contract.Dtos.Salary;
using EployeeManagment.ApplicationService.Contract.IService;

namespace EmpeloyeeManagment.ApplicationnService.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository repository;
        private readonly IUserRepository userRepository;

        public SalaryService(ISalaryRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
        }

        public void AddSalary(AddSalaryDto dto,long userId )
        {
            var user = userRepository.GetAll().Where(x => x.Id == userId).FirstOrDefault();
            Salary salary = new()
            {
                Amount = dto.Amount,
                UserId = userId
            };
            repository.Add(salary);
            repository.SaveChanges();
        }
    }
}
