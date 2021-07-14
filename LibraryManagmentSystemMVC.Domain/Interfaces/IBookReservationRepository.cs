using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Domain.Interfaces
{
    public interface IBookReservationRepository
    {
        int AddBookReservation(BookReservation bookReservation);
        void UpdateBookReservation(BookReservation bookReservation);
        void DeleteBookReservation(int bookReservationId);
        BookReservation GetBookReservationById(int bookReservationId);
        IQueryable<BookReservation> GetBookReservationsByCustomerId(int customerId);
    }
}
