namespace EmployeeManagment.Domain.Models
{
    public class Salary:BaseEntity<long>
    {
        public decimal Amount { get; set; }
        public long UserId { get; set; }
        #region Relations
        public User User { get; set; }
        #endregion
    }
}
