using System.ComponentModel.DataAnnotations;

namespace NetCoreApiProject.API.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
