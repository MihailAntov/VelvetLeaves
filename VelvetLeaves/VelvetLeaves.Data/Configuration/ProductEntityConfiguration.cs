using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public static class ProductEntityConfiguration 
    {
        public static void SeedColorsAndProducts(this ModelBuilder builder)
        {
            var colorList = new List<Color>
            {
                new Color {Id = 1, ColorValue = "#ff0000", Name = "Red"},
                new Color {Id = 2, ColorValue = "#0000ff", Name = "Blue"},
                new Color {Id = 3, ColorValue = "#00ff00", Name = "Green"}
            };

            var productList = new List<Product> {
                new Product {Id = 1, Name = "Red Silver Earings", Description = "Red earings with silver frames.", SubcategoryId = 1, Colors = new List<Color>{colorList[0]} }, 
                new Product {Id = 2, Name = "Red-Blue Earings", Description = "Red-blue earings with steel frames.", SubcategoryId = 1, Colors = new List<Color>{colorList[0]} }, 
                new Product {Id = 3, Name = "Green Earings", Description = "Green earings with silver frames.", SubcategoryId = 1, Colors = new List<Color>{colorList[0]} }, 
                new Product {Id = 4, Name = "Red Earings", Description = "Red earings with silver frames.", SubcategoryId = 1, Colors = new List<Color>{colorList[0]} }, 
                new Product {Id = 5, Name = "Red Earings", Description = "Red earings with silver frames.", SubcategoryId = 1, Colors = new List<Color>{colorList[0]} }, 
                new Product {Id = 6, Name = "Red Earings", Description = "Red earings with silver frames.", SubcategoryId = 1, Colors = new List<Color>{colorList[0]} }, 
                new Product {Id = 7, Name = "Red Earings", Description = "Red earings with silver frames.", SubcategoryId = 1, Colors = new List<Color>{colorList[0]} }, 
            
            };



            builder.
        }
    }
}
