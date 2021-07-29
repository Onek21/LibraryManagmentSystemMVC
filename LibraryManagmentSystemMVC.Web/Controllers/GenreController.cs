using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.GenreVm;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly IBookService _bookService;
        public GenreController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            var model = _bookService.GetActiveGenres();
            return View(model);
        }
        [HttpGet]
        public IActionResult EditGenre(int id)
        {
            var model = _bookService.GetGenreForUpdate(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditGenre(NewGenreVm newGenreVm)
        {
            if(ModelState.IsValid)
            {
                _bookService.UpdateGenre(newGenreVm);
                return RedirectToAction("Index");
            }
            return View(newGenreVm);
        }
        [HttpGet]
        public IActionResult CreateGenre()
        {
            return View(new NewGenreVm());
        }
        [HttpPost]
        public IActionResult CreateGenre(NewGenreVm newGenreVm)
        {
            if(ModelState.IsValid)
            {
                _bookService.AddGenre(newGenreVm);
                return RedirectToAction("Index");
            }
            return View(newGenreVm);
        }
        public IActionResult DeleteGenre(NewGenreVm newGenreVm)
        {
            if(ModelState.IsValid)
            {
                _bookService.DeleteGenre(newGenreVm);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
