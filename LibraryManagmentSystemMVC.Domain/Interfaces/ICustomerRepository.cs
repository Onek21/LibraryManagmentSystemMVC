using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        IQueryable<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
    }
}
