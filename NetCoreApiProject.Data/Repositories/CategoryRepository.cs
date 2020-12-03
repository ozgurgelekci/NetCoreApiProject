using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreApiProject.Core.Entities.Concrete;
using NetCoreApiProject.Core.Repositories;
using NetCoreApiProject.Data.DbContexts;

namespace NetCoreApiProject.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByCategoryIdAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Products)
                .SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
