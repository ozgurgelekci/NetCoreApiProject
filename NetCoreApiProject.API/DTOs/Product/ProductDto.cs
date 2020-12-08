using System.ComponentModel.DataAnnotations;

namespace NetCoreApiProject.API.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        public string Name { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
    }
}
