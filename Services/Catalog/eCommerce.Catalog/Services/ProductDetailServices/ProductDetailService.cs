using AutoMapper;
using eCommerce.Catalog.Dtos.ProductDetailDtos;
using eCommerce.Catalog.Entities;
using eCommerce.Catalog.Settings;
using MongoDB.Driver;

namespace eCommerce.Catalog.Services.ProductDetailServices {
    public class ProductDetailService : IProductDetailService {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings) {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto) {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string productDetailId) {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == productDetailId);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync() {
            var values = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailByIdAsync(string productDetailId) {
            var values = await _productDetailCollection.Find(x => x.ProductDetailId == productDetailId).FirstOrDefaultAsync();
            return _mapper.Map<GetProductDetailByIdDto>(values);
        }

        public Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto) {
            var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
            return _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, values);
        }
    }
}