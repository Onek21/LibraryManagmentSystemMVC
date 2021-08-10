using AutoMapper;
using FluentValidation;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.UsersVm
{
    public class NewUserVm : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }
        [DisplayName("Nazwa użytkownika")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [DisplayName("Hasło")]
        public string Password { get; set; }
        [DisplayName("Potwierdź hasło")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Imię")]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewUserVm, ApplicationUser>()
                .ReverseMap();
        }
    }

    public class NewUserVmValidation : AbstractValidator<NewUserVm>
    {
        public NewUserVmValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Nazwa użytkownika nie może być pusta");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email nie może być pusty").EmailAddress().WithMessage("Proszę podać adres email w odpowiednim formacie");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Hasła muszą być identyczne");
            RuleFor(x => x.Password).MinimumLength(8).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).*$").WithMessage("Hasło musi posiadać długość min. 8 znaków oraz zawierać cyfrę, małą oraz wielką literę");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Polę 'imię' nie może być puste");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Polę 'nazwisko' nie może być puste");
        }
    }
}
