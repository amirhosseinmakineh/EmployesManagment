using EmployeeManagment.Domain.Models;

namespace EmployeeManagment.Domain.IRpositories
{
    public interface IUserRepository : IRepository<long, User>
    {
    }
}
