using CustomerRegister.Models;
using CustomerRegister.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;

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
                _customerService.AddCustomer(customer);
                return Created("", customer.Id);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public IActionResult SearchAllCustomers()
        {
            var response = _customerService.SearchAllCustomers();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult SearchCustomerById(int id)
        {
            try
            {
                return Ok(_customerService.SearchCustomerById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(CustomerEntity selectedCustomer, int id)
        {
            try
            {
                _customerService.UpdateCustomer(selectedCustomer, id);
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
                _customerService.DeleteCustomer(id);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }          
        }
    }
}
