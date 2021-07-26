using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.AuthorVm;
using LibraryManagmentSystemMVC.Application.ViewModel.BookVm;
using LibraryManagmentSystemMVC.Application.ViewModel.GenreVm;
using LibraryManagmentSystemMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        public int AddBook()
        {
            throw new NotImplementedException();
        }

        public BookDetailsVm BookDetails(int id)
        {
            var book = _bookRepo.GetBookById(id);
            var bookVm = _mapper.Map<BookDetailsVm>(book);

            bookVm.BookAuthors = new List<AuthorsForListVm>();
            foreach(var item in book.BookAuthors)
            {
                var add = new AuthorsForListVm()
                {
                    Id = item.Author.Id,
                    Name = item.Author.FirstName + " " + item.Author.LastName

                };
                bookVm.BookAuthors.Add(add);
            }
            bookVm.BookGeners = new List<GenreForListVm>();
            foreach(var item in book.BookGeners)
            {
                var add = new GenreForListVm()
                {
                    Id = item.Genre.Id,
                    Name = item.Genre.Name
                };
                bookVm.BookGeners.Add(add);
            }
            return bookVm;
        }

        public List<BookForListVm> GetAllActiveBooksForList()
        {
            var books = _bookRepo.GetAllBooks().Where(p => p.IsActive == true).ProjectTo<BookForListVm>(_mapper.ConfigurationProvider).ToList();
            return books;
        }
    }
}
