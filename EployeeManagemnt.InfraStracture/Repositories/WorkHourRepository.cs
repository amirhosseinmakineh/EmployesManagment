using EmployeeManagment.Domain.IRpositories;
using EmployeeManagment.Domain.Models;
using EployeeManagemnt.InfraStracture.Context;

namespace EployeeManagemnt.InfraStracture.Repositories
{
    public class WorkHourRepository : BaseRepository<long, WorkHour>, IWorkHourRepository
    {
        public WorkHourRepository(EmployeeManagmentContext context) : base(context)
        {
        }
    }
}
