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

    public class CustomerForEditValidation : AbstractValidator<CustomerForEditVm>
    {
        public CustomerForEditValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).MinimumLength(2);
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).MinimumLength(2);
            RuleFor(x => x.PhoneNumber).Length(9);
            RuleFor(x => x.Email).EmailAddress();

        }
    }
}
