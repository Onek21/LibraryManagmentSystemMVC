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
        void EditCustomer(NewCustomerVm newCustomerVm);
        void DeleteCustomer(NewCustomerVm newCustomerVm);
        CustomerDetailVm GetCustomerDetail(int id);

        

    }
}
