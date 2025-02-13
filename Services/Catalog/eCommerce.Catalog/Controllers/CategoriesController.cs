using eCommerce.Catalog.Dtos.CategoryDtos;
using eCommerce.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Catalog.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList() {
            var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id) {
            var values = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto) {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto) {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori guncellendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id) {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori silindi!");
        }
    }
}
