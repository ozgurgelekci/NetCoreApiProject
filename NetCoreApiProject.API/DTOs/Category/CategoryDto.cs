using System.ComponentModel.DataAnnotations;

namespace NetCoreApiProject.API.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        public string Name { get; set; }
    }
}
