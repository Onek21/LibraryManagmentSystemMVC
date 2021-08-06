using AutoMapper;
using FluentValidation;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.GenreVm
{
    public class NewGenreVm : IMapFrom<Genre>
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        public bool IsActive { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewGenreVm, Genre>().ReverseMap();
        }
    }

    public class NewGenreValidation : AbstractValidator<NewGenreVm>
    {
        public NewGenreValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
