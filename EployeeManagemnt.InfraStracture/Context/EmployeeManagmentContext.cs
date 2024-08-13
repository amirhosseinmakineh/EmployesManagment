using EmployeeManagment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EployeeManagemnt.InfraStracture.Context
{
    public class EmployeeManagmentContext:DbContext
    {
        public EmployeeManagmentContext(DbContextOptions<EmployeeManagmentContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkHour> WorkHours { get; set; }
    }
}
