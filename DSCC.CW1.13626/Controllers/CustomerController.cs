// CustomerController.cs
using Microsoft.AspNetCore.Mvc;
using DSCC.CW1._13626.Repository;
using System.Collections.Generic;
using DSCC.CW1._13626.Model;

namespace DSCC.CW1._13626.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            return Ok(customers);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer cannot be null");
            }

            _customerRepository.InsertCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (customer == null || customer.CustomerId != id)
            {
                return BadRequest("Customer ID mismatch");
            }

            _customerRepository.UpdateCustomer(customer);
            return NoContent();
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            _customerRepository.DeleteCustomer(id);
            return NoContent();
        }
    }
}
