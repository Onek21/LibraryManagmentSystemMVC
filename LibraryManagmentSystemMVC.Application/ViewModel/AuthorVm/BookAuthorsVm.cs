using AutoMapper;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Application.ViewModel.BookVm;
using LibraryManagmentSystemMVC.Domain.Model;

namespace LibraryManagmentSystemMVC.Application.ViewModel.AuthorVm
{
    public class BookAuthorsVm : IMapFrom<BookAuthor>
    {
        public int BookId { get; set; }
        public NewBookVm Book { get; set; }
        public int AuthorId { get; set; }
        public NewAuthorVm Author { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BookAuthorsVm, BookAuthor>().ReverseMap();
        }
    }
}
