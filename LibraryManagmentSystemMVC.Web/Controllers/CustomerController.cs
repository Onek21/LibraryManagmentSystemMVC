using AutoMapper;
using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.CustomerVm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _custService;

        public CustomerController(ICustomerService customerService)
        {
            _custService = customerService;
        }
        public IActionResult Index()
        {
            var model = _custService.GetActiveCustomers();
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View(new NewCustomerVm());
        }
        [HttpPost]
        public IActionResult CreateCustomer(NewCustomerVm newCustomerVm)
        {
            if(ModelState.IsValid)
            {
                _custService.AddCustomer(newCustomerVm);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newCustomerVm);
            }
        }
        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            var customer = _custService.GetCustomerForEdit(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult EditCustomer(CustomerForEditVm customerForEditVm)
        {
            if (ModelState.IsValid) 
            {
                _custService.EditCustomer(customerForEditVm);
                _custService.EditAddress(customerForEditVm.Addresses);
                return RedirectToAction("Index");
            }
            else
            {
                return View(customerForEditVm);
            }
        }

    }
}
