using IShopWeb.Domain.Models;
using IShopWeb.Persistence.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopWeb.Persistence.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        public async Task CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProductAsync(Product productDto)
        {
            throw new NotImplementedException();
        }
    }
}
