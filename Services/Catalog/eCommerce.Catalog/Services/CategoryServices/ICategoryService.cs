using eCommerce.Catalog.Dtos.CategoryDtos;

namespace eCommerce.Catalog.Services.CategoryServices {
    public interface ICategoryService {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string categoryId);
        Task<GetCategoryByIdDto> GetCategoryByIdAsync(string categoryId);
    }
}