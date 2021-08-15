using AutoMapper;
using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.BookVm;
using LibraryManagmentSystemMVC.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BookForListVm>> GetActiveBooks()
        {
            var books = _bookService.GetAllActiveBooksForList();
            if(books.Count < 0)
            {
                return NotFound();
            }
            return Ok(books);
        }
        [HttpPost("CreateBook")]
        public IActionResult CreateBook(NewBookVm newBook)
        {
            var id =_bookService.AddBook(newBook);
            if(id != 0)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPut("EditBook/{id}")]
        public IActionResult EditBook(NewBookVm newBook)
        {
            if(ModelState.IsValid)
            {
                _bookService.EditBook(newBook);
                return Ok();
            }
            throw new Exception("Błąd walidacji danych");
        }
        [HttpGet("BookDetails/{id}")]
        public ActionResult<Book> BookDetails(int id)
        {
            var book = _bookService.BookDetails(id);
            return Ok(book);
        }
    }
}
