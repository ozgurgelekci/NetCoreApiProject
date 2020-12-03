using Microsoft.EntityFrameworkCore;
using NetCoreApiProject.Core.Entities.Concrete;
using NetCoreApiProject.Data.EntityConfiguration;

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
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
