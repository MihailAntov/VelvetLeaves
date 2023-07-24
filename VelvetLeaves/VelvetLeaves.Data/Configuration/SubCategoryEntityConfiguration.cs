

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public class SubCategoryEntityConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.HasData(new List<Subcategory>()
            {
                {new Subcategory {Name = "Earings",Id = 1, CategoryId = 1, ImageId = "64be89ae1409e5a61554e6ed"} },
                {new Subcategory {Name = "Necklaces",Id = 2, CategoryId = 1, ImageId = "64be8c870b7f086367ebb6a5"} },
                {new Subcategory {Name = "Rings",Id = 3, CategoryId = 1, ImageId = "64be8c9332b088f8d6063040"} },
                {new Subcategory {Name = "Bags",Id = 4, CategoryId = 2, ImageId = "64be8ca5b7f1ea12383c364a"} },
                {new Subcategory {Name = "Book Bindings",Id = 5, CategoryId = 2, ImageId = "64be8cb3b390e17c62039322"} }
            });
        }
    }
}
