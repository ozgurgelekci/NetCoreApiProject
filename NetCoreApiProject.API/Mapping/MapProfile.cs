using AutoMapper;
using NetCoreApiProject.API.DTOs.Category;
using NetCoreApiProject.API.DTOs.Product;
using NetCoreApiProject.Core.Entities.Concrete;

namespace NetCoreApiProject.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<CategoryWithProductsDto, Category>();

            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
