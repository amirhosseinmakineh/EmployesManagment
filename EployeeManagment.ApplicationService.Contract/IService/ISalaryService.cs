using EployeeManagment.ApplicationService.Contract.Dtos.Salary;

namespace EployeeManagment.ApplicationService.Contract.IService
{
    public interface ISalaryService
    {
        void AddSalary(AddSalaryDto dto,long userId);
    }
}
