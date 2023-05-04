using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Data.Repositories.Customers
{
    public interface ICustomersRepository
    {

        Customer InsertCustomer(Customer customer);

        Customer? EditCustomer(Customer customer);

        Customer? DeleteCustomer(Guid guid);

        IEnumerable<Customer> ReadCustomers(int limit);

        Customer? GetCustomerByGuid(Guid id);
        Customer? GetCustomerByEmail(string email);

    }
}
