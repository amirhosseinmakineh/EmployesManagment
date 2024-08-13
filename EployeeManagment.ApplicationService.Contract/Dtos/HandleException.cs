using System.Net;

namespace EployeeManagment.ApplicationService.Contract.Dtos
{
    public class HandleException
    {
        public virtual string Message { get; set; } = string.Empty;
        public virtual HttpStatusCode HttpStatusCode { get; set; }
    }
}
