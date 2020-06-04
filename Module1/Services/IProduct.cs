using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module1.Models;

namespace Module1.Services
{
    public interface IProduct
    {
        // CRUD Operations
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        IEnumerable<Product> searchProducts(string searchProduct);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
