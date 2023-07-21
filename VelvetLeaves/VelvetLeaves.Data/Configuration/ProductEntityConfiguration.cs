using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public static class ProductEntityConfiguration 
    {
        public static void SeedColorsAndProducts(this ModelBuilder builder)
        {
            var colorList = new List<Color>
            {
                new Color {Id = 1, ColorValue = "ff0000", Name = "Red"},
                new Color {Id = 2, ColorValue = "0000ff", Name = "Blue"},
                new Color {Id = 3, ColorValue = "00ff00", Name = "Green"}
            };

            var materialList = new List<Material>
            {
                new Material {Id = 1, Name = "Silver"},
                new Material {Id = 2, Name = "Steel"},
                new Material {Id = 3, Name = "Glass"},
                new Material {Id = 4, Name = "Textile"}
            };

            var tagList = new List<Tag>
            {
                new Tag {Id = 1, Name = "Traditional Sewing Pattern"},
                new Tag {Id = 2, Name = "Silk Cocoons"}
            };

            var productSeriesList = new List<ProductSeries>
            {
                new ProductSeries{Id = 1, Name = "Silver Earrings", SubcategoryId = 1, DefaultName="Silver Earrings", DefaultDescription = "Earrings with silver frames.", DefaultPrice = 50.00M},
                new ProductSeries{Id = 2, Name = "Steel Earrings", SubcategoryId = 1, DefaultName="Steel Earrings", DefaultDescription = "Earrings with steel frames.", DefaultPrice = 50.00M},
                new ProductSeries{Id = 3, Name = "Silver Necklace", SubcategoryId = 2, DefaultName="Silver Necklace", DefaultDescription = "Necklace with a silver frame.", DefaultPrice = 50.00M},
                new ProductSeries{Id = 4, Name = "Glass Ring", SubcategoryId = 3, DefaultName="Glass Ring", DefaultDescription = "Ring made out of glass and silver.", DefaultPrice = 50.00M},
                new ProductSeries{Id = 5, Name = "Traditional Bag", SubcategoryId = 4, DefaultName="Traditional Bag", DefaultDescription = "Hand bag with traditional sewing pattern.", DefaultPrice = 50.00M},
                new ProductSeries{Id = 6, Name = "Book Binding", SubcategoryId = 5, DefaultName="Book Binding", DefaultDescription = "Book binding.", DefaultPrice = 50.00M},
            };

            var imageList = new List<Image>
            {
                new Image {Id = 1, Url = "jewelry.jpg" , ProductId = 1},
                new Image {Id = 2, Url = "jewelry.jpg" , ProductId = 1},
                new Image {Id = 3, Url = "jewelry.jpg" , ProductId = 1},
                new Image {Id = 4, Url = "jewelry.jpg" , ProductId = 2},
                new Image {Id = 5, Url = "jewelry.jpg" , ProductId = 2},
                new Image {Id = 6, Url = "jewelry.jpg" , ProductId = 2},
                new Image {Id = 7, Url = "jewelry.jpg" , ProductId = 3},
                new Image {Id = 8, Url = "jewelry.jpg" , ProductId = 3},
                new Image {Id = 9, Url = "jewelry.jpg" , ProductId = 4},
                new Image {Id = 10, Url = "jewelry.jpg" , ProductId = 4},
                new Image {Id = 11, Url = "bag.jpg" , ProductId = 5},
                new Image {Id = 12, Url = "bag.jpg" , ProductId = 5},
                new Image {Id = 13, Url = "bag.jpg" , ProductId = 6},
                new Image {Id = 14, Url = "bag.jpg" , ProductId = 6},
                new Image {Id = 15, Url = "bag.jpg" , ProductId = 7},
                new Image {Id = 16, Url = "bag.jpg" , ProductId = 7}
                
            };
            

           



            var productList = new List<Product> {
                new Product {Id = 1, Name = "Red Silver Earrings", Description = "Red earrings with silver frames.", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 }, 
                new Product {Id = 2, Name = "Red-Blue Steel Earrings", Description = "Red-blue earrings with steel frames.", SubcategoryId = 1, Price = 45.00M, ProductSeriesId = 2 }, 
                new Product {Id = 3, Name = "Green Silver Necklace", Description = "Green necklace with a silver frame.", SubcategoryId = 2, Price = 35.00M, ProductSeriesId = 3 }, 
                new Product {Id = 4, Name = "Blue Glass Ring", Description = "Blue ring made out of glass and silver.", SubcategoryId = 3 , Price = 25.00M, ProductSeriesId = 4 }, 
                new Product {Id = 5, Name = "Traditional Hand Bag", Description = "Hand bag with traditional sewing pattern.", SubcategoryId = 4, Price = 120.00M, ProductSeriesId = 5 }, 
                new Product {Id = 6, Name = "Traditional Hand Bag", Description = "Hand bag with traditional sewing pattern.", SubcategoryId = 4, Price = 120.00M, ProductSeriesId = 5 }, 
                new Product {Id = 7, Name = "Blue Book Binding", Description = "Blue book binding.", SubcategoryId = 5, Price = 70.00M, ProductSeriesId = 6 }, 
            };

            builder.Entity<Color>().HasData(colorList);
            builder.Entity<Material>().HasData(materialList);
            builder.Entity<Product>().HasData(productList);
            builder.Entity<Tag>().HasData(tagList);
            builder.Entity<ProductSeries>().HasData(productSeriesList);
            builder.Entity<Image>().HasData(imageList);

            builder.Entity<ProductSeries>()
                .HasMany(ps => ps.Products)
                .WithOne(p => p.ProductSeries)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Tag>()
               .HasMany(c => c.ProductSeries)
               .WithMany(p => p.DefaultTags)
               .UsingEntity<Dictionary<string, object>>("ProductsSeriesTags",
               r => r.HasOne<ProductSeries>().WithMany().HasForeignKey("ProductSeriesId"),
                   l => l.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
                   mt =>
                   {
                       mt.HasKey("ProductSeriesId", "TagId");
                       mt.HasData(
                           new { ProductSeriesId = 1, TagId = 2 },
                           new { ProductSeriesId = 2, TagId = 2 },
                           new { ProductSeriesId = 3, TagId = 2 },
                           new { ProductSeriesId = 5, TagId = 1 },
                           new { ProductSeriesId = 6, TagId = 1 });
                   });

            builder.Entity<Material>()
                .HasMany(c => c.ProductSeries)
                .WithMany(p => p.DefaultMaterials)
                .UsingEntity<Dictionary<string, object>>("ProductsSeriesMaterials",
                r => r.HasOne<ProductSeries>().WithMany().HasForeignKey("ProductSeriesId"),
                    l => l.HasOne<Material>().WithMany().HasForeignKey("MaterialId"),
                    mt =>
                    {
                        mt.HasKey("ProductSeriesId", "MaterialId");
                        mt.HasData(
                            new { ProductSeriesId = 1, MaterialId = 1 },
                            new { ProductSeriesId = 2, MaterialId = 2 },
                            new { ProductSeriesId = 3, MaterialId = 1 },
                            new { ProductSeriesId = 4, MaterialId = 3 },
                            new { ProductSeriesId = 5, MaterialId = 4 },
                            new { ProductSeriesId = 6, MaterialId = 4 });
                    });

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

            builder.Entity<Tag>()
                .HasMany(t => t.Products)
                .WithMany(p => p.Tags)
                .UsingEntity<Dictionary<string, object>>("ProductsTags",
                r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                l => l.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
                mt =>
                {
                    mt.HasKey("ProductId", "TagId");
                    mt.HasData(
                        new { ProductId = 1, TagId = 2 },
                        new { ProductId = 2, TagId = 2 },
                        new { ProductId = 3, TagId = 2 },
                        new { ProductId = 5, TagId = 1 },
                        new { ProductId = 6, TagId = 1 }
                        );
                });



        }
    }
}
