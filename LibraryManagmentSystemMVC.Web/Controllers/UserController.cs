using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.UsersVm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = _userService.GetUsers();
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View(new NewUserVm());
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(NewUserVm newUserVm)
        {
            if(ModelState.IsValid)
            {     
                var result = await _userService.AddUser(newUserVm);
                return RedirectToAction("Index");
            }
            else
            {
                return  View(newUserVm);
            }   
        }
    }
}
