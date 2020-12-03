using System;
using System.Threading.Tasks;
using NetCoreApiProject.Core.Repositories;
using NetCoreApiProject.Core.UnitOfWorks;
using NetCoreApiProject.Data.DbContexts;
using NetCoreApiProject.Data.Repositories;

namespace NetCoreApiProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;


        public IProductRepository Product => _productRepository ??= new ProductRepository(_context);

        public ICategoryRepository Category => _categoryRepository ??= new CategoryRepository(_context);

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
