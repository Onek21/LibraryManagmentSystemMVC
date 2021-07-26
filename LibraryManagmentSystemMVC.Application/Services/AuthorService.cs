using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.AuthorVm;
using LibraryManagmentSystemMVC.Application.ViewModel.BookVm;
using LibraryManagmentSystemMVC.Domain.Interfaces;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AuthorService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public int AddAuthor(NewAuthorVm newAuthorVm)
        {
            var author = _mapper.Map<Author>(newAuthorVm);
            author.IsActive = true;
            var id = _bookRepository.AddAuthor(author);
            return id;
        }

        public void DeleteAuthor(NewAuthorVm model)
        {
            var author = _mapper.Map<Author>(model);
            author.IsActive = false;
            _bookRepository.DeleteAuthor(author);
        }

        public List<AuthorsForListVm> GetAllActiveAuthors()
        {
            var authors = _bookRepository.GetAllAuthors().Where(p => p.IsActive == true).ProjectTo<AuthorsForListVm>(_mapper.ConfigurationProvider).ToList();
            return authors;
        }

        public AuthorDetailVm GetAuthorDetail(int id)
        {
            var author = _bookRepository.GetAuthorById(id);
            var authorVm = _mapper.Map<AuthorDetailVm>(author);
            authorVm.Books = new List<BookForListVm>();
            foreach(var item in author.BookAuthors)
            {
                var book = new BookForListVm()
                {
                    Id = item.Book.Id,
                    Name = item.Book.Name
                };
                authorVm.Books.Add(book);
                
            };
            return authorVm;
        }

        public NewAuthorVm GetAuthorForEdit(int id)
        {
            var author = _bookRepository.GetAuthorById(id);
            var authorVm = _mapper.Map<NewAuthorVm>(author);
            return authorVm;
        }

        public void UpdateAuthor(NewAuthorVm model)
        {
            var author = _mapper.Map<Author>(model);
            _bookRepository.EditAuthor(author);
        }
    }
}
