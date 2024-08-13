using EmployeeManagment.Domain.IRpositories;
using EmployeeManagment.Domain.Models;
using EployeeManagemnt.InfraStracture.Context;

namespace EployeeManagemnt.InfraStracture.Repositories
{
    public class SalaryRepository : BaseRepository<long, Salary>, ISalaryRepository
    {
        public SalaryRepository(EmployeeManagmentContext context) : base(context)
        {
        }
    }
}
