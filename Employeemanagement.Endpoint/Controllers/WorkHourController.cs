using EmpeloyeeManagment.ApplicationnService.Services;
using EmployeeManagment.Domain.Models;
using EployeeManagment.ApplicationService.Contract.Dtos.WorkHour;
using EployeeManagment.ApplicationService.Contract.IService;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace Employeemanagement.Endpoint.Controllers
{
    public class WorkHourController : Controller
    {
        private readonly IWorkHourService workHourService;

        public WorkHourController(IWorkHourService workHourService)
        {
            this.workHourService = workHourService;
        }
        [HttpGet]
        public IActionResult Add(long userId)
        {
            AddWorkHourDto dto = new();
            dto.UserId = userId;
            return View(dto);
        }
        [HttpPost]
        public IActionResult Add(AddWorkHourDto dto)
        {
            workHourService.Add(dto, dto.UserId);
            return Redirect("/Employes/Index");
        }
    }
}
