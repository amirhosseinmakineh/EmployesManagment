using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Domain.Models
{
    public class WorkHour:BaseEntity<long>
    {
        public string DayOfWeek { get; set; }
        [Required]
        public TimeSpan Startworkhour { get; set; }
        [Required]
        public TimeSpan Endtworkhour { get; set; }
        public long UserId { get; set; }

        #region Relations
        public User User { get; set; }
        #endregion
    }
}
