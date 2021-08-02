using AutoMapper;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.DocumentVm
{
    public class DocumentDetailVm : IMapFrom<Document>
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public int Quantity { get; set; }
        public int Type { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Document, DocumentDetailVm>();
        }
    }
}
