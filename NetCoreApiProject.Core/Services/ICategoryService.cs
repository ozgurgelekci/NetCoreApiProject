using System.Threading.Tasks;
using NetCoreApiProject.Core.Entities.Concrete;

namespace NetCoreApiProject.Core.Services
{
    // for transactions outside the database

    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByCategoryIdAsync(int categoryId);
    }
}
