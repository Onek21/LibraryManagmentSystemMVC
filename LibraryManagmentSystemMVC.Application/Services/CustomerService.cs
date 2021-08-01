using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.CustomerVm;
using LibraryManagmentSystemMVC.Domain.Interfaces;
using LibraryManagmentSystemMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _custRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _custRepo = customerRepository;
            _mapper = mapper;
        }
        public int AddCustomer(NewCustomerVm newCustomerVm)
        {
            var customer =_mapper.Map<Customer>(newCustomerVm);
            customer.IsActive = true;
            customer.Addresses = new List<Address>();
            foreach(var item in newCustomerVm.Addresses)
            {
                var address = new Address();
                address.Country = item.Country;
                address.City = item.City;
                address.Street = item.Street;
                address.HouseNumber = item.HouseNumber;

                customer.Addresses.Add(address);
            }
            var id = _custRepo.AddCustomer(customer);
            return id;
        }

        public void DeleteCustomer(NewCustomerVm newCustomerVm)
        {
            throw new NotImplementedException();
        }

        public void EditCustomer(NewCustomerVm newCustomerVm)
        {
            throw new NotImplementedException();
        }

        public List<CustomerForListVm> GetActiveCustomers()
        {
            var customers = _custRepo.GetAllCustomers().Where(x => x.IsActive == true).ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();
            return customers;
        }

        public CustomerDetailVm GetCustomerDetail(int id)
        {
            throw new NotImplementedException();
        }
    }
}
