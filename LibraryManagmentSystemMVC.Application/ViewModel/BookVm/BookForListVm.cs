using AutoMapper;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.BookVm
{
    public class BookForListVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PublishingHouse { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookForListVm>();
        }
    }
}
