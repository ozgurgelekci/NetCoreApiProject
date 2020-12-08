using AutoMapper;
using NetCoreApiProject.API.DTOs;
using NetCoreApiProject.Core.Entities.Concrete;

namespace NetCoreApiProject.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
