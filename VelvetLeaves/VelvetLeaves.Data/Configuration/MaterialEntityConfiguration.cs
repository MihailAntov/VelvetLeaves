

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
                //old seed
                //new Material {Id = 1, Name = "Silver"},
                //new Material {Id = 2, Name = "Steel"},
                //new Material {Id = 3, Name = "Glass"},
                //new Material {Id = 4, Name = "Textile"}


                new Material {Id = 1, Name = "Лен"},
                new Material {Id = 2, Name = "Памук"},
                new Material {Id = 3, Name = "Стомана"},
                new Material {Id = 4, Name = "Сребро"},
                new Material {Id = 5, Name = "Полускъпоценни камъни"},
                new Material {Id = 6, Name = "Кристали Сваровски"},
                new Material {Id = 8, Name = "Естествени копринени пашкули"},
                new Material {Id = 9, Name = "Посребрена тел"},
                new Material {Id = 10, Name = "Кожа"},
                new Material {Id = 11, Name = "Стоманена магнитна закопчалка"},
                new Material {Id = 12, Name = "Велур"},
                new Material {Id = 13, Name = "Дърво"},
                new Material {Id = 14, Name = "Речни перли"}
                

            };
            builder.HasData(materialList);
        }
    }
}
