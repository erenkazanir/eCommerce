using eCommerce.Catalog.Dtos.ProductDtos;

namespace eCommerce.Catalog.Services.ProductServices {
    public interface IProductService {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string productId);
        Task<GetProductByIdDto> GetProductByIdAsync(string productId);
    }
}