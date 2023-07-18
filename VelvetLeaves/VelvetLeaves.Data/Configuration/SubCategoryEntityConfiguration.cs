

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
                {new Subcategory {Name = "Silver",Id = 1, CategoryId = 1, ImageUrl = "jewelry.jpg"} },
                {new Subcategory {Name = "Steel",Id = 2, CategoryId = 1, ImageUrl = "jewelry.jpg"} },
                {new Subcategory {Name = "Clay",Id = 3, CategoryId = 1, ImageUrl = "jewelry.jpg"} },
                {new Subcategory {Name = "Hand Bags",Id = 4, CategoryId = 2, ImageUrl = "bag.jpg"} },
                {new Subcategory {Name = "Small Bags",Id = 5, CategoryId = 2, ImageUrl = "bag.jpg"} }
            });
        }
    }
}
