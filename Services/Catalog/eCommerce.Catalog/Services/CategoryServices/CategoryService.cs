﻿using AutoMapper;
using eCommerce.Catalog.Dtos.CategoryDtos;
using eCommerce.Catalog.Entities;
using eCommerce.Catalog.Settings;
using MongoDB.Driver;

namespace eCommerce.Catalog.Services.CategoryServices {
    public class CategoryService : ICategoryService {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings) {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto) {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string categoryId) {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == categoryId);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync() {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetCategoryByIdDto> GetCategoryByIdAsync(string categoryId) {
            var values = await _categoryCollection.Find(x => x.CategoryId == categoryId).FirstOrDefaultAsync();
            return _mapper.Map<GetCategoryByIdDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto) {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, values);
        }
    }
}