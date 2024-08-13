using Employeemanagement.Endpoint.Models;
using EployeeManagment.ApplicationService.Contract.Dtos.User;
using EployeeManagment.ApplicationService.Contract.IService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employeemanagement.Endpoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AddUserDto dto)
        {
            if(userService.AddUser(dto) is true)
            {
                TempData["Success"] = "ثبت کاربر جدید با موفقیت انجام شد";
            }
            else
            {
                TempData["Success"] = "ثبت کاربر جدید با شکست مواجه شد";
            }
            return View(dto);
        }
    }
}