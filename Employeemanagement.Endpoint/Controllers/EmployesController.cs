using EployeeManagment.ApplicationService.Contract.Dtos.Salary;
using EployeeManagment.ApplicationService.Contract.Dtos.WorkHour;
using EployeeManagment.ApplicationService.Contract.IService;
using Microsoft.AspNetCore.Mvc;

namespace Employeemanagement.Endpoint.Controllers
{
    public class EmployesController : Controller
    {
        private readonly IUserService userService;
        private readonly IWorkHourService workHourService;
        private readonly ISalaryService salaryService;
        public EmployesController(IUserService userService, IWorkHourService workHourService, ISalaryService salaryService)
        {
            this.userService = userService;
            this.workHourService = workHourService;
            this.salaryService = salaryService;
        }

        public IActionResult Index()
        {
            var users = userService.GetAll();
            return View(users);
        }
        [HttpGet]
        public IActionResult SetUserSalary(long userId)
        {
            AddSalaryDto dto = new();
            dto.UserId = userId;
            return View(dto);
        }
        [HttpPost]
        public IActionResult SetUserSalary(AddSalaryDto dto)
        {
            salaryService.AddSalary(dto,dto.UserId);
            return Redirect("/Employes/Index");
        }
    }
}
