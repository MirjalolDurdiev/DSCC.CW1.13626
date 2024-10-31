// CustomerRepository.cs
using DSCC.CW1._13626.DbContexts;
using DSCC.CW1._13626.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DSCC.CW1._13626.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrderDbContext _dbContext;

        public CustomerRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _dbContext.Customer.Find(customerId);
            if (customer != null)
            {
                _dbContext.Customer.Remove(customer);
                Save();
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            return _dbContext.Customer.Find(customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customer.ToList();
        }

        public void InsertCustomer(Customer customer)
        {
            _dbContext.Customer.Add(customer);
            Save();
        }

        public void UpdateCustomer(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
