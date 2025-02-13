using eCommerce.Catalog.Dtos.ProductImageDtos;

namespace eCommerce.Catalog.Services.ProductImageServices {
    public interface IProductImageService {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string productId);
        Task<GetProductImageByIdDto> GetProductImageByIdAsync(string productId);
    }
}