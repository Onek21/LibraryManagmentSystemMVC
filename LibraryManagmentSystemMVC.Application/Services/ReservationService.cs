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
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepo = reservationRepository;
            _mapper = mapper;
        }

        public int AddReservation(NewReservationVm newReservationVm)
        {
            var reservation = _mapper.Map<Reservation>(newReservationVm);
            _reservationRepo.AddBookReservation(reservation);
            return reservation.Id;
        }

        public void CancelReservation(NewReservationVm newReservationVm)
        {
            var reservation = _mapper.Map<Reservation>(newReservationVm);
            reservation.ReservationStateId = 1;
            _reservationRepo.UpdateReservationStatus(reservation);
        }

        public void CompleteReservation(NewReservationVm newReservationVm)
        {
            var reservation = _mapper.Map<Reservation>(newReservationVm);
            reservation.ReservationStateId = 5;
            _reservationRepo.UpdateReservationStatus(reservation);
        }

        public void ExtendReservation(NewReservationVm newReservationVm)
        {
            var reservation = _mapper.Map<Reservation>(newReservationVm);
            reservation.ReservationStateId = 4;
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
            var reservations = _reservationRepo.GetReservations().Where(x => x.ReservationStateId == 2).ProjectTo<ReservationForListVm>(_mapper.ConfigurationProvider).ToList();
            return reservations;
        }

        public List<ReservationStateVm> GetReservationStates()
        {
            var reservationStates = _reservationRepo.GetReservationStates().ProjectTo<ReservationStateVm>(_mapper.ConfigurationProvider).ToList();
            return reservationStates;
        }

        public void MarkReservationAsOverTime()
        {
            var reservations = _reservationRepo.GetReservations().Where(x => x.ReservationStateId == 2).ProjectTo<Reservation>(_mapper.ConfigurationProvider).ToList();

            foreach(var item in reservations)
            {
                if(item.EndDate > DateTime.Now)
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
