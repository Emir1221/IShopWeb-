using IShopWeb.Application.Dto;
using IShopWeb.Application.Services.Interfaces;
using IShopWeb.Persistence.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShopWeb.Application.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProductAsync(ProductDto productDto)
        {
            //TODO Mapping
            _productRepository.CreateProductAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            _productRepository.DeleteProductAsync(id);
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync();
        }

        public async Task UpdateProductAsync(ProductDto productDto)
        {
            await _productRepository.UpdateProductAsync();
        }
    }
}
