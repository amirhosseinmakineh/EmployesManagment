using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EployeeManagment.ApplicationService.Contract.Dtos.Salary
{
    public class AddSalaryDto:HandleException
    {
        [Required(ErrorMessage ="لطفا مبغ حقوق را وارد کنید")]
        public decimal Amount { get; set; }
        public long UserId { get; set; }
        public override string Message { get => base.Message; set => base.Message = value; }
        public override HttpStatusCode HttpStatusCode { get => base.HttpStatusCode; set => base.HttpStatusCode = value; }
    }
}
