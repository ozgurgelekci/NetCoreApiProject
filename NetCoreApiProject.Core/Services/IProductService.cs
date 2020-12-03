using System.Threading.Tasks;
using NetCoreApiProject.Core.Entities.Concrete;

namespace NetCoreApiProject.Core.Services
{
    // for transactions outside the database
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
