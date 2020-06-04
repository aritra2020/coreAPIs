using Module1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module1.Controllers;
using Module1.Data;

namespace Module1.Services
{
    public class ProductRepository : IProduct
    {
        private ProductsDbContext productsDbContext;
        public ProductRepository(ProductsDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }
        public void AddProduct(Product product)
        {
            productsDbContext.Products.Add(product);
            productsDbContext.SaveChanges(true);
        }

        public void DeleteProduct(int id)
        {
            //var product = productsDbContext.Products.SingleOrDefault(m => m.ProductId == id);
            var product = productsDbContext.Products.Find(id);
            //if (product != null)
            productsDbContext.Products.Remove(product);
            productsDbContext.SaveChanges(true);
        }
        
        public Product GetProduct(int id)
        {
            var product = productsDbContext.Products.SingleOrDefault(m => m.ProductId == id);

            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productsDbContext.Products;
        }

        public IEnumerable<Product> searchProducts(string searchProduct)
        {
            var products = productsDbContext.Products.Where(a => a.ProductName.StartsWith(searchProduct));

            return products;
        }

        public void UpdateProduct(Product product)
        {
            productsDbContext.Products.Update(product);
            productsDbContext.SaveChanges(true);
        }
    }
}
