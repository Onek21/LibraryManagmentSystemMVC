using LibraryManagmentSystemMVC.Application.ViewModel.AuthorVm;
using LibraryManagmentSystemMVC.Application.ViewModel.BookVm;
using LibraryManagmentSystemMVC.Application.ViewModel.GenreVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.Interfaces
{
     public interface IBookService
    {
        List<BookForListVm> GetAllActiveBooksForList();
        int AddBook(NewBookVm newBookVm);
        BookDetailsVm BookDetails(int id);

        List<GenreForListVm> GetActiveGenres();
        NewGenreVm GetGenreForUpdate(int id);
        int AddGenre(NewGenreVm newGenreVm);
        void UpdateGenre(NewGenreVm newGenreVm);
        void DeleteGenre(NewGenreVm newGenreVm);

        List<AuthorsForListVm> GetAllActiveAuthors();
        AuthorDetailVm GetAuthorDetail(int id);
        NewAuthorVm GetAuthorForEdit(int id);
        void UpdateAuthor(NewAuthorVm model);
        int AddAuthor(NewAuthorVm newAuthorVm);
        void DeleteAuthor(NewAuthorVm newAuthorVm);
        void DeleteBook(NewBookVm newBookVm);
        object GetBookToEdit(int id);
        void EditBook(NewBookVm newBookVm);
    }
}
