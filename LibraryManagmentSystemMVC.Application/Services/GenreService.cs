using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryManagmentSystemMVC.Application.Interfaces;
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
    public class GenreService : IGenreService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public GenreService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepo = bookRepository;
            _mapper = mapper;
        }
        public int AddGenre(NewGenreVm newGenreVm)
        {
            var genre = _mapper.Map<Genre>(newGenreVm);
            genre.IsActive = true;
            var id =_bookRepo.AddGenre(genre);
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
    }
}
