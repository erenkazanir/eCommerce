using AutoMapper;
using eCommerce.Catalog.Dtos.CategoryDtos;
using eCommerce.Catalog.Dtos.ProductDetailDtos;
using eCommerce.Catalog.Dtos.ProductDtos;
using eCommerce.Catalog.Dtos.ProductImageDtos;
using eCommerce.Catalog.Entities;

namespace eCommerce.Catalog.Mapping {
    public class GeneralMapping : Profile {
        public GeneralMapping() {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, GetProductByIdDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetProductDetailByIdDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetProductImageByIdDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
        }
    }
}
