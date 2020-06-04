using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;

namespace Module1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        static List<Customer> _customer = new List<Customer>()
        {
            new Customer{ Id=0, Name="Aritra", Email="aritra.ghosh@gmail.com", Phone="9836783364"},
            new Customer{ Id=1, Name="Tome", Email="tom.cat@apache.com", Phone="5512081655"},
        };
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customer;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (ModelState.IsValid) 
            {
                _customer.Add(customer);
                return Ok();
            }
            return BadRequest(ModelState); 
        }
    }
}
