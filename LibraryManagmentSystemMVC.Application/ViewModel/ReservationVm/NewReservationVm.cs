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
    public class NewReservationVm :IMapFrom<Reservation>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ReservationStateId { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<NewReservationVm, Reservation>().ReverseMap();
        }
    }
}
