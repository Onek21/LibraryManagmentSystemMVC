using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.ReservationVm;
using LibraryManagmentSystemMVC.Domain.Interfaces;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IBookRepository bookRepository ,IMapper mapper)
        {
            _reservationRepo = reservationRepository;
            _bookRepo = bookRepository;
            _mapper = mapper;
        }

        public int AddReservation(NewReservationVm newReservationVm)
        {
            var reservation = _mapper.Map<Reservation>(newReservationVm);
            reservation.ReservationStateId = 2;
            reservation.EndDate = DateTime.Today.AddDays(30);
            reservation.IsActive = true;
            _reservationRepo.AddBookReservation(reservation);
            var book = _bookRepo.GetBookById(reservation.BookId);
            book.QuantityOnState -= 1;
            _bookRepo.UpdateQuantityOnState(book);
            return reservation.Id;
        }

        public void CancelReservation(int id)
        {
            var reservation = _reservationRepo.GetBookReservationById(id);
            reservation.ReservationStateId = 1;
            var book = _bookRepo.GetBookById(reservation.BookId);
            book.QuantityOnState += 1;
            _bookRepo.UpdateQuantityOnState(book);
            _reservationRepo.UpdateReservationStatus(reservation);
        }

        public void CompleteReservation(int id)
        {
            var reservation = _reservationRepo.GetBookReservationById(id);
            reservation.ReservationStateId = 5;
            var book = _bookRepo.GetBookById(reservation.BookId);
            book.QuantityOnState += 1;
            _bookRepo.UpdateQuantityOnState(book);
            _reservationRepo.UpdateReservationStatus(reservation);
        }

        public void ExtendReservation(int id)
        {
            var reservation = _reservationRepo.GetBookReservationById(id);
            reservation.ReservationStateId = 4;
            reservation.EndDate = reservation.EndDate.AddDays(30);
            _reservationRepo.UpdateReservationStatus(reservation);
        }

        public List<ReservationForListVm> GetCanceledReservations()
        {
            var reservations = _reservationRepo.GetReservations().Where(x => x.ReservationStateId == 1).ProjectTo<ReservationForListVm>(_mapper.ConfigurationProvider).ToList();
            return reservations;
        }

        public List<ReservationForListVm> GetCompletedReservations()
        {
            var reservations = _reservationRepo.GetReservations().Where(x => x.ReservationStateId == 5).ProjectTo<ReservationForListVm>(_mapper.ConfigurationProvider).ToList();
            return reservations;
        }

        public List<ReservationForListVm> GetCurrnetReservations()
        {
            var reservations = _reservationRepo.GetReservations().Where(x => x.ReservationStateId == 2 || x.ReservationStateId == 4).ProjectTo<ReservationForListVm>(_mapper.ConfigurationProvider).ToList();
            return reservations;
        }

        public List<ReservationStateVm> GetReservationStates()
        {
            var reservationStates = _reservationRepo.GetReservationStates().ProjectTo<ReservationStateVm>(_mapper.ConfigurationProvider).ToList();
            return reservationStates;
        }

        public void MarkReservationAsOverTime()
        {
            var reservations = _reservationRepo.GetReservations().Where(x => x.ReservationStateId == 2).ToList();

            foreach(var item in reservations)
            {
                if(item.EndDate < DateTime.Now)
                {
                    item.ReservationStateId = 3;
                    _reservationRepo.UpdateReservationStatus(item);
                }
            }
        }

        public ReservationDetailVm ReservationDetail(int id)
        {
            var reservation = _reservationRepo.GetBookReservationById(id);
            var reservationVm = _mapper.Map<ReservationDetailVm>(reservation);
            return reservationVm;
        }
    }
}
