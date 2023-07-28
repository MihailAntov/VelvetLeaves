

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            var colorList = new List<Color>
            {
                new Color {Id = 1, ColorValue = "#ff0000", Name = "Red"},
                new Color {Id = 2, ColorValue = "#0000ff", Name = "Blue"},
                new Color {Id = 3, ColorValue = "#00ff00", Name = "Green"}
            };

            builder.HasData(colorList);
        }
    }
}
