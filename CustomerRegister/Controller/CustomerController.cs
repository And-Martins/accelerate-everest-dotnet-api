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
            catch (ArgumentException ex)
            {
                var exMessage = ex.InnerException?.Message ?? ex.Message;
                return BadRequest(exMessage);
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
            catch (ArgumentNullException ex)
            {
                var exMessage = ex.InnerException?.Message ?? ex.Message;
                return NotFound(exMessage);
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
                var eMessage = e.InnerException?.Message ?? e.Message;
                return NotFound(e.Message);
            }
            catch (ArgumentException ex)
            {
                var exMessage = ex.InnerException?.Message ?? ex.Message;
                return BadRequest(exMessage);
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
            catch (ArgumentNullException ex)
            {
                var exMessage = ex.InnerException?.Message ?? ex.Message;
                return NotFound(exMessage);
            }
        }
    }
}
