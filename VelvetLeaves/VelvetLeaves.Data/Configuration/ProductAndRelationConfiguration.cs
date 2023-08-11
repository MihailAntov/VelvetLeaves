using Microsoft.EntityFrameworkCore;

using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public static class ProductAndRelationConfiguration 
    {
        public static void ConfigureRelations(this ModelBuilder builder)
        {
            

            builder.Entity<Product>().Property(p => p.Price)
                .HasPrecision(18, 2);

            builder.Entity<ProductSeries>().Property(p => p.DefaultPrice)
                .HasPrecision(18, 2);

            
      
            builder.Entity<ProductSeries>().Property("DefaultPrice").HasPrecision(18, 2);
            builder.Entity<Product>().Property("Price").HasPrecision(18, 2);

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
                });

            builder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<GalleryProduct>().
                HasKey(gp => new {gp.GalleryId, gp.ProductId });
        }
    }
}
