using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.ReservationVm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reseravtionService;
        private readonly IBookService _bookService;
        private readonly ICustomerService _custService;
        public ReservationController(IReservationService reservationService, IBookService bookService, ICustomerService customerService)
        {
            _reseravtionService = reservationService;
            _bookService = bookService;
            _custService = customerService;
        }
        public IActionResult Index()
        {
            _reseravtionService.MarkReservationAsOverTime();
            var model = _reseravtionService.GetCurrnetReservations();
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateReservation()
        {
            ViewBag.books = _bookService.GetAllActiveBooksForList();
            ViewBag.customers = _custService.GetActiveCustomers();
            ViewBag.states = _reseravtionService.GetReservationStates();
            return View(new NewReservationVm());
        }
        [HttpPost]
        public IActionResult CreateReservation(NewReservationVm newReservationVm)
        {
            if(ModelState.IsValid)
            {
                _reseravtionService.AddReservation(newReservationVm);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newReservationVm);
            }
        }
    }
}
