using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Domain.Interfaces
{
    public interface IReservationRepository
    {
        int AddBookReservation(Reservation bookReservation);
        void UpdateBookReservation(Reservation bookReservation);
        void DeleteBookReservation(int bookReservationId);
        Reservation GetBookReservationById(int bookReservationId);
        IQueryable<Reservation> GetBookReservationsByCustomerId(int customerId);
    }
}
