using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.AuthorVm;
using LibraryManagmentSystemMVC.Application.ViewModel.BookVm;
using LibraryManagmentSystemMVC.Application.ViewModel.DocumentVm;
using LibraryManagmentSystemMVC.Application.ViewModel.GenreVm;
using LibraryManagmentSystemMVC.Domain.Interfaces;
using LibraryManagmentSystemMVC.Domain.Model;
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

        public int AddAuthor(NewAuthorVm newAuthorVm)
        {
            var author = _mapper.Map<Author>(newAuthorVm);
            author.IsActive = true;
            var id = _bookRepo.AddAuthor(author);
            return id;
        }

        public void DeleteAuthor(NewAuthorVm model)
        {
            var author = _mapper.Map<Author>(model);
            author.IsActive = false;
            _bookRepo.DeleteAuthor(author);
        }

        public List<AuthorsForListVm> GetAllActiveAuthors()
        {
            var authors = _bookRepo.GetAllAuthors().Where(p => p.IsActive == true).ProjectTo<AuthorsForListVm>(_mapper.ConfigurationProvider).ToList();
            return authors;
        }

        public AuthorDetailVm GetAuthorDetail(int id)
        {
            var author = _bookRepo.GetAuthorById(id);
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
            var author = _bookRepo.GetAuthorById(id);
            var authorVm = _mapper.Map<NewAuthorVm>(author);
            return authorVm;
        }

        public void UpdateAuthor(NewAuthorVm model)
        {
            var author = _mapper.Map<Author>(model);
            _bookRepo.EditAuthor(author);
        }

        public int AddGenre(NewGenreVm newGenreVm)
        {
            var genre = _mapper.Map<Genre>(newGenreVm);
            genre.IsActive = true;
            var id = _bookRepo.AddGenre(genre);
            return id;
        }

        public void DeleteGenre(NewGenreVm newGenreVm)
        {
            var genre = _mapper.Map<Genre>(newGenreVm);
            genre.IsActive = false;
            _bookRepo.DeleteGenre(genre);
        }

        public List<GenreForListVm> GetActiveGenres()
        {
            var genres = _bookRepo.GetAllGenres().Where(p => p.IsActive).ProjectTo<GenreForListVm>(_mapper.ConfigurationProvider).ToList();
            return genres;
        }

        public NewGenreVm GetGenreForUpdate(int id)
        {
            var genre = _bookRepo.GetGenreById(id);
            var genreVm = _mapper.Map<NewGenreVm>(genre);
            return genreVm;
        }

        public void UpdateGenre(NewGenreVm newGenreVm)
        {
            var genre = _mapper.Map<Genre>(newGenreVm);
            _bookRepo.EditGenre(genre);
        }

        public int AddBook(NewBookVm model)
        {
            var book = _mapper.Map<Book>(model);
            List<Author> authors = new List<Author>();
            foreach(var item in model.AuthorId)
            {
                var add = _bookRepo.GetAuthorById(item);
                authors.Add(add);
            }
            book.BookAuthors = new List<BookAuthor>();
            foreach(var author in authors)
            {
                var bookauthor = new BookAuthor();
                bookauthor.Author = author;
                bookauthor.Book = book;
                book.BookAuthors.Add(bookauthor);
            }
            List<Genre> genres = new List<Genre>();
            foreach(var item in model.GenresId)
            {
                var add = _bookRepo.GetGenreById(item);
                genres.Add(add);
            }
            book.BookGeners = new List<BookGenre>();
            foreach(var genre in genres)
            {
                var bookgenres = new BookGenre();
                bookgenres.Genre = genre;
                bookgenres.Book = book;
                book.BookGeners.Add(bookgenres);
            }
            book.QuantityOnState = book.Quanity;
            book.IsActive = true;
            var id = _bookRepo.AddBook(book);
            return id;
        }

        public void DeleteBook(NewBookVm newBookVm)
        {
            var book = _mapper.Map<Book>(newBookVm);
            book.IsActive = false;
            _bookRepo.DeleteBook(book);

        }

        public object GetBookToEdit(int id)
        {
            var book = _bookRepo.GetBookById(id);
            var bookVm = _mapper.Map<NewBookVm>(book);
            bookVm.AuthorId = new List<int>();
            foreach(var item in book.BookAuthors)
            {
                bookVm.AuthorId.Add(item.AuthorId);
            }
            bookVm.GenresId = new List<int>();
            foreach(var item in book.BookGeners)
            {
                bookVm.GenresId.Add(item.GenreId);
            }
            return bookVm;
        }

        public void EditBook(NewBookVm newBookVm)
        {
            _bookRepo.DeleteBookAuthorById(newBookVm.Id);
            _bookRepo.DeleteBookGenreById(newBookVm.Id);

            var book = _mapper.Map<Book>(newBookVm);
            List<Author> authors = new List<Author>();
            foreach (var item in newBookVm.AuthorId)
            {
                var add = _bookRepo.GetAuthorById(item);
                authors.Add(add);
            }
            foreach (var author in authors)
            {
                var bookauthor = new BookAuthor();
                bookauthor.AuthorId = author.Id;
                bookauthor.BookId = book.Id;
                _bookRepo.AddBookAuthors(bookauthor);
            }
            List<Genre> genres = new List<Genre>();
            foreach (var item in newBookVm.GenresId)
            {
                var add = _bookRepo.GetGenreById(item);
                genres.Add(add);
            }
            foreach (var genre in genres)
            {
                var bookgenre = new BookGenre();
                bookgenre.GenreId = genre.Id;
                bookgenre.BookId = book.Id;
                _bookRepo.AddBookGenre(bookgenre);
            }
            _bookRepo.EditBook(book);
        }

        public List<DocumentForListVm> GetDocumentsForList()
        {
            var documents = _bookRepo.GetAllDocuments().ProjectTo<DocumentForListVm>(_mapper.ConfigurationProvider).ToList();
            return documents;
        }

        public int AddDocument(NewDocumentVm newDocumentVm)
        {
            var document = _mapper.Map<Document>(newDocumentVm);

            var year = DateTime.Now.Year;
            var lastId = _bookRepo.GetAllDocuments().OrderByDescending(p => p.Id).Select(r => r.Id).FirstOrDefault();
            if (lastId == 0)
            {
                document.DocumentNumber = $"{year}/1";
            }
            else
            {
                lastId += 1;
                document.DocumentNumber = $"{year}/{lastId}";
            }
            if(document.Type == 1)
            {
                var book = _bookRepo.GetBookById(document.BookId);
                book.Quanity  += document.Quantity;
                book.QuantityOnState += document.Quantity;
                _bookRepo.UpdateBookQuantity(book);
            }
            else
            {
                var book = _bookRepo.GetBookById(document.BookId);
                book.Quanity -= document.Quantity;
                book.QuantityOnState -= document.Quantity;
                _bookRepo.UpdateBookQuantity(book);
            }
            var id = _bookRepo.AddDocument(document);
            return id;
        }

        public DocumentDetailVm GetDocumentById(int id)
        {
            var document = _bookRepo.GetDocumentById(id);
            var documentVm = _mapper.Map<DocumentDetailVm>(document);
            return documentVm;
        }

    }
}
