﻿using eCommerce.Catalog.Dtos.ProductDtos;
using eCommerce.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Catalog.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList() {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id) {
            var values = await _productService.GetProductByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto) {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Urun eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto) {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Urun guncellendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id) {
            await _productService.DeleteProductAsync(id);
            return Ok("Urun silindi!");
        }
    }
}