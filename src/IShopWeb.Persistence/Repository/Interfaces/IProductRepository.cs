using IShopWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShopWeb.Persistence.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();

        Task<Product> GetProductByIdAsync(int id);

        Task CreateProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(int id);
    }
}
