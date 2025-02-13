using eCommerce.Catalog.Dtos.ProductDetailDtos;

namespace eCommerce.Catalog.Services.ProductDetailServices {
    public interface IProductDetailService {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string productId);
        Task<GetProductDetailByIdDto> GetProductDetailByIdAsync(string productId);
    }
}
