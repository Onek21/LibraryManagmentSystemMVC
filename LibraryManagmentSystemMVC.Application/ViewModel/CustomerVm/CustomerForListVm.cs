using AutoMapper;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.CustomerVm
{
    public class CustomerForListVm : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerForListVm>()
                .ForMember(dt => dt.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
        }
    }
}
