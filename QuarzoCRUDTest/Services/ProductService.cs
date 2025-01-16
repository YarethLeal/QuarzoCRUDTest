using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuarzoCRUDTest.Models;
using QuarzoCRUDTest.Repositories;

namespace QuarzoCRUDTest.Services
{
    public class ProductService
    {
        private readonly ProductRepository productRepository = new ProductRepository();

        public ProductService()
        {
        }

        public IEnumerable<Product> GetProducts(int ?id)
        {
            return productRepository.GetProducts(id);
        }
    }
}