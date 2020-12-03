using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreApiProject.Core.Entities.Concrete;

namespace NetCoreApiProject.Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _ids;

        public CategorySeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = _ids[0], Name = "Kalem" }
            );

            builder.HasData(
                new Category { Id = _ids[1], Name = "Defter" }
            );
        }
    }
}
