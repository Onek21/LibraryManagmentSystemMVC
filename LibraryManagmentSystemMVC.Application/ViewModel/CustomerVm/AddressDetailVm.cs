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
    public class AddressDetailVm : IMapFrom<Address>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressDetailVm>();
        }
    }
}
