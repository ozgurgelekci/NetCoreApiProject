using System.Collections.Generic;
using System.Collections.ObjectModel;
using NetCoreApiProject.Core.Entities.Abstract;

namespace NetCoreApiProject.Core.Entities.Concrete
{
    public class Category : IEntity
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
