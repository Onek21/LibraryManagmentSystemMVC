using LibraryManagmentSystemMVC.Application.ViewModel.ReservationVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.Interfaces
{
    public interface IReservationService
    {
        List<ReservationForListVm> GetCurrnetReservations();
        List<ReservationForListVm> GetCanceledReservations();
        List<ReservationForListVm> GetCompletedReservations();
        int AddReservation(NewReservationVm newReservationVm);
        void CancelReservation(NewReservationVm newReservationVm);
        void ExtendReservation(NewReservationVm newReservationVm);
        void CompleteReservation(NewReservationVm newReservationVm);
        ReservationDetailVm ReservationDetail(int id);
        void MarkReservationAsOverTime();
        List<ReservationStateVm> GetReservationStates();
    }
}
