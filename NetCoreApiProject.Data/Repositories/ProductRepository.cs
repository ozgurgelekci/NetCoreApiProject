using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreApiProject.Core.Entities.Concrete;
using NetCoreApiProject.Core.Repositories;
using NetCoreApiProject.Data.DbContexts;

namespace NetCoreApiProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}
