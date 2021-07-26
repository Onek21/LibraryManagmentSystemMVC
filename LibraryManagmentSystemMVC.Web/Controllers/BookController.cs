using LibraryManagmentSystemMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
    }
}
