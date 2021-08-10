using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.DocumentVm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Web.Controllers
{   
    [Authorize(Roles = "Kierownik, Administrator")]
    public class DocumentController : Controller
    {
        private readonly IBookService _bookService;
        public DocumentController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            var model = _bookService.GetDocumentsForList();
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateDocument()
        {
            ViewBag.books = _bookService.GetBooksWithPositiveAmount();
            return View(new NewDocumentVm());
        }
        [HttpPost]
        public IActionResult CreateDocument(NewDocumentVm newDocumentVm)
        {
            if(ModelState.IsValid)
            {
                _bookService.AddDocument(newDocumentVm);
                return RedirectToAction("Index");

            }
            else
            {
                return View(newDocumentVm);
            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _bookService.GetDocumentById(id);
            return View(model);
        }
    }
}
