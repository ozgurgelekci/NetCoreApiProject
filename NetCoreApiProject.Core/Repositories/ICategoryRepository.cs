using System.Threading.Tasks;
using NetCoreApiProject.Core.Entities.Concrete;

namespace NetCoreApiProject.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductsByCategoryIdAsync(int categoryId);
    }
}
