using LibraryManagmentSystemMVC.Application.ViewModel.CustomerVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerForListVm> GetActiveCustomers();
        int AddCustomer(NewCustomerVm newCustomerVm);
        void EditCustomer(CustomerForEditVm customerForEditVm);
        void DeleteCustomer(NewCustomerVm newCustomerVm);
        CustomerDetailVm GetCustomerDetail(int id);
        CustomerForEditVm GetCustomerForEdit(int id);
        void EditAddress(List<NewAddressVm> newAddressVms);
    }
}
