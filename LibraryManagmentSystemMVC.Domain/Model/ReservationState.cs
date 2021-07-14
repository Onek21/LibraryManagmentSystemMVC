using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Domain.Model
{
    public class ReservationState
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BookReservation BookReservation { get; set; }
    }
}
