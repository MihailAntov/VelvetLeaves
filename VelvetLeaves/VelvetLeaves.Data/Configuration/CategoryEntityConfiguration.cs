

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
                new Category { Name = "Jewelry", ImageUrl = "jewelry.jpg", Id = 1 },
                new Category { Name = "Textile", ImageUrl = "textile.jpg", Id = 2},
            });
        }
    }
}
