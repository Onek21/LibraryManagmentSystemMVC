using AutoMapper;
using FluentValidation;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Application.ViewModel.AuthorVm;
using LibraryManagmentSystemMVC.Application.ViewModel.GenreVm;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.BookVm
{
    public class NewBookVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Wydawnictwo")]
        public string PublishingHouse { get; set; }
        [DisplayName("Data wydania")]
        [DataType(DataType.Date)]
        public DateTime RealseDate { get; set; }
        [DisplayName("Ilość")]
        public int Quanity { get; set; }
        public int QuantityOnState { get; set; }
        [DisplayName("Autorzy")]
        public List<int> AuthorId { get; set; }
        [DisplayName("Gatunki")]
        public List<int> GenresId { get; set; }
        public IList<AuthorsForListVm> BookAuthors { get; set; }
        public IList<GenreForListVm> BookGenres { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, NewBookVm>()
                .ForMember(dto => dto.AuthorId, opt => opt.Ignore())
                .ForMember(dto => dto.GenresId, opt => opt.Ignore())
                .ForMember(dto => dto.BookAuthors, opt => opt.Ignore())
                .ForMember(dto => dto.BookGenres, opt => opt.Ignore())
                .ReverseMap();
        }
    }

    public class NewBookValidation : AbstractValidator<NewBookVm>
    {
        public NewBookValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2);
            RuleFor(x => x.PublishingHouse).NotEmpty();
            RuleFor(x => x.PublishingHouse).MinimumLength(2);
            RuleFor(x => x.RealseDate).NotEmpty();
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.GenresId).NotEmpty();
        }
    }
}
