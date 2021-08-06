using AutoMapper;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.BookVm
{
    public class BookForListVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Wydawnictwo")]
        public string PublishingHouse { get; set; }
        [DisplayName("Ilość")]
        public int Quanity { get; set; }
        [DisplayName("Ilość na stanie")]
        public int QuantityOnState { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookForListVm>();
        }
    }
}
