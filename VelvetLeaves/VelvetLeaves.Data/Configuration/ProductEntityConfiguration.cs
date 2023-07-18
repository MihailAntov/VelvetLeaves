﻿using Microsoft.EntityFrameworkCore;
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
                new Product {Id = 1, Name = "Red Silver Earings", Description = "Red earings with silver frames.", SubcategoryId = 1, ImageUrl = "jewelry.jpg" }, 
                new Product {Id = 2, Name = "Red-Blue Steel Earings", Description = "Red-blue earings with steel frames.", SubcategoryId = 1,ImageUrl = "jewelry.jpg" }, 
                new Product {Id = 3, Name = "Green Silver Necklace", Description = "Green necklace with a silver frame.", SubcategoryId = 2,ImageUrl = "jewelry.jpg"}, 
                new Product {Id = 4, Name = "Blue Glass Ring", Description = "Blue ring made out of glass and silver.", SubcategoryId = 3,ImageUrl = "jewelry.jpg" }, 
                new Product {Id = 5, Name = "Traditional Hand Bag", Description = "Hand bag with traditional sewing pattern.", SubcategoryId = 4, ImageUrl = "bag.jpg"}, 
                new Product {Id = 6, Name = "Traditional Hand Bag", Description = "Hand bag with traditional sewing pattern.", SubcategoryId = 4, ImageUrl = "bag.jpg"}, 
                new Product {Id = 7, Name = "Blue Book Binding", Description = "Blue book binding with traditional sewing pattern.", SubcategoryId = 5, ImageUrl = "bag.jpg" }, 
            };

            builder.Entity<Color>().HasData(colorList);
            builder.Entity<Material>().HasData(materialList);
            builder.Entity<Product>().HasData(productList);

            builder.Entity<Color>()
                .HasMany(c=> c.Products)
                .WithMany(p=> p.Colors)
                .UsingEntity<Dictionary<string, object>>("ProductsColors",
                r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                    l => l.HasOne<Color>().WithMany().HasForeignKey("ColorId"),
                    mt =>
                    {
                        mt.HasKey("ProductId", "ColorId");
                        mt.HasData(
                            new { ProductId = 1, ColorId = 1 },
                            new { ProductId = 2, ColorId = 1 },
                            new { ProductId = 2, ColorId = 2 },
                            new { ProductId = 3, ColorId = 3 },
                            new { ProductId = 4, ColorId = 2 });
                    });

            builder.Entity<Material>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Materials)
                .UsingEntity<Dictionary<string, object>>("ProductsMaterials",
                r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                    l => l.HasOne<Material>().WithMany().HasForeignKey("MaterialId"),
                    mt =>
                    {
                        mt.HasKey("ProductId", "MaterialId");
                        mt.HasData(
                            new { ProductId = 1, MaterialId = 1 },
                            new { ProductId = 2, MaterialId = 2 },
                            new { ProductId = 3, MaterialId = 1 },
                            new { ProductId = 4, MaterialId = 1 },
                            new { ProductId = 4, MaterialId = 3 },
                            new { ProductId = 5, MaterialId = 4 },
                            new { ProductId = 6, MaterialId = 4 },
                            new { ProductId = 7, MaterialId = 4 });
                    });



        }
    }
}
