using AutoMapper;
using FluentValidation;
using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.Services;
using LibraryManagmentSystemMVC.Application.ViewModel.AuthorVm;
using LibraryManagmentSystemMVC.Application.ViewModel.BookVm;
using LibraryManagmentSystemMVC.Application.ViewModel.CustomerVm;
using LibraryManagmentSystemMVC.Application.ViewModel.DocumentVm;
using LibraryManagmentSystemMVC.Application.ViewModel.GenreVm;
using LibraryManagmentSystemMVC.Application.ViewModel.ReservationVm;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LibraryManagmentSystemMVC.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IReservationService, ReservationService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IValidator<NewAuthorVm>, NewAuthorValidaton>();
            services.AddTransient<IValidator<NewBookVm>, NewBookValidation>();
            services.AddTransient<IValidator<NewCustomerVm>, NewCustomerValidation>();
            services.AddTransient<IValidator<CustomerForEditVm>, CustomerForEditValidation>();
            services.AddTransient<IValidator<NewAddressVm>, NewAddressValidation>();
            services.AddTransient<IValidator<NewGenreVm>, NewGenreValidation>();
            services.AddTransient<IValidator<NewDocumentVm>, NewDocumentValidation>();
            services.AddTransient<IValidator<NewReservationVm>, NewReservationValidation>();
            return services;
        }
    }
}
