using System.Threading.Tasks;
using NetCoreApiProject.Core.Entities.Concrete;
using NetCoreApiProject.Core.Repositories;
using NetCoreApiProject.Core.Services;
using NetCoreApiProject.Core.UnitOfWorks;

namespace NetCoreApiProject.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByCategoryIdAsync(int categoryId)
        {
            return await _unitOfWork.Category.GetWithProductsByCategoryIdAsync(categoryId);
        }
    }
}
