using System.Threading.Tasks;
using NetCoreApiProject.Core.Entities.Concrete;

namespace NetCoreApiProject.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
