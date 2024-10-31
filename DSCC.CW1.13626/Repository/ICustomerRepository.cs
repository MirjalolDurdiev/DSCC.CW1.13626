using DSCC.CW1._13626.Model;

namespace DSCC.CW1._13626.Repository
{
    public interface ICustomerRepository
    {
        void InsertCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        Customer GetCustomerById(int customerId);
        IEnumerable<Customer> GetCustomers();
    }
}
