using AutoMapper;
using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.CustomerVm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Web.Controllers
{  
     [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _custService;
        private readonly IReservationService _reservationService;

        public CustomerController(ICustomerService customerService, IReservationService reservationService)
        {
            _custService = customerService;
            _reservationService = reservationService;
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
        [HttpGet]
        public IActionResult Details(int id)
        {
            var customer = _custService.GetCustomerDetail(id);
            return View(customer);
        }
        public IActionResult DeleteCustomer(CustomerForEditVm customerForEditVm)
        {
            _custService.DeleteCustomer(customerForEditVm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetCustomerHistory(int id)
        {
            var model = _reservationService.GetCustomerReservations(id);
            return View(model);
        }
    }
}
