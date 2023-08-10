

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            //old seed
            //var colorList = new List<Color>
            //{
            //    new Color {Id = 1, ColorValue = "#ff0000", Name = "Red"},
            //    new Color {Id = 2, ColorValue = "#0000ff", Name = "Blue"},
            //    new Color {Id = 3, ColorValue = "#00ff00", Name = "Green"}
            //};

            var colorList = new List<Color>
            {
                new Color {Id = 1,  ColorValue = "#d0c442", Name = "жълто"},
                new Color {Id = 2,  ColorValue = "#147b83", Name = "тюркоаз"},
                new Color {Id = 3,  ColorValue = "#d03844", Name = "червено"},
                new Color {Id = 4,  ColorValue = "#87cc4a", Name = "светло зелено"},
                new Color {Id = 5,  ColorValue = "#46761b", Name = "тъмно зелено"},
                new Color {Id = 6,  ColorValue = "#721cae", Name = "лилаво"},
                new Color {Id = 7,  ColorValue = "#154978", Name = "тъмно синьо"},
                new Color {Id = 8,  ColorValue = "#34b4df", Name = "светло синьо"},
                new Color {Id = 9,  ColorValue = "#e6c89f", Name = "шампанско"},
                new Color {Id = 10, ColorValue = "#d8748c", Name = "розово"},
                new Color {Id = 11, ColorValue = "#f0eddc", Name = "бяло"},
                new Color {Id = 12, ColorValue = "#961243", Name = "циклама"},
                new Color {Id = 13, ColorValue = "#904236", Name = "кафяво"},
                new Color {Id = 14, ColorValue = "#000000", Name = "черно"},
                new Color {Id = 15, ColorValue = "#fe7612", Name = "оранжево"},
            };

            builder.HasData(colorList);
        }
    }
}
