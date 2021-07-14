using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Domain.Interfaces
{
    public interface IBookRepository
    {
         int AddBook(Book book);
        void DeleteBook(int bookId);
        void EditBook(Book book);
        IQueryable<Book> GetAllBooks();
        Book GetBookById(int bookId);
        IQueryable<Genre> GetAllGenres();
        int AddGenre(Genre genre);
        IQueryable<Author> GetAllAuthors();
        int AddAuthor(Author author);

    }
}
