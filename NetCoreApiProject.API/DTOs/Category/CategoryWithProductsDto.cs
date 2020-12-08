using System.Collections.Generic;
using NetCoreApiProject.API.DTOs.Product;

namespace NetCoreApiProject.API.DTOs.Category
{
    public class CategoryWithProductsDto:CategoryDto
    {
        public ICollection<ProductDto> Products{ get; set; }
    }
}
