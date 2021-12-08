using IShopWeb.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShopWeb.Application.Services.Interfaces
{
    public interface IProductService
    {

        Task<List<ProductDto>> GetAllProductsAsync();

        Task<ProductDto> GetProductByIdAsync(int id);

        Task CreateProductAsync(ProductDto productDto);

        Task UpdateProductAsync(ProductDto productDto);

        Task DeleteProductAsync(int id);

    }
}
