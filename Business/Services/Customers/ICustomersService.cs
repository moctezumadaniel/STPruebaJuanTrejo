using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Business.Services.Customers
{
    public interface ICustomersService
    {
        Customer CreateCustomer(Customer customer);
        Customer? UpdateCustomer(Customer customer);
        Customer? DeleteCustomer(Guid guid);
        IEnumerable<Customer> ReadCustomers(int limit);
        IEnumerable<Customer> GetCustomerByGuid(Guid id);
        Customer? GetCustomerByEmail(string email);
        IEnumerable<Item> GetCustomerItems(Guid id);



    }
}
