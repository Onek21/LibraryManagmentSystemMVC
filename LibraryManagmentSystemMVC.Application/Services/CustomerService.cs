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
                address.IsActive = true;
                customer.Addresses.Add(address);
            }
            var id = _custRepo.AddCustomer(customer);
            return id;
        }

        public void DeleteCustomer(NewCustomerVm newCustomerVm)
        {
            throw new NotImplementedException();
        }

        public void EditAddress(List<NewAddressVm> newAddressVms)
        {
            foreach (var item in newAddressVms)
            {
                var address = _mapper.Map<Address>(item);
                _custRepo.UpdateAddress(address);
            }
        }

        public void EditCustomer(CustomerForEditVm customerForEditVm)
        {
            var customer = _mapper.Map<Customer>(customerForEditVm);
            _custRepo.UpdateCustomer(customer);
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

        public CustomerForEditVm GetCustomerForEdit(int id)
        {
            var customer = _custRepo.GetCustomerById(id);
            var customerVm = _mapper.Map<CustomerForEditVm>(customer);
            customerVm.Addresses = new List<NewAddressVm>();
            foreach (var item in customer.Addresses)
            {
                var add = new NewAddressVm()
                {
                    Id = item.Id,
                    CustomerId = item.CustomerId,
                    Country = item.Country,
                    City = item.City,
                    Street = item.Street,
                    HouseNumber = item.HouseNumber,
                    IsActive = item.IsActive
                };

                if (add.IsActive == true)
                { 
                    customerVm.Addresses.Add(add);
                }
            }
            return customerVm;
        }
    }
}
