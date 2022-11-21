using CustomerRegister.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System;

namespace CustomerRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customer)
        {
            _customerService = customer ?? throw new ArgumentException(nameof(customer));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerEntity customer)
        {
            try
            {
                _customerService.Add(customer);
                return Created("", customer.Id);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var response = _customerService.GetAllCustomers();
                return Ok(response);
            } catch (ArgumentException)
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                return Ok(_customerService.GetCustomerById(id));
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateCustomer(CustomerEntity selectedCustomer)
        {
            try
            {
                _customerService.Update(selectedCustomer);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _customerService.Delete(id);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }          
        }
    }
}
