using PruebaSTJuanTrejo.Entities;

namespace PruebaSTJuanTrejo.Data.Repositories.Customers
{
    public class CustomersRepository: ICustomersRepository
    {
        private readonly DataContext _dataContext;
        public CustomersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Customer InsertCustomer(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            _dataContext.Customers.Add(customer);
            _dataContext.SaveChanges();
            return customer;
        }

        public Customer? EditCustomer(Customer customer)
        {
            var customerFound = _dataContext.Customers.SingleOrDefault(c => c.Id == customer.Id);
            if(customerFound != null)
            {
                customerFound = customer;
            }
            _dataContext.SaveChanges();
            return customerFound;
        }

        public Customer? DeleteCustomer(Guid guid)
        {
            var customerFound = _dataContext.Customers.SingleOrDefault(c => c.Id == guid);
            if (customerFound != null)
            {
                _dataContext.Customers.Remove(customerFound);
                _dataContext.SaveChanges();
            }
            return customerFound;
        }

        public IEnumerable<Customer> ReadCustomers(int limit)
        {
            var customers = 
                (from customer in _dataContext.Customers 
                select customer)
                .Take(limit);

            return customers;
        }

        public Customer? GetCustomerByGuid(Guid id)
        {
            var customer = _dataContext.Customers.FirstOrDefault(c => c.Id == id);

            return customer;
        }

        public Customer? GetCustomerByEmail(string email)
        {
            var customer = _dataContext.Customers.FirstOrDefault(c => c.EmailAddress == email);
            return customer;
        }
    }
}
