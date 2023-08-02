using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data.Configuration;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data
{
    public class VelvetLeavesDbContext : IdentityDbContext<ApplicationUser>
    {
        public VelvetLeavesDbContext(DbContextOptions<VelvetLeavesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<AppPreferences> AppPreferences { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Subcategory> Subcategories { get; set; } = null!;
        public DbSet<Gallery> Galleries { get; set; } = null!;
        public DbSet<GalleryProduct> GalleriesProducts { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<ProductSeries> ProductSeries { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GalleryProduct>().HasKey(gp => new { gp.GalleryId, gp.ProductId });

            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            builder.ApplyConfiguration(new SubCategoryEntityConfiguration());
            builder.ApplyConfiguration(new ColorEntityConfiguration());
            builder.ApplyConfiguration(new TagEntityConfiguration());
            builder.ApplyConfiguration(new MaterialEntityConfiguration());
            builder.ApplyConfiguration(new ProductSeriesEntityConfiguration());
            builder.ApplyConfiguration(new ImageEntityConfiguration());
            builder.SeedProductsAndRelations();
            builder.SeedGalleries();
            builder.SeedUsers();

            base.OnModelCreating(builder);
        }
    }
}