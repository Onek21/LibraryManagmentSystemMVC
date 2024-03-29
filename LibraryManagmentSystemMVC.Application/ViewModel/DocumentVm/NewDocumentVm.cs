﻿using AutoMapper;
using FluentValidation;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.DocumentVm
{
    public class NewDocumentVm : IMapFrom<Document>
    {
        public int Id { get; set; }
        [DisplayName("Numer dokumentu")]
        public string DocumentNumber { get; set; }
        [DisplayName("Ilość")]
        public int Quantity { get; set; }
        [DisplayName("Typ dokumentu")]
        public int Type { get; set; }
        [DisplayName("Nazwa książki")]
        public int BookId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Document, NewDocumentVm>().ReverseMap();
        }
    }

    public class NewDocumentValidation : AbstractValidator<NewDocumentVm>
    {
        public NewDocumentValidation()
        {
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.Type).NotEmpty();
        }
    }
}
