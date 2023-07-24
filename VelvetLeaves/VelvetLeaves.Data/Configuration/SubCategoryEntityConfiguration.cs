

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
                {new Subcategory {Name = "Earings",Id = 1, CategoryId = 1, ImageId = "jewelry.jpg"} },
                {new Subcategory {Name = "Necklaces",Id = 2, CategoryId = 1, ImageId = "jewelry.jpg"} },
                {new Subcategory {Name = "Rings",Id = 3, CategoryId = 1, ImageId = "jewelry.jpg"} },
                {new Subcategory {Name = "Bags",Id = 4, CategoryId = 2, ImageId = "bag.jpg"} },
                {new Subcategory {Name = "Book Bindings",Id = 5, CategoryId = 2, ImageId = "bag.jpg"} }
            });
        }
    }
}
