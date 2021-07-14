using LibraryManagmentSystemMVC.Domain.Interfaces;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Context _context;

        public BookRepository(Context context)
        {
            _context = context;
        }

        public int AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }

        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Find(bookId);

            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public void EditBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public IQueryable<Book> GetAllBooks()
        {
            var books = _context.Books;
            return books;
        }

        public Book GetBookById(int bookId)
        {
            var book = _context.Books.FirstOrDefault(p => p.Id == bookId);
            return book;
        }

        public IQueryable<Genre> GetAllGenres()
        {
            var genres = _context.Genres;
            return genres;
        }

        public int AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return genre.Id;
        }

        public IQueryable<Author> GetAllAuthors()
        {
            var authors = _context.Authors;
            return authors;
        }

        public int AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author.Id;
        }
    }
}
