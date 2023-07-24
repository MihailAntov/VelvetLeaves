﻿

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new List<Category>(){
                new Category { Name = "Jewelry", ImageId = "64be89ae1409e5a61554e6ed", Id = 1 },
                new Category { Name = "Textile", ImageId = "64be8c9f41c19cda7ab19853", Id = 2},
            });
        }
    }
}
