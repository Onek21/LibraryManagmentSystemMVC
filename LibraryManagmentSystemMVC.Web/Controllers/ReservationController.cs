using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.ReservationVm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Web.Controllers
{
    [Authorize]
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
            ViewBag.books = _bookService.GetBooksInStock();
            ViewBag.customers = _custService.GetActiveCustomers();
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
        public IActionResult ExtendReservation(int id)
        {
            _reseravtionService.ExtendReservation(id);
            return RedirectToAction("Index");
        }
        public IActionResult CancelReservation(int id)
        {
            _reseravtionService.CancelReservation(id);
            return RedirectToAction("Index");
        }
        public IActionResult MarkReservationAsComplete(int id)
        {
            _reseravtionService.CompleteReservation(id);
            return RedirectToAction("Index");
        }
        public IActionResult CompletedReservations()
        {
            var model = _reseravtionService.GetCompletedReservations();
            return View(model);
        }
        public IActionResult CanceledReservations()
        {
            var model = _reseravtionService.GetCanceledReservations();
            return View(model);
        }
    }
}
