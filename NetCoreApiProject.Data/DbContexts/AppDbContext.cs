using Microsoft.EntityFrameworkCore;
using NetCoreApiProject.Core.Entities.Concrete;

namespace NetCoreApiProject.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        private DbSet<Category> Categories { get; set; }

        private DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
