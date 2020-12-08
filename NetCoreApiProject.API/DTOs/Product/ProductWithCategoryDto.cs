using NetCoreApiProject.API.DTOs.Category;

namespace NetCoreApiProject.API.DTOs.Product
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
