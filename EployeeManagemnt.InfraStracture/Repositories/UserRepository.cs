using EmployeeManagment.Domain.IRpositories;
using EmployeeManagment.Domain.Models;
using EployeeManagemnt.InfraStracture.Context;

namespace EployeeManagemnt.InfraStracture.Repositories
{
    public class UserRepository : BaseRepository<long, User>,IUserRepository
    {
        public UserRepository(EmployeeManagmentContext context) : base(context)
        {
        }
    }
}
