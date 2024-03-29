﻿using AutoMapper;
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
    public class DocumentForListVm : IMapFrom<Document>
    {
        public int Id { get; set; }
        [DisplayName("Numer dokumentu")]
        public string DocumentNumber { get; set; }
        [DisplayName("Typ dokumentu")]
        public int Type { get; set; }
        [DisplayName("Nazwa książki")]
        public string BookName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Document, DocumentForListVm>()
                .ForMember(dt => dt.BookName, opt => opt.MapFrom(src => src.Book.Name));
        }
    }
}
