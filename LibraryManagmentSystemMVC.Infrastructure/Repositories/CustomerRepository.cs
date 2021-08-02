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
            _context.Attach(customer);
            _context.Entry(customer).Property("FirstName").IsModified = true;
            _context.Entry(customer).Property("LastName").IsModified = true;
            _context.Entry(customer).Property("PhoneNumber").IsModified = true;
            _context.Entry(customer).Property("Email").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).Property("IsActive").IsModified = true;
            _context.SaveChanges();
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            var customers = _context.Customers
                .Include(addreesses => addreesses.Addresses);
            return customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = _context.Customers
                .Include(addresses => addresses.Addresses)
                .FirstOrDefault(x => x.Id == customerId);
            return customer;
        }

        public void UpdateAddress(Address address)
        {
            _context.Attach(address);
            _context.Entry(address).Property("Country").IsModified = true;
            _context.Entry(address).Property("City").IsModified = true;
            _context.Entry(address).Property("Street").IsModified = true;
            _context.Entry(address).Property("HouseNumber").IsModified = true;
            _context.Entry(address).Property("IsActive").IsModified = true;
            _context.SaveChanges();
        }
    }
}
