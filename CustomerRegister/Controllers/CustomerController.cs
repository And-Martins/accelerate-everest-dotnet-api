using CustomerRegister.Models;
using CustomerRegister.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var response = _customerService.AddCustomer(customer);
            return response
                ? Created("", customer.Id)
                : BadRequest("Email ou CPF já exitem");
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
            var response = _customerService.SearchCustomerById(id);
            return response is null 
                ? NotFound($"Não foi encontrado usuário com Id : {id}")
                : Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(CustomerEntity selectedCustomer, int id)
        {
            var response = _customerService.UpdateCustomer(selectedCustomer, id);
            if(response > 1)
            {
                return Ok();
            }
            else if (response == 0)
            {
                return BadRequest("Email e CPF já existem na nossa base de dados.");
            }
            return NotFound($"Não foi encontrado nenhum registro com este CPF: {selectedCustomer.Cpf}");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var response = _customerService.DeleteCustomer(id);
            return response
                ? Ok()
                : NotFound($"O usuário com id: {id} não foi encontrado");
        }
    }
}
