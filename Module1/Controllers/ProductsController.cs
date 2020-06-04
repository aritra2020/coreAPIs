using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;

namespace Module1.Controllers
{
    [ApiVersion("1.0")]
    //[Route("api/[controller]")]
    //[Route("api/Products")]
    [Route("api/v{version:apiVersion}/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
         static List<Product> _products = new List<Product>()
        {
            new Product{ ProductId=0, ProductName="Laptop", ProductPrice=40000.00m},
            new Product{ ProductId=0, ProductName="Smartphone", ProductPrice=20000.00m},
        };

        //public IEnumerable<Product> Get()
        //{
        //    return _products;
        //}
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_products);
        }
        [HttpGet("LoadWelcomeMessage")]
        public IActionResult GetWelcomeMessage()
        {
            return Ok("Welcome to our Store..");
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {
            _products.Add(product);
        }

        [HttpPut("{id}")]      
        public void Put(int id,[FromBody] Product product)
        {
            _products[id] = product;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _products.RemoveAt(id);
        }


    }
}
