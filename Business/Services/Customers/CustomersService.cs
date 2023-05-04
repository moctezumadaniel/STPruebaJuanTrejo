using PruebaSTJuanTrejo.Data;
using PruebaSTJuanTrejo.Data.Repositories.Customers;
using PruebaSTJuanTrejo.Entities;
using System;

namespace PruebaSTJuanTrejo.Business.Services.Customers
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly DataContext _dataContext;
        public CustomersService(
            ICustomersRepository customersRepository,
            DataContext dataContext)
        {
            _customersRepository = customersRepository;
            _dataContext = dataContext;
        }
        public Customer CreateCustomer(Customer customer)
        {
            var result = _customersRepository.InsertCustomer(customer);
            return result;
        }

        public Customer? DeleteCustomer(Guid guid)
        {
            var result = _customersRepository.DeleteCustomer(guid);
            return result;
        }

        public Customer? GetCustomerByEmail(string email)
        {
            var customer = _customersRepository.GetCustomerByEmail(email);
            return customer;
        }

        public IEnumerable<Customer> GetCustomerByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetCustomerItems(Guid id)
        {
            var itemsIds = from itemtoCustomer in _dataContext.ItemToCustomers
                        where itemtoCustomer.CustomerId == id
                        select itemtoCustomer.ItemId;
            var items = from item in _dataContext.Items
                       where itemsIds.Contains(item.Id)
                       select item;
            return items;
        }

        public IEnumerable<Customer> ReadCustomers(int limit)
        {
            var result = _customersRepository.ReadCustomers(limit);
            return result;
        }

        public Customer? UpdateCustomer(Customer customer)
        {
            var result = _customersRepository.EditCustomer(customer);
            return result;
        }
    }
}
