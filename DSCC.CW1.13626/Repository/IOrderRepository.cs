
using DSCC.CW1._13626.Model;

namespace DSCC.CW1._13626.Repository
        {
            public interface IOrderRepository
            {
            void InsertOrder(Order order);
            void UpdateOrder(Order order);
            void DeleteOrder(int orderId);
            Order GetOrderById(int orderId);
            IEnumerable<Order> GetOrders();
        }
        }
