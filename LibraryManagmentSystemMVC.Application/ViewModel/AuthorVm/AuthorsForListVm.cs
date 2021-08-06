using AutoMapper;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.AuthorVm
{
    public class AuthorsForListVm : IMapFrom<Author>
    {
        public int Id { get; set; }
        [DisplayName("Imię i nazwisko")]
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorsForListVm>()
                .ForMember(dt => dt.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
        }
    }
}
