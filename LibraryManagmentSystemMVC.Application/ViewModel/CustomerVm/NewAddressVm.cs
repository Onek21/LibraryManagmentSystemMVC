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
    public class NewAddressVm :IMapFrom<Address>
    {
        public int Id { get; set; }
        [DisplayName("Kraj")]
        public string Country { get; set; }
        [DisplayName("Miasto")]
        public string City { get; set; }
        [DisplayName("Ulica")]
        public string Street { get; set; }
        [DisplayName("Numer domu")]
        public string HouseNumber { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewAddressVm, Address>().ReverseMap();
        }
    }

    public class NewAddressValidation : AbstractValidator<NewAddressVm>
    {
        public NewAddressValidation()
        {
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.HouseNumber).NotEmpty();
        }
    }
}
