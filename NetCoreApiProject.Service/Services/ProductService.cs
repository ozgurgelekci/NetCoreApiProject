using System.Threading.Tasks;
using NetCoreApiProject.Core.Entities.Concrete;
using NetCoreApiProject.Core.Repositories;
using NetCoreApiProject.Core.Services;
using NetCoreApiProject.Core.UnitOfWorks;

namespace NetCoreApiProject.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return _unitOfWork.Product.GetWithCategoryByIdAsync(productId);
        }
    }
}
