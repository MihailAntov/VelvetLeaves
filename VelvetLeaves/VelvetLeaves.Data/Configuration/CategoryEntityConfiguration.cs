

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //old seed
            //builder.HasData(new List<Category>(){
            //    new Category { Name = "Jewelry", ImageId = "64be89ae1409e5a61554e6ed", Id = 1 },
            //    new Category { Name = "Textile", ImageId = "64be8c9f41c19cda7ab19853", Id = 2},
            //});

            builder.HasData(new List<Category>(){
                new Category { Name = "Текстил", ImageId = "64d52335b30136c5a68bb051", Id = 1 },
                new Category { Name = "Бижута", ImageId = "64d5238d2acacb9e2043c933", Id = 2},
            });
        }
    }
}
