using CustomerRegister.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<CustomerEntity>> SearchAllCustomers()
        {
            return Ok();
        }
    }
}
