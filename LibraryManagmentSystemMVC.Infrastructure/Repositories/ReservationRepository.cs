using LibraryManagmentSystemMVC.Domain.Interfaces;
using LibraryManagmentSystemMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly Context _context;

        public ReservationRepository(Context context)
        {
            _context = context;
        }

        public int AddBookReservation(Reservation bookReservation)
        {
            _context.Reservations.Add(bookReservation);
            _context.SaveChanges();
            return bookReservation.Id;
        }

        public Reservation GetBookReservationById(int bookReservationId)
        {
            var bookReservation = _context.Reservations
                .Include(books => books.Book)
                .Include(customers => customers.Customer)
                .Include(reservationStates => reservationStates.ReservationState)
                .FirstOrDefault(x => x.Id == bookReservationId);
            return bookReservation;
        }

        public IQueryable<Reservation> GetBookReservationsByCustomerId(int customerId)
        {
            var bookReservations = _context.Reservations.Where(p => p.CustomerId == customerId);
            return bookReservations;
        }

        public IQueryable<Reservation> GetReservations()
        {
            var reservations = _context.Reservations
                .Include(books => books.Book)
                .Include(customers => customers.Customer)
                .Include(reservationStates => reservationStates.ReservationState);
            return reservations;
        }

        public IQueryable<ReservationState> GetReservationStates()
        {
            var reservationStates = _context.ReservationStates;
            return reservationStates;
        }

        public void UpdateReservationStatus(Reservation reservation)
        {
            _context.Attach(reservation);
            _context.Entry(reservation).Property("ReservationStateId").IsModified = true;
            _context.SaveChanges();
        }
    }
}
