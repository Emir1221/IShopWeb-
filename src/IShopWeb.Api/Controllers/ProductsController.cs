using IShopWeb.Application.Dto;
using IShopWeb.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            return await _productService.GetAllProductsAsync();
        }

        [HttpPost]
        public async Task CreateProductAsync(ProductDto productDto)
        {
            await _productService.CreateProductAsync(productDto);
        }

        [HttpPut]
        public async Task UpdateProductAsync(ProductDto productDto)
        {
            await _productService.UpdateProductAsync(productDto);
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProductAsync(int id)
        {
            await _productService.DeleteProductAsync(id);
        }

    }
}
