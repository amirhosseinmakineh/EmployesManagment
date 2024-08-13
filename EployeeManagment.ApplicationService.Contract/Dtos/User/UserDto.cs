namespace EployeeManagment.ApplicationService.Contract.Dtos.User
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Family { get; set; } = string.Empty;
        public long UserId { get; set; }
        public long TotalWorkingHours { get; set; }
        public float Salary { get; set; }
        public float SalaryPerWeek { get; set; }
        public  float SalaryPerMonth { get; set; }
        
    }
}
