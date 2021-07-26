using LibraryManagmentSystemMVC.Application.ViewModel.GenreVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.Interfaces
{
    public interface IGenreService
    {
        List<GenreForListVm> GetActiveGenres();
        NewGenreVm GetGenreForUpdate(int id);
        int AddGenre(NewGenreVm newGenreVm);
        void UpdateGenre(NewGenreVm newGenreVm);
        void DeleteGenre(NewGenreVm newGenreVm);


    }
}
