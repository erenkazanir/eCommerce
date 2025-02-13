using eCommerce.Catalog.Dtos.ProductDetailDtos;
using eCommerce.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Catalog.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase {
        private readonly IProductDetailService _productDetail;

        public ProductDetailsController(IProductDetailService productDetail) {
            _productDetail = productDetail;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList() {
            var values = await _productDetail.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id) {
            var values = await _productDetail.GetProductDetailByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto) {
            await _productDetail.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Urun detay eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto) {
            await _productDetail.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Urun detay guncellendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id) {
            await _productDetail.DeleteProductDetailAsync(id);
            return Ok("Urun detay silindi!");
        }
    }
}