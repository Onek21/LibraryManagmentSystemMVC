using AutoMapper;
using LibraryManagmentSystemMVC.Application.Mapping;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.ReservationVm
{
    public class ReservationForListVm :IMapFrom<Reservation>
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string CustomerName { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string ReservationStateName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Reservation, ReservationForListVm>()
                .ForMember(dt => dt.BookName, opt => opt.MapFrom(src => src.Book.Name))
                .ForMember(dt => dt.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                .ForMember(dt => dt.ReservationStateName, opt => opt.MapFrom(src => src.ReservationState.Name));
        }
    }
}
