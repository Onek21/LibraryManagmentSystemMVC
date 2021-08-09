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
        void CancelReservation(int id);
        void ExtendReservation(int id);
        void CompleteReservation(int id);
        ReservationDetailVm ReservationDetail(int id);
        void MarkReservationAsOverTime();
        List<ReservationStateVm> GetReservationStates();
        List<ReservationForListVm> GetCustomerReservations(int customerId);
    }
}
