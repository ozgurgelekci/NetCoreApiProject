using System;
using System.Threading.Tasks;
using NetCoreApiProject.Core.Repositories;
using NetCoreApiProject.Core.UnitOfWorks;

namespace NetCoreApiProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository Product { get; }
        public ICategoryRepository Category { get; }
        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
