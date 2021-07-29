using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.BookVm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        public BookController(IBookService bookService,ILogger<HomeController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = _bookService.GetAllActiveBooksForList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = _bookService.BookDetails(id);
            return View(book);
        }
        [HttpGet]
        public IActionResult CreateBook()
        {
            ViewBag.authorsList = _bookService.GetAllActiveAuthors();
            ViewBag.genreList = _bookService.GetActiveGenres();
            return View(new NewBookVm());
        }
        [HttpPost]
        public IActionResult CreateBook(NewBookVm newBookVm)
        {
            if(ModelState.IsValid)
            {
                _bookService.AddBook(newBookVm);
                return RedirectToAction("Index");
            }
            else
            {     
                return View(newBookVm);
            }
        }

        public IActionResult DeleteBook(NewBookVm newBookVm)
        {
            _bookService.DeleteBook(newBookVm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditBook(int id)
        {
            var book = _bookService.GetBookToEdit(id);
            ViewBag.authorsList = _bookService.GetAllActiveAuthors();
            ViewBag.genreList = _bookService.GetActiveGenres();
            return View(book);
        }
        [HttpPost]
        public IActionResult EditBook(NewBookVm newBookVm)
        {
            if(ModelState.IsValid)
            {
                _bookService.EditBook(newBookVm);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newBookVm);
            }
        }
    }
}
