using AutoMapper;
using eCommerce.Catalog.Dtos.ProductImageDtos;
using eCommerce.Catalog.Entities;
using eCommerce.Catalog.Settings;
using MongoDB.Driver;

namespace eCommerce.Catalog.Services.ProductImageServices {
    public class ProductImageService : IProductImageService {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings) {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto) {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string productImageId) {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == productImageId);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync() {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetProductImageByIdDto> GetProductImageByIdAsync(string productImageId) {
            var values = await _productImageCollection.Find(x => x.ProductImageId == productImageId).FirstOrDefaultAsync();
            return _mapper.Map<GetProductImageByIdDto>(values);
        }

        public Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto) {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            return _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, values);
        }
    }
}