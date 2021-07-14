using LibraryManagmentSystemMVC.Domain.Interfaces;
using LibraryManagmentSystemMVC.Domain.Model;
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

        public void UpdateBookReservation(Reservation bookReservation)
        {
            _context.Reservations.Update(bookReservation);
            _context.SaveChanges();
        }

        public void DeleteBookReservation(int bookReservationId)
        {
            var bookReservation = _context.Reservations.Find(bookReservationId);

            if(bookReservation != null)
            {
                _context.Reservations.Remove(bookReservation);
                _context.SaveChanges();
            }
        }

        public Reservation GetBookReservationById(int bookReservationId)
        {
            var bookReservation = _context.Reservations.Find(bookReservationId);
            return bookReservation;
        }

        public IQueryable<Reservation> GetBookReservationsByCustomerId(int customerId)
        {
            var bookReservations = _context.Reservations.Where(p => p.CustomerId == customerId);
            return bookReservations;
        }
    }
}
