using AutoMapper;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Application.ViewModel.AuthorVm;
using LibraryManagmentSystemMVC.Application.ViewModel.GenreVm;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.BookVm
{
    public class BookDetailsVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PublishingHouse { get; set; }
        public DateTime RealseDate { get; set; }
        public int Quanity { get; set; }
        public int QuantityOnState { get; set; }
        public IList<AuthorsForListVm> BookAuthors { get; set; }
        public IList<GenreForListVm> BookGeners { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsVm>()
                .ForMember(dto => dto.BookAuthors, opt => opt.Ignore())
                .ForMember(dto => dto.BookGeners, opt => opt.Ignore());
        }
    }
}
