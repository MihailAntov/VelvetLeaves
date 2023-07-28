

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public class MaterialEntityConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            var materialList = new List<Material>
            {
                new Material {Id = 1, Name = "Silver"},
                new Material {Id = 2, Name = "Steel"},
                new Material {Id = 3, Name = "Glass"},
                new Material {Id = 4, Name = "Textile"}
            };
            builder.HasData(materialList);
        }
    }
}
