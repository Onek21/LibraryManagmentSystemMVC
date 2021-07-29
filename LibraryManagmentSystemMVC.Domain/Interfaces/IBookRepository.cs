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
        void DeleteBook(Book book);
        void EditBook(Book book);
        IQueryable<Book> GetAllBooks();
        Book GetBookById(int bookId);
        IQueryable<Genre> GetAllGenres();
        int AddGenre(Genre genre);
        IQueryable<Author> GetAllAuthors();
        int AddAuthor(Author author);
        Author GetAuthorById(int authorId);
        void EditAuthor(Author author);
        void DeleteAuthor(Author author);
        void DeleteGenre(Genre genre);
        Genre GetGenreById(int id);
        void EditGenre(Genre genre);
        void DeleteBookGenreById(int id);
        void DeleteBookAuthorById(int id);
        void AddBookAuthors(BookAuthor bookauthor);
        void AddBookGenre(BookGenre bookgenre);
    }
}
