using LibraryManagmentSystemMVC.Domain.Interfaces;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Infrastructure.Repositories
{
    public class BookReservationRepository : IBookReservationRepository
    {
        private readonly Context _context;

        public BookReservationRepository(Context context)
        {
            _context = context;
        }

        public int AddBookReservation(BookReservation bookReservation)
        {
            _context.BookReservations.Add(bookReservation);
            _context.SaveChanges();
            return bookReservation.Id;
        }

        public void UpdateBookReservation(BookReservation bookReservation)
        {
            _context.BookReservations.Update(bookReservation);
            _context.SaveChanges();
        }

        public void DeleteBookReservation(int bookReservationId)
        {
            var bookReservation = _context.BookReservations.Find(bookReservationId);

            if(bookReservation != null)
            {
                _context.BookReservations.Remove(bookReservation);
                _context.SaveChanges();
            }
        }

        public BookReservation GetBookReservationById(int bookReservationId)
        {
            var bookReservation = _context.BookReservations.FirstOrDefault(p => p.Id == bookReservationId);
            return bookReservation;
        }

        public IQueryable<BookReservation> GetBookReservationsByCustomerId(int customerId)
        {
            var bookReservations = _context.BookReservations.Where(p => p.CustomerId == customerId);
            return bookReservations;
        }
    }
}
