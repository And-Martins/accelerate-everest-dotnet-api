using CustomerRegister.Models;
using CustomerRegister.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegister.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRegister _customer;

        public CustomerController(ICustomerRegister customer)
        {
            _customer = customer ?? throw new ArgumentException(nameof(customer));
        }

        [HttpPost]
        public ActionResult Create([FromBody] CustomerEntity customer)
        {
            var response = _customer.AddCustomer(customer);
            return response
                ? Created("", customer.Id)
                : BadRequest("Email ou CPF já exitem");
        }

        [HttpGet]
        public ActionResult<List<CustomerEntity>> SearchAllCustomers()
        {
            var response = _customer.SearchAllCustomers();
            return response;
        }

        [HttpGet("{id}")]
        public ActionResult SearchCustomerById(int id)
        {
            var response = _customer.SearchCustomerById(id);
            return response is null 
                ? NotFound($"Não foi encontrado usuário com Id : {id}")
                : Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(CustomerEntity selectedCustomer, int id)
        {
            var response = _customer.UpdateCustomer(selectedCustomer, id);
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
            var response = _customer.DeleteCustomer(id);
            return response
                ? Ok()
                : NotFound($"O usuário com id: {id} não foi encontrado");
        }

    }
}
