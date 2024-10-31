using DSCC.CW1._13626.DbContexts;
using DSCC.CW1._13626.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DSCC.CW1._13626.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteOrder(int orderId)
        {
            var order = _dbContext.Orders.Find(orderId);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                Save();
            }
        }

        public Order GetOrderById(int orderId)
        {
            var order = _dbContext.Orders
                .Include(o => o.Customer)
                .ThenInclude(c => c.Orders)
                .FirstOrDefault(o => o.OrderId == orderId);

            return order;
        }


        public IEnumerable<Order> GetOrders()
        {
            return _dbContext.Orders
                .Include(o => o.Customer) 
                .Include(o => o.Customer.Orders) 
                .ToList();
        }

        public void InsertOrder(Order order)
        {
            _dbContext.Add(order);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            Save();
        }

       
        public Order GetOrder()
        {
            return _dbContext.Orders.FirstOrDefault();
        }
    }
}
