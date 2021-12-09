using IShopWeb.Domain.Models;
using IShopWeb.Persistence.Data;
using IShopWeb.Persistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShopWeb.Persistence.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext; //TODO нормально ли так делать или создать интерфейс

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            _appDbContext.Products.Remove(product); //TODO можно сделать так чтоб удалить одним запросом и не искать из бд по id
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _appDbContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _appDbContext.Products.Update(product);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
