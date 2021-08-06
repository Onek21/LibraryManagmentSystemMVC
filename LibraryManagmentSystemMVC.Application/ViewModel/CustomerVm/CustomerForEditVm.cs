using AutoMapper;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.CustomerVm
{
    public class CustomerForEditVm : IMapFrom<Customer>
    {
        public int Id { get; set; }
        [DisplayName("Imię")]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }
        [DisplayName("Numer telefonu")]
        public string PhoneNumber { get; set; }
        [DisplayName("Mail")]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        [DisplayName("Adresy")]
        public List<NewAddressVm> Addresses { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerForEditVm, Customer>()
                .ForMember(src => src.Addresses, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
