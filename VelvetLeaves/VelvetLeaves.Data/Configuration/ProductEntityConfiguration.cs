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

            var materialList = new List<Material>
            {
                new Material {Id = 1, Name = "Silver"},
                new Material {Id = 2, Name = "Steel"},
                new Material {Id = 3, Name = "Glass"},
                new Material {Id = 4, Name = "Textile"}
            };

            var productList = new List<Product> {
                new Product {Id = 1, Name = "Red Silver Earings", Description = "Red earings with silver frames.", SubcategoryId = 1, Colors = new List<Color>{colorList[0]}, Materials = new List<Material> {materialList[0] } }, 
                new Product {Id = 2, Name = "Red-Blue Steel Earings", Description = "Red-blue earings with steel frames.", SubcategoryId = 1, Colors = new List<Color>{colorList[0], colorList[1] }, Materials = new List<Material> {materialList[1] } }, 
                new Product {Id = 3, Name = "Green Silver Necklace", Description = "Green necklace with a silver frame.", SubcategoryId = 2, Colors = new List<Color>{colorList[2]}, Materials = new List<Material> {materialList[0] } }, 
                new Product {Id = 4, Name = "Blue Glass Ring", Description = "Blue ring made out of glass and silver.", SubcategoryId = 3, Colors = new List<Color>{colorList[1]}, Materials = new List<Material> {materialList[0], materialList[2] } }, 
                new Product {Id = 5, Name = "Traditional Hand Bag", Description = "Hand bag with traditional sewing pattern.", SubcategoryId = 4, Materials = new List<Material> {materialList[3] } }, 
                new Product {Id = 6, Name = "Traditional Hand Bag", Description = "Hand bag with traditional sewing pattern.", SubcategoryId = 4, Materials = new List<Material> {materialList[3] } }, 
                new Product {Id = 7, Name = "Blue Book Binding", Description = "Blue book binding with traditional sewing pattern.", SubcategoryId = 5, Materials = new List<Material> {materialList[3] } }, 
            };



            builder.Entity<Color>().HasData(colorList);
            builder.Entity<Material>().HasData(materialList);
            builder.Entity<Product>().HasData(productList);
        }
    }
}
