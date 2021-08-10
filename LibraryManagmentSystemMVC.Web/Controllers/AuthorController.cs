using AutoMapper;
using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.AuthorVm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Web.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IBookService _bookService;

        public AuthorController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            var model = _bookService.GetAllActiveAuthors();
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var author = _bookService.GetAuthorDetail(id);
            return View(author);
        }
        [HttpGet]
        public IActionResult EditAuthor(int id)
        {
            var author = _bookService.GetAuthorForEdit(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult EditAuthor(NewAuthorVm authorVm)
        {
            if(ModelState.IsValid)
            {
                _bookService.UpdateAuthor(authorVm);
                return RedirectToAction("Index");
            }
            return View(authorVm);
        }
        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View(new NewAuthorVm());
        }
        [HttpPost]
        public IActionResult AddAuthor(NewAuthorVm model)
        {
            if(ModelState.IsValid)
            {
                var id = _bookService.AddAuthor(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteAuthor(NewAuthorVm model)
        {
            _bookService.DeleteAuthor(model);
            return RedirectToAction("Index");
        }
    }
}
