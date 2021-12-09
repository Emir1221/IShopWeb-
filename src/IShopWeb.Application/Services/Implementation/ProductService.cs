using IShopWeb.Application.Dto;
using IShopWeb.Application.Services.Interfaces;
using IShopWeb.Domain.Models;
using IShopWeb.Persistence.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
            var product = new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name
            };

            await _productRepository.CreateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {


            var products = await _productRepository.GetAllProductsAsync();

            return products.Select(x => new ProductDto { Id = x.Id, Name = x.Name }).ToList();
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return new ProductDto { Id = product.Id, Name = product.Name };

        }

        public async Task UpdateProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name
            };
            await _productRepository.UpdateProductAsync(product);
        }
    }
}
