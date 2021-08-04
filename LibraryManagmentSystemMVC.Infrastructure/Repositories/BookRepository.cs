using LibraryManagmentSystemMVC.Domain.Interfaces;
using LibraryManagmentSystemMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
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

        public void DeleteBook(Book book)
        {
            _context.Attach(book);
            _context.Entry(book).Property("IsActive").IsModified = true;
            _context.SaveChanges();
        }

        public void EditBook(Book book)
        {
            _context.Attach(book);
            _context.Entry(book).Property("Name").IsModified = true;
            _context.Entry(book).Property("PublishingHouse").IsModified = true;
            _context.Entry(book).Property("RealseDate").IsModified = true;
            _context.SaveChanges();
        }

        public IQueryable<Book> GetAllBooks()
        {
            var books = _context.Books;
            return books;
        }

        public Book GetBookById(int bookId)
        {
            var book = _context.Books
                .Include(bookauthors => bookauthors.BookAuthors)
                .ThenInclude(authors => authors.Author)
                .Include(bookgeneres => bookgeneres.BookGeners)
                .ThenInclude(geners => geners.Genre)
                .FirstOrDefault(x => x.Id == bookId);
            //var book = _context.Books.Find(bookId);
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

        public Author GetAuthorById(int authorId)
        {
            var author = _context.Authors
                .Include(bookauthors => bookauthors.BookAuthors)
                .ThenInclude(book => book.Book)
                .FirstOrDefault(x => x.Id == authorId);
            return author;
        }

        public void EditAuthor(Author author)
        {
            _context.Attach(author);
            _context.Entry(author).Property("FirstName").IsModified = true;
            _context.Entry(author).Property("LastName").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteAuthor(Author author)
        {
            _context.Attach(author);
            _context.Entry(author).Property("IsActive").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteGenre(Genre genre)
        {
            _context.Attach(genre);
            _context.Entry(genre).Property("IsActive").IsModified = true;
            _context.SaveChanges();
        }

        public Genre GetGenreById(int id)
        {
            var genre =_context.Genres.Find(id);
            return genre;
        }

        public void EditGenre(Genre genre)
        {
            _context.Attach(genre);
            _context.Entry(genre).Property("Name").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteBookGenreById(int id)
        {
            var model = _context.BookGenre.FirstOrDefault(x => x.BookId == id);
            if(model != null)
            {
                _context.BookGenre.Remove(model);
                _context.SaveChanges();
            }
        }

        public void DeleteBookAuthorById(int id)
        {
            var model = _context.BookAuthor.FirstOrDefault(x => x.BookId == id);
            if (model != null)
            {
                _context.BookAuthor.Remove(model);
                _context.SaveChanges();
            }
        }

        public void AddBookAuthors(BookAuthor bookauthor)
        {
            _context.BookAuthor.Add(bookauthor);
            _context.SaveChanges();
        }

        public void AddBookGenre(BookGenre bookgenre)
        {
            _context.BookGenre.Add(bookgenre);
            _context.SaveChanges();
        }

        public IQueryable<Document> GetAllDocuments()
        {
            var model = _context.Documents
                 .Include(books => books.Book);
            return model;
        }

        public int AddDocument(Document document)
        {
            _context.Documents.Add(document);
            _context.SaveChanges();
            return document.Id;
        }

        public void UpdateBookQuantity(Book book)
        {
            _context.Attach(book);
            _context.Entry(book).Property("Quanity").IsModified = true;
            _context.Entry(book).Property("QuantityOnState").IsModified = true;
            _context.SaveChanges();

        }

        public Document GetDocumentById(int id)
        {
            var model = _context.Documents
                .Include(books => books.Book)
                .FirstOrDefault(x => x.Id == id);
            return model;
        }

        public void UpdateQuantityOnState(Book book)
        {
            _context.Attach(book);
            _context.Entry(book).Property("QuantityOnState").IsModified = true;
            _context.SaveChanges();
        }
    }
}
