using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EployeeManagment.ApplicationService.Contract.Dtos.WorkHour
{
    public class AddWorkHourDto:HandleException
    {
        [Required(ErrorMessage = "لطفا روز هفته را وارد کنید")]
        public string DayOfWeek { get; set; } = string.Empty;
        [Required(ErrorMessage = "لطفا ساعت شروع روز وارد کنید")]
        public TimeSpan Startworkhour { get; set; }
        [Required(ErrorMessage ="لطفا ساعا پایان روز را وارد کنید")]
        public TimeSpan Endtworkhour { get; set; }
        public long UserId { get; set; }
        public override HttpStatusCode HttpStatusCode { get => base.HttpStatusCode; set => base.HttpStatusCode = value; }
        public override string Message { get => base.Message; set => base.Message = value; }
    }
}
