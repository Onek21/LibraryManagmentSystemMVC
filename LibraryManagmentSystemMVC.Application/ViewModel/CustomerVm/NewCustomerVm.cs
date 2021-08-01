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
    public class NewCustomerVm : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public NewAddressVm newAddressVm { get; set; }
        public List<NewAddressVm> Addresses {get; set;}

        public NewCustomerVm()
        {
            Addresses = new List<NewAddressVm>();
            Addresses.Add(new NewAddressVm());
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCustomerVm, Customer>()
                .ForMember(src => src.Addresses, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
