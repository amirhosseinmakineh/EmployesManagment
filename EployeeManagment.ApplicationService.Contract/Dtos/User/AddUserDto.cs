using EmployeeManagment.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EployeeManagment.ApplicationService.Contract.Dtos.User
{
    public class AddUserDto:HandleException
    {
        [Required(ErrorMessage = "لطفا نام خود را وارد کنید")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "لطفا نام خانوادگی  خود را وارد کنید")]
        public string Family { get; set; } = string.Empty;
        public override string Message { get => base.Message; set => base.Message = value; }
        public override HttpStatusCode HttpStatusCode { get => base.HttpStatusCode; set => base.HttpStatusCode = value; }
    }
}
