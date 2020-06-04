using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Data;
using Module1.Models;
using Module1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Module1.Controllers
{
    [ApiVersion("2.0")]
    //[Route("api/[controller]")]
    //[Route("api/Products")]
    [Route("api/v{version:apiVersion}/Products")]
    [ApiController]
    public class ProductsDbController : ControllerBase
    {
        //private ProductsDbContext productsDbContext;

        //public ProductsDbController(ProductsDbContext _productsDbContext)
        //{
        //    productsDbContext = _productsDbContext;
        //}
        private IProduct productRepository;
        public ProductsDbController(IProduct _productRepository)
        {
            productRepository = _productRepository;
        }
        // GET: api/<ProductsDbController>
        //[HttpGet]
        //public IEnumerable<Product> Get()
        //{
        //    return productRepository.GetProducts();
        //}
        //public IEnumerable<Product> Get(string sortPrice)
        //{
        //    IQueryable<Product> products;
        //    switch (sortPrice)
        //    {
        //        case "desc":
        //            products = productsDbContext.Products.OrderByDescending(n => n.ProductPrice);
        //            break;
        //        case "asc":
        //            products = productsDbContext.Products.OrderBy(n => n.ProductPrice);
        //            break;
        //        default:
        //            products = productsDbContext.Products;
        //            break;
        //    }
        //    return products;
        //}       
        //public IEnumerable<Product> Get(int? pageNumber, int? pageSize)
        //{
        //    var products = from p in productsDbContext.Products.OrderBy(a => a.ProductId) select p;
        //    int currentPage = pageNumber ?? 1;
        //    int currentPagesize = pageSize ?? 10;

        //    var items = products.Skip((currentPage-1)* currentPagesize).Take(currentPagesize).ToList();
        //    return items;
        //}

        [HttpGet]        
        public IEnumerable<Product> Get(string searchProduct)
        {
            if (searchProduct is null)
            {
                return productRepository.GetProducts();
            }

            return productRepository.searchProducts(searchProduct);
        }
        // GET api/<ProductsDbController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound("No Records found.");
            }
            return Ok(product);
        }

        // POST api/<ProductsDbController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            productRepository.AddProduct(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ProductsDbController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != product.ProductId)
            {
                return BadRequest("Id mismatch for Product..");
            }
            try
            {
                productRepository.UpdateProduct(product);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound("No records found against this id..");
            }
            
            return Ok("product is updated successfully..");
        }

        // DELETE api/<ProductsDbController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productRepository.DeleteProduct(id);
            //if (product == null)
            //{
            //    return NotFound("No Records found.");
            //}            
            
            return Ok("Product deleted..");
        }
    }
}
