using eCommerce.Catalog.Dtos.ProductImageDtos;
using eCommerce.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Catalog.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase {
        private readonly IProductImageService _ProductImage;

        public ProductImagesController(IProductImageService ProductImage) {
            _ProductImage = ProductImage;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList() {
            var values = await _ProductImage.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id) {
            var values = await _ProductImage.GetProductImageByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto) {
            await _ProductImage.CreateProductImageAsync(createProductImageDto);
            return Ok("Urun gorseli eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto) {
            await _ProductImage.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Urun gorseli guncellendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(string id) {
            await _ProductImage.DeleteProductImageAsync(id);
            return Ok("Urun gorseli silindi!");
        }
    }
}