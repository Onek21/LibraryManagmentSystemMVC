using AutoMapper;
using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.AuthorVm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public IActionResult Index()
        {
            var model = _authorService.GetAllActiveAuthors();
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var author = _authorService.GetAuthorDetail(id);
            return View(author);
        }
        [HttpGet]
        public IActionResult EditAuthor(int id)
        {
            var author = _authorService.GetAuthorForEdit(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult EditAuthor(NewAuthorVm authorVm)
        {
            if(ModelState.IsValid)
            {
                _authorService.UpdateAuthor(authorVm);
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
                var id = _authorService.AddAuthor(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteAuthor(NewAuthorVm model)
        {
            _authorService.DeleteAuthor(model);
            return RedirectToAction("Index");
        }
    }
}
