using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("GetCustomer")]
        public List<Customer> Get()
        {
            var services = new CustomerService();
            var customer = services.GetAll();
            return customer;
        }

        [HttpGet("{customerId}", Name = "CustomerDetails")]
        public Customer? Get(int customerId)
        {
            var services = new CustomerService();
            var customer = services.GetDetails(customerId);
            return customer;
        }

    }
}
