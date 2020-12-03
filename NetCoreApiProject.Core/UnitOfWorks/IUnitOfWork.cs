using System.Threading.Tasks;
using NetCoreApiProject.Core.Repositories;

namespace NetCoreApiProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }

        Task CommitAsync();
        void Commit();
    }
}
