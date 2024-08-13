using EmpeloyeeManagment.ApplicationnService.Services;
using EmployeeManagment.Domain.Models;
using EployeeManagment.ApplicationService.Contract.Dtos.Salary;
using EployeeManagment.ApplicationService.Contract.IService;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace Employeemanagement.Endpoint.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ISalaryService salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            this.salaryService = salaryService;
        }

        [HttpGet]
        public IActionResult Add(long userId)
        {
            AddSalaryDto dto = new();
            dto.UserId = userId;
            return View(dto);
        }
        [HttpPost]
        public IActionResult Add(AddSalaryDto dto)
        {
            salaryService.AddSalary(dto, dto.UserId);
            return Redirect("/Employes/Index");
        }
    }
}
