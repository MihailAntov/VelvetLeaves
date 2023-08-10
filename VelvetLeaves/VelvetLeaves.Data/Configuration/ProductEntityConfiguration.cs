using Microsoft.EntityFrameworkCore;

using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public static class ProductEntityConfiguration 
    {
        public static void SeedProductsAndRelations(this ModelBuilder builder)
        {
            //old seed
            //var productList = new List<Product> {
            //    new Product {Id = 1, Name = "Red Silver Earrings", Description = "Red earrings with silver frames.", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 }, 
            //    new Product {Id = 2, Name = "Red-Blue Steel Earrings", Description = "Red-blue earrings with steel frames.", SubcategoryId = 1, Price = 45.00M, ProductSeriesId = 2 }, 
            //    new Product {Id = 3, Name = "Green Silver Necklace", Description = "Green necklace with a silver frame.", SubcategoryId = 2, Price = 35.00M, ProductSeriesId = 3 }, 
            //    new Product {Id = 4, Name = "Blue Glass Ring", Description = "Blue ring made out of glass and silver.", SubcategoryId = 3 , Price = 25.00M, ProductSeriesId = 4 }, 
            //    new Product {Id = 5, Name = "Traditional Hand Bag", Description = "Hand bag with traditional sewing pattern.", SubcategoryId = 4, Price = 120.00M, ProductSeriesId = 5 }, 
            //    new Product {Id = 6, Name = "Traditional Hand Bag", Description = "Hand bag with traditional sewing pattern.", SubcategoryId = 4, Price = 120.00M, ProductSeriesId = 5 }, 
            //    new Product {Id = 7, Name = "Blue Book Binding", Description = "Blue book binding.", SubcategoryId = 5, Price = 70.00M, ProductSeriesId = 6 }, 
            //};

            var productList = new List<Product> {
                new Product {Id = 1, Name = "Ленена чанта \"Слънце\"",  Description = "Авторска ръчно изработена чанта от лен, с ръчна бродерия и памучна подплата. Всяка чанта е уникална и няма да бъде повторена в тази комбинация от модел и шевица.", SubcategoryId = 1, Price = 140.00M, ProductSeriesId = 1 },
                new Product {Id = 2, Name = "Ленена чанта \" Синева\"", Description = "Авторска ръчно изработена чанта от лен, с ръчна бродерия и памучна подплата. Всяка чанта е уникална и няма да бъде повторена в тази комбинация от модел и шевица.", SubcategoryId = 1, Price = 150.00M, ProductSeriesId = 1 },
                new Product {Id = 3, Name = "Ленен несесер ",           Description = "Авторски ръчно изработен несесер от лен, с ръчна бродерия и памучна подплата. ", SubcategoryId = 1, Price = 40.00M, ProductSeriesId = 1 },
                new Product {Id = 4, Name = "Ленен несесер ",           Description = "Авторски ръчно изработен несесер от лен, с ръчна бродерия и памучна подплата. ", SubcategoryId = 1, Price = 40.00M, ProductSeriesId = 1 },
                new Product {Id = 5, Name = "Ленена подвързия за книга", Description = "Авторска ръчно изработенa подвързия за книга от лен, с ръчна бродерия и памучна подплата.", SubcategoryId = 1, Price = 45.00M, ProductSeriesId = 1 },
                new Product {Id = 6, Name = "Ленена подвързия за Kindle", Description = "Авторска ръчно изработенa подвързия за електронна книга от лен, с ръчна бродерия и памучна подплата. ", SubcategoryId = 1, Price = 45.00M, ProductSeriesId = 1 },
                new Product {Id = 7, Name = "Обици \"Букет\"",          Description = "Ръчно изработени обеци от естествени копринени пашкули и стомана", SubcategoryId = 1, Price = 25.00M, ProductSeriesId = 1 },
                new Product {Id = 8, Name = "Обици \"Букет\"",          Description = "Ръчно изработени обеци от естествени копринени пашкули и стомана", SubcategoryId = 1, Price = 25.00M, ProductSeriesId = 1 },
                new Product {Id = 9, Name = "Големи обеци \"Грозд\"",   Description = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 1, Price = 60.00M, ProductSeriesId = 1 },
                new Product {Id = 10, Name = "Големи обеци \"Грозд\"", Description = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 1, Price = 60.00M, ProductSeriesId = 1 },
                new Product {Id = 11, Name = "Средни обеци \"Грозд\"", Description = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 1, Price = 60.00M, ProductSeriesId = 1 },
                new Product {Id = 12, Name = "Средни обеци \"Грозд\"", Description = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 1, Price = 60.00M, ProductSeriesId = 1 },
                new Product {Id = 13, Name = "Малки обеци \"Грозд\"",   Description = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 1, Price = 35.00M, ProductSeriesId = 1 },
                new Product {Id = 14, Name = "Малки обеци \"Грозд\" ", Description = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 1, Price = 35.00M, ProductSeriesId = 1 },
                new Product {Id = 15, Name = "Дълги обеци",             Description = "Ръчно изработени обеци от естествени копринени пашкули, стоманена тел, сребро и полускъпоценни камъни", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 },
                new Product {Id = 16, Name = "Дълги обеци",             Description = "Ръчно изработени обеци от естествени копринени пашкули, стоманена тел, сребро и полускъпоценни камъни", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 },
                new Product {Id = 17, Name = "Обеци на синджир",        Description = "Ръчно изработени обеци от естествени копринени пашкули и стомана", SubcategoryId = 1, Price = 25.00M, ProductSeriesId = 1 },
                new Product {Id = 18, Name = "Обеци на синджир",        Description = "Ръчно изработени обеци от естествени копринени пашкули и стомана", SubcategoryId = 1, Price = 25.00M, ProductSeriesId = 1 },
                new Product {Id = 19, Name = "Обеци \"Тромбон\"",       Description = "Ръчно изработени обеци от естествени копринени пашкули, посребрена тел, сребро и кристали Сваровски", SubcategoryId = 1, Price = 35.00M, ProductSeriesId = 1 },
                new Product {Id = 20, Name = "Колие малък \"Грозд\"",   Description = "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 },
                new Product {Id = 21, Name = "Колие малък \"Грозд\"",   Description = "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 },
                new Product {Id = 22, Name = "Колие на обръч \"Мак\"",  Description = "Ръчно изработено колие от естествени копринени пашкули, посребрена тел и полускъпоценни камъни", SubcategoryId = 1, Price = 45.00M, ProductSeriesId = 1 },
                new Product {Id = 23, Name = "Колие на обръч \"Мак\"",  Description = "Ръчно изработено колие от естествени копринени пашкули, посребрена тел и полускъпоценни камъни", SubcategoryId = 1, Price = 45.00M, ProductSeriesId = 1 },
                new Product {Id = 24, Name = "Сребърно колие",          Description = "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 },
                new Product {Id = 25, Name = "Сребърно колие",          Description = "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 },
                new Product {Id = 26, Name = "Колие на кожа с цели пашкули", Description = "Ръчно изработено колие от естествени копринени пашкули, кожа, полускъпоценни камъни и с магнитна закопчалка", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 },
                new Product {Id = 27, Name = "Колие на кожа с цели пашкули", Description = "Ръчно изработено колие от естествени копринени пашкули, кожа, полускъпоценни камъни и с магнитна закопчалка", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 },
                new Product {Id = 28, Name = "Колие на кожа с цветя", Description = "Ръчно изработено колие от естествени копринени пашкули, кожа, полускъпоценни камъни и с магнитна закопчалка", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 },
                new Product {Id = 29, Name = "Колие на велур с цветя", Description = "Ръчно изработено колие от естествени копринени пашкули, велур, ръчно изработен дървен елемент от орех, и полускъпоценни камъни", SubcategoryId = 1, Price = 35.00M, ProductSeriesId = 1 },
                new Product {Id = 30, Name = "Колие на велур с цели пашкули", Description = "Ръчно изработено колие от естествени копринени пашкули, велур и полускъпоценни камъни", SubcategoryId = 1, Price = 40.00M, ProductSeriesId = 1 },
                new Product {Id = 31, Name = "Колие на велур с цели пашкули", Description = "Ръчно изработено колие от естествени копринени пашкули, велур и полускъпоценни камъни", SubcategoryId = 1, Price = 40.00M, ProductSeriesId = 1 },
                new Product {Id = 32, Name = "Колие на велур с цветя", Description = "Ръчно изработено колие от естествени копринени пашкули, велур и полускъпоценни камъни", SubcategoryId = 1, Price = 35.00M, ProductSeriesId = 1 },
                new Product {Id = 33, Name = "Колие на велур с цветя", Description = "Ръчно изработено колие от естествени копринени пашкули, велур, ръчно изработен дървен елемент от орех, и полускъпоценни камъни", SubcategoryId = 1, Price = 35.00M, ProductSeriesId = 1 },
                new Product {Id = 34, Name = "Колие \"Венец\"",         Description = "Ръчно изработено колие от естествени копринени пашкули с магнитна закопчалка", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 },
                new Product {Id = 35, Name = "Колие \"Венец\"",         Description = "Ръчно изработено колие от естествени копринени пашкули с магнитна закопчалка", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 },
                new Product {Id = 36, Name = "Стоманено колие",         Description = "Ръчно изработено колие от естествени копринени пашкули, стомана и речни перли", SubcategoryId = 1, Price = 45.00M, ProductSeriesId = 1 },
                new Product {Id = 37, Name = "Сребърна гривна",         Description = "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и сребро", SubcategoryId = 1, Price = 45.00M, ProductSeriesId = 1 },
                new Product {Id = 38, Name = "Сребърна гривна",         Description = "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и сребро", SubcategoryId = 1, Price = 45.00M, ProductSeriesId = 1 },
                new Product {Id = 39, Name = "Кожена гривна",           Description = "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и кожа, с магнитна закопчалка", SubcategoryId = 1, Price = 45.00M, ProductSeriesId = 1 },
                new Product {Id = 40, Name = "Кожена гривна",           Description = "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и кожа, с магнитна закопчалка", SubcategoryId = 1, Price = 45.00M, ProductSeriesId = 1 },
                new Product {Id = 41, Name = "Сребърен пръстен с речна перла", Description = "Ръчно изработен пръстен от естествени копринени пашкули, сладководни перли и сребро", SubcategoryId = 1, Price = 35.00M, ProductSeriesId = 1 },
                new Product {Id = 42, Name = "Сребърен пръстен с речна перла", Description = "Ръчно изработен пръстен от естествени копринени пашкули, сладководни перли и сребро", SubcategoryId = 1, Price = 35.00M, ProductSeriesId = 1 },
                new Product {Id = 43, Name = "Стоманен пръстен",        Description = "Ръчно изработен пръстен от естествени копринени пашкули и стомана", SubcategoryId = 1, Price = 25.00M, ProductSeriesId = 1 },
                new Product {Id = 44, Name = "Стоманен пръстен",        Description = "Ръчно изработен пръстен от естествени копринени пашкули и стомана", SubcategoryId = 1, Price = 25.00M, ProductSeriesId = 1 }
               
            };

            builder.Entity<Product>().Property(p => p.Price)
                .HasPrecision(18, 2);
            
            builder.Entity<Product>().HasData(productList);
      

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
                           new { ProductSeriesId = 6, TagId = 3 });
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
                            new { ProductSeriesId = 1, MaterialId = 2 },
                            new { ProductSeriesId = 2, MaterialId = 1 },
                            new { ProductSeriesId = 2, MaterialId = 2 },
                            new { ProductSeriesId = 3, MaterialId = 1 },
                            new { ProductSeriesId = 3, MaterialId = 2 },
                            new { ProductSeriesId = 4, MaterialId = 8 },
                            new { ProductSeriesId = 4, MaterialId = 3 },
                            new { ProductSeriesId = 5, MaterialId = 8 },
                            new { ProductSeriesId = 5, MaterialId = 4 },
                            new { ProductSeriesId = 5, MaterialId = 5 },
                            new { ProductSeriesId = 6, MaterialId = 8 },
                            new { ProductSeriesId = 6, MaterialId = 3 },
                            new { ProductSeriesId = 6, MaterialId = 4 },
                            new { ProductSeriesId = 6, MaterialId = 5 },
                            new { ProductSeriesId = 7, MaterialId = 8 },
                            new { ProductSeriesId = 7, MaterialId = 3 },
                            new { ProductSeriesId = 8, MaterialId = 5 },
                            new { ProductSeriesId = 8, MaterialId = 8 },
                            new { ProductSeriesId = 8, MaterialId = 9 },
                            new { ProductSeriesId = 8, MaterialId = 4 },
                            new { ProductSeriesId = 8, MaterialId = 6 },
                            new { ProductSeriesId = 9, MaterialId = 5 },
                            new { ProductSeriesId = 9, MaterialId = 8 },
                            new { ProductSeriesId = 9, MaterialId = 4 },
                            new { ProductSeriesId = 10, MaterialId = 8 },
                            new { ProductSeriesId = 10, MaterialId = 5 },
                            new { ProductSeriesId = 10, MaterialId = 9 },
                            new { ProductSeriesId = 11, MaterialId = 8 },
                            new { ProductSeriesId = 11, MaterialId = 5 },
                            new { ProductSeriesId = 11, MaterialId = 4 },
                            new { ProductSeriesId = 12, MaterialId = 8 },
                            new { ProductSeriesId = 12, MaterialId = 5 },
                            new { ProductSeriesId = 12, MaterialId = 10 },
                            new { ProductSeriesId = 12, MaterialId = 11 },
                            new { ProductSeriesId = 13, MaterialId = 8 },
                            new { ProductSeriesId = 13, MaterialId = 5 },
                            new { ProductSeriesId = 13, MaterialId = 12 },
                            new { ProductSeriesId = 14, MaterialId = 8 },
                            new { ProductSeriesId = 14, MaterialId = 11 },
                            new { ProductSeriesId = 15, MaterialId = 8 },
                            new { ProductSeriesId = 15, MaterialId = 3 },
                            new { ProductSeriesId = 15, MaterialId = 14 },
                            new { ProductSeriesId = 16, MaterialId = 8 },
                            new { ProductSeriesId = 16, MaterialId = 4 },
                            new { ProductSeriesId = 16, MaterialId = 5 },
                            new { ProductSeriesId = 17, MaterialId = 8 },
                            new { ProductSeriesId = 17, MaterialId = 5 },
                            new { ProductSeriesId = 17, MaterialId = 10 },
                            new { ProductSeriesId = 17, MaterialId = 11 },
                            new { ProductSeriesId = 18, MaterialId = 8 },
                            new { ProductSeriesId = 18, MaterialId = 4 },
                            new { ProductSeriesId = 18, MaterialId = 14 },
                            new { ProductSeriesId = 19, MaterialId = 8 },
                            new { ProductSeriesId = 19, MaterialId = 3 });
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
                            new { ProductId = 2, ColorId = 7 },
                            new { ProductId = 3, ColorId = 4 },
                            new { ProductId = 4, ColorId = 3 },
                            new { ProductId = 5, ColorId = 1 },
                            new { ProductId = 5, ColorId = 3 },
                            new { ProductId = 6, ColorId = 1 },
                            new { ProductId = 6, ColorId = 7 },
                            new { ProductId = 7, ColorId = 3 },
                            new { ProductId = 8, ColorId = 1 },
                            new { ProductId = 9, ColorId = 9 },
                            new { ProductId = 10, ColorId = 7 },
                            new { ProductId = 10, ColorId = 8 },
                            new { ProductId = 11, ColorId = 6 },
                            new { ProductId = 12, ColorId = 1 },
                            new { ProductId = 13, ColorId = 10 },
                            new { ProductId = 14, ColorId = 1 },
                            new { ProductId = 15, ColorId = 5 },
                            new { ProductId = 16, ColorId = 11 },
                            new { ProductId = 16, ColorId = 12 },
                            new { ProductId = 17, ColorId = 3 },
                            new { ProductId = 18, ColorId = 13 },
                            new { ProductId = 19, ColorId = 5 },
                            new { ProductId = 20, ColorId = 1 },
                            new { ProductId = 21, ColorId = 10 },
                            new { ProductId = 22, ColorId = 3 },
                            new { ProductId = 23, ColorId = 4 },
                            new { ProductId = 23, ColorId = 5 },
                            new { ProductId = 24, ColorId = 11 },
                            new { ProductId = 24, ColorId = 12 },
                            new { ProductId = 25, ColorId = 9 },
                            new { ProductId = 26, ColorId = 1 },
                            new { ProductId = 26, ColorId = 5 },
                            new { ProductId = 27, ColorId = 3 },
                            new { ProductId = 27, ColorId = 14 },
                            new { ProductId = 28, ColorId = 10 },
                            new { ProductId = 28, ColorId = 12 },
                            new { ProductId = 29, ColorId = 6 },
                            new { ProductId = 30, ColorId = 6 },
                            new { ProductId = 30, ColorId = 8 },
                            new { ProductId = 31, ColorId = 1 },
                            new { ProductId = 31, ColorId = 15 },
                            new { ProductId = 32, ColorId = 2 },
                            new { ProductId = 33, ColorId = 11 },
                            new { ProductId = 33, ColorId = 14 },
                            new { ProductId = 34, ColorId = 1 },
                            new { ProductId = 34, ColorId = 7 },
                            new { ProductId = 35, ColorId = 1 },
                            new { ProductId = 35, ColorId = 3 },
                            new { ProductId = 35, ColorId = 4 },
                            new { ProductId = 36, ColorId = 4 },
                            new { ProductId = 36, ColorId = 5 },
                            new { ProductId = 37, ColorId = 10 },
                            new { ProductId = 38, ColorId = 1 },
                            new { ProductId = 39, ColorId = 4 },
                            new { ProductId = 39, ColorId = 5 },
                            new { ProductId = 40, ColorId = 1 },
                            new { ProductId = 40, ColorId = 8 },
                            new { ProductId = 41, ColorId = 11 },
                            new { ProductId = 42, ColorId = 8 },
                            new { ProductId = 43, ColorId = 3 },
                            new { ProductId = 44, ColorId = 1 },
                            new { ProductId = 44, ColorId = 15 });
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
                            new { ProductId = 1,    MaterialId = 1 },
                            new { ProductId = 1,    MaterialId = 2 },
                            new { ProductId = 2,    MaterialId = 1 },
                            new { ProductId = 2,    MaterialId = 2 },
                            new { ProductId = 3,    MaterialId = 1 },
                            new { ProductId = 3,    MaterialId = 2 },
                            new { ProductId = 4,    MaterialId = 1 },
                            new { ProductId = 4,    MaterialId = 2 },
                            new { ProductId = 5,    MaterialId = 1 },
                            new { ProductId = 5,    MaterialId = 2 },
                            new { ProductId = 6,    MaterialId = 1 },
                            new { ProductId = 6,    MaterialId = 2 },
                            new { ProductId = 7,    MaterialId = 8 },
                            new { ProductId = 7,    MaterialId = 3 },
                            new { ProductId = 8,    MaterialId = 8 },
                            new { ProductId = 8,    MaterialId = 3 },
                            new { ProductId = 9,    MaterialId = 8 },
                            new { ProductId = 9,    MaterialId = 4 },
                            new { ProductId = 9,    MaterialId = 5 },
                            new { ProductId = 10,   MaterialId = 8 },
                            new { ProductId = 10,   MaterialId = 3 },
                            new { ProductId = 10,   MaterialId = 4 },
                            new { ProductId = 10,   MaterialId = 5 },
                            new { ProductId = 11,   MaterialId = 8 },
                            new { ProductId = 11,   MaterialId = 3 },
                            new { ProductId = 11,   MaterialId = 4 },
                            new { ProductId = 11,   MaterialId = 5 },
                            new { ProductId = 12,   MaterialId = 8 },
                            new { ProductId = 12,   MaterialId = 3 },
                            new { ProductId = 12,   MaterialId = 4 },
                            new { ProductId = 12,   MaterialId = 5 },
                            new { ProductId = 13,   MaterialId = 8 },
                            new { ProductId = 13,   MaterialId = 3 },
                            new { ProductId = 13,   MaterialId = 4 },
                            new { ProductId = 13,   MaterialId = 5 },
                            new { ProductId = 14,   MaterialId = 8 },
                            new { ProductId = 14,   MaterialId = 3 },
                            new { ProductId = 14,   MaterialId = 4 },
                            new { ProductId = 14,   MaterialId = 5 },
                            new { ProductId = 15,   MaterialId = 8 },
                            new { ProductId = 15,   MaterialId = 3 },
                            new { ProductId = 15,   MaterialId = 4 },
                            new { ProductId = 15,   MaterialId = 5 },
                            new { ProductId = 16,   MaterialId = 8 },
                            new { ProductId = 16,   MaterialId = 3 },
                            new { ProductId = 16,   MaterialId = 4 },
                            new { ProductId = 16,   MaterialId = 5 },
                            new { ProductId = 17,   MaterialId = 8 },
                            new { ProductId = 17,   MaterialId = 3 },
                            new { ProductId = 18,   MaterialId = 8 },
                            new { ProductId = 18,   MaterialId = 3 },
                            new { ProductId = 19,   MaterialId = 8 },
                            new { ProductId = 19,   MaterialId = 9 },
                            new { ProductId = 19,   MaterialId = 4 },
                            new { ProductId = 19,   MaterialId = 6 },
                            new { ProductId = 20,   MaterialId = 8 },
                            new { ProductId = 20,   MaterialId = 5 },
                            new { ProductId = 20,   MaterialId = 4 },
                            new { ProductId = 21,   MaterialId = 8 },
                            new { ProductId = 21,   MaterialId = 5 },
                            new { ProductId = 21,   MaterialId = 4 },
                            new { ProductId = 22,   MaterialId = 8 },
                            new { ProductId = 22,   MaterialId = 5 },
                            new { ProductId = 22,   MaterialId = 9 },
                            new { ProductId = 23,   MaterialId = 8 },
                            new { ProductId = 23,   MaterialId = 5 },
                            new { ProductId = 23,   MaterialId = 9 },
                            new { ProductId = 24,   MaterialId = 8 },
                            new { ProductId = 24,   MaterialId = 5 },
                            new { ProductId = 24,   MaterialId = 4 },
                            new { ProductId = 25,   MaterialId = 8 },
                            new { ProductId = 25,   MaterialId = 5 },
                            new { ProductId = 25,   MaterialId = 3 },
                            new { ProductId = 26,   MaterialId = 8 },
                            new { ProductId = 26,   MaterialId = 5 },
                            new { ProductId = 26,   MaterialId = 10 },
                            new { ProductId = 26,   MaterialId = 11 },
                            new { ProductId = 27,   MaterialId = 8 },
                            new { ProductId = 27,   MaterialId = 5 },
                            new { ProductId = 27,   MaterialId = 10 },
                            new { ProductId = 27,   MaterialId = 11 },
                            new { ProductId = 28,   MaterialId = 8 },
                            new { ProductId = 28,   MaterialId = 5 },
                            new { ProductId = 28,   MaterialId = 10 },
                            new { ProductId = 28,   MaterialId = 11 },
                            new { ProductId = 29,   MaterialId = 8 },
                            new { ProductId = 29,   MaterialId = 5 },
                            new { ProductId = 29,   MaterialId = 12 },
                            new { ProductId = 29,   MaterialId = 13 },
                            new { ProductId = 30,   MaterialId = 8 },
                            new { ProductId = 30,   MaterialId = 5 },
                            new { ProductId = 30,   MaterialId = 12 },
                            new { ProductId = 31,   MaterialId = 8 },
                            new { ProductId = 31,   MaterialId = 5 },
                            new { ProductId = 31,   MaterialId = 12 },
                            new { ProductId = 32,   MaterialId = 8 },
                            new { ProductId = 32,   MaterialId = 12 },
                            new { ProductId = 32,   MaterialId = 13 },
                            new { ProductId = 32,   MaterialId = 5 },
                            new { ProductId = 33,   MaterialId = 8 },
                            new { ProductId = 33,   MaterialId = 12 },
                            new { ProductId = 33,   MaterialId = 13},
                            new { ProductId = 33,   MaterialId = 5 },
                            new { ProductId = 34,   MaterialId = 8 },
                            new { ProductId = 34,   MaterialId = 11 },
                            new { ProductId = 35,   MaterialId = 8 },
                            new { ProductId = 35,   MaterialId = 11 },
                            new { ProductId = 36,   MaterialId = 8 },
                            new { ProductId = 36,   MaterialId = 3 },
                            new { ProductId = 36,   MaterialId = 14 },
                            new { ProductId = 37,   MaterialId = 8 },
                            new { ProductId = 37,   MaterialId = 4 },
                            new { ProductId = 37,   MaterialId = 5 },
                            new { ProductId = 38,   MaterialId = 8 },
                            new { ProductId = 38,   MaterialId = 4 },
                            new { ProductId = 38,   MaterialId = 5 },
                            new { ProductId = 39,   MaterialId = 8 },
                            new { ProductId = 39,   MaterialId = 5 },
                            new { ProductId = 39,   MaterialId = 10 },
                            new { ProductId = 39,   MaterialId = 11},
                            new { ProductId = 40,   MaterialId = 8 },
                            new { ProductId = 40,   MaterialId = 5 },
                            new { ProductId = 40,   MaterialId = 10 },
                            new { ProductId = 40,   MaterialId = 11 },
                            new { ProductId = 41,   MaterialId = 8 },
                            new { ProductId = 41,   MaterialId = 4 },
                            new { ProductId = 41,   MaterialId = 14 },
                            new { ProductId = 42,   MaterialId = 8 },
                            new { ProductId = 42,   MaterialId = 4 },
                            new { ProductId = 42,   MaterialId = 14 },
                            new { ProductId = 43,   MaterialId = 8 },
                            new { ProductId = 43,   MaterialId = 3 },
                            new { ProductId = 44,   MaterialId = 8 },
                            new { ProductId = 44,   MaterialId = 3 });
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
                        new { ProductId = 9, TagId = 3 },
                        new { ProductId = 10, TagId = 3 },
                        new { ProductId = 15, TagId = 3 },
                        new { ProductId = 16, TagId = 3 },
                        new { ProductId = 22, TagId = 1 },
                        new { ProductId = 23, TagId = 1 },
                        new { ProductId = 26, TagId = 2 },
                        new { ProductId = 27, TagId = 2 },
                        new { ProductId = 30, TagId = 2 },
                        new { ProductId = 31, TagId = 2 },
                        new { ProductId = 43, TagId = 1 });
                });

            builder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });



        }
    }
}
