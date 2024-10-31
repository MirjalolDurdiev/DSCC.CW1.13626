using Microsoft.AspNetCore.Mvc;
using DSCC.CW1._13626.Repository;
using DSCC.CW1._13626.Model;
using System.Collections.Generic;

namespace DSCC.CW1._13626.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/Order
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            var orders = _orderRepository.GetOrders();
            return Ok(orders);
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order cannot be null");
            }

           
            _orderRepository.InsertOrder(order);

          
            var createdOrder = _orderRepository.GetOrderById(order.OrderId);

            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrderId }, createdOrder);
        }


        // PUT: api/Order/5
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, [FromBody] Order order)
        {
            if (order == null || order.OrderId != id)
            {
                return BadRequest("Order ID mismatch");
            }

            _orderRepository.UpdateOrder(order);
            return NoContent();
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            _orderRepository.DeleteOrder(id);
            return NoContent();
        }
    }
}
