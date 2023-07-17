using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GalleryProduct>().HasKey(gp => new { gp.GalleryId, gp.ProductId });
            
            base.OnModelCreating(builder);
        }
    }
}