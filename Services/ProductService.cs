using MyApiProject.Models;  
using System.Collections.Generic;
using System.Linq;

namespace MyApiProject.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m },
            new Product { Id = 2, Name = "Mouse", Price = 19.99m }
        };

        public List<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1; 
            _products.Add(product);
        }

        public bool Update(int id, Product product)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.Name = product.Name;
            existing.Price = product.Price;
            return true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;
            _products.Remove(product);
            return true;
        }
    }
}
