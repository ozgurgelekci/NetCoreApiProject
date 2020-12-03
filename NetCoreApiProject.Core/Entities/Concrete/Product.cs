using NetCoreApiProject.Core.Entities.Abstract;

namespace NetCoreApiProject.Core.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; }
        public decimal Price { get; set; }

        public virtual Category Category { get; set; }
    }
}
