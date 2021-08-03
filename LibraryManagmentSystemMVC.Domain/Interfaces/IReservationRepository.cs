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
        Reservation GetBookReservationById(int bookReservationId);
        IQueryable<Reservation> GetBookReservationsByCustomerId(int customerId);
        IQueryable<Reservation> GetReservations();
        void UpdateReservationStatus(Reservation reservation);
        IQueryable<ReservationState> GetReservationStates();
    }
}
