using LibraryManagmentSystemMVC.Domain.Interfaces;
using LibraryManagmentSystemMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Infrastructure.Repositories
{
    public class CustomerRepository :ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public int AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.Id;
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            var customers = _context.Customers
                .Include(addreesses => addreesses.Addresses);
            return customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            return customer;
        }

        
    }
}
