﻿using AutoMapper;
using eCommerce.Catalog.Dtos.ProductDtos;
using eCommerce.Catalog.Entities;
using eCommerce.Catalog.Settings;
using MongoDB.Driver;

namespace eCommerce.Catalog.Services.ProductServices {
    public class ProductService : IProductService {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings) {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto) {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string productId) {
            await _productCollection.DeleteOneAsync(x => x.ProductId == productId);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync() {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetProductByIdDto> GetProductByIdAsync(string productId) {
            var values = await _productCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<GetProductByIdDto>(values);
        }

        public Task UpdateProductAsync(UpdateProductDto updateProductDto) {
            var values = _mapper.Map<Product>(updateProductDto);
            return _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}