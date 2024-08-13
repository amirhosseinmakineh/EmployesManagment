namespace EployeeManagment.ApplicationService.Contract.Dtos.WorkHour
{
    public class WorkHourDto
    {
        public string DayOfWeek { get; set; } = string.Empty;
        public TimeSpan Startworkhour { get; set; }
        public TimeSpan Endtworkhour { get; set; }
        public  long UserId { get; set; }
    }
}
