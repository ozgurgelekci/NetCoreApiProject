using System.ComponentModel.DataAnnotations;

namespace NetCoreApiProject.API.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        public decimal Price { get; set; }
    }
}
