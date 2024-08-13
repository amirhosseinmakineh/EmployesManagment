using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Domain.Models
{
    public class User:BaseEntity<long>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Family { get; set; }
        #region Relations
        public ICollection<WorkHour> WorkHours { get; set; }
        public ICollection<Salary> Salaries { get; set; }
        #endregion
    }
}
