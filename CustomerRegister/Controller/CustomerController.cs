using AppServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomerRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService appService)
        {
            _customerAppService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        [HttpPost]
        public IActionResult Create(CustomerEntity customer)
        {
            try
            {
                var customerId = _customerAppService.Add(customer);
                return Created("Id: ", customerId);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var listCustomers = _customerAppService.GetAllCustomers();
                return Ok(listCustomers);
            }
            catch (Exception ex)
            {
                var exMessage = ex.InnerException?.Message ?? ex.Message;
                return Problem(exMessage);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(long id)
        {
            try
            {
                return Ok(_customerAppService.GetCustomerById(id));
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateCustomer(CustomerEntity selectedCustomer)
        {
            try
            {
                _customerAppService.Update(selectedCustomer);
                return Ok();
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                _customerAppService.Delete(id);
                return NoContent();
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
