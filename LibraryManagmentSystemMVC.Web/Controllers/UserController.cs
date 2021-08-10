using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.UsersVm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Web.Controllers
{
    [Authorize(Roles ="Administrator")]
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
        public IActionResult RolesList()
        {
            var model = _userService.GetRoles();
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View(new NewRoleVm());
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(NewRoleVm newRoleVm)
        {
            if(ModelState.IsValid)
            { 
                await _userService.AddRole(newRoleVm);
                return RedirectToAction("RolesList");
            }
            else
            {
                return View(newRoleVm);
            }

        }
        [HttpGet]
        public IActionResult ChangeRoles(string id)
        {
            var model = _userService.GetUserById(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeRoles(NewUserVm newUserVm)
        {
            await _userService.ChangeUserRoles(newUserVm.Id, newUserVm.UserRoles);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UserDetails(string id)
        {
            var model = _userService.GetUserById(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult EditUser(string id)
        {
            var model = _userService.GetUserById(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(NewUserVm newUserVm)
        {
            await _userService.EditUser(newUserVm);
            return RedirectToAction("Index");
        }
       [HttpGet]
       public IActionResult ResetPassword(string id)
        {
            var model = _userService.GetUserById(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(NewUserVm newUserVm)
        {
            await _userService.ResetPassword(newUserVm);
            return RedirectToAction("Index");
        }
    }
}
