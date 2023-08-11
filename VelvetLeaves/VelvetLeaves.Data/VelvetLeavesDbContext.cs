using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VelvetLeaves.Data.Configuration;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Data.Seeding;

namespace VelvetLeaves.Data
{
    public class VelvetLeavesDbContext : IdentityDbContext<ApplicationUser>
    {
        private bool seedDb;
        private string? adminEmail;
        private string? adminPassword;
        public VelvetLeavesDbContext(DbContextOptions<VelvetLeavesDbContext> options, IOptions<VelvetLeavesDbContextConfiguration> configuration)
            : base(options)
        {
            seedDb = configuration.Value.SeedDb;
            adminEmail = configuration.Value.AdminEmail;
            adminPassword = configuration.Value.AdminPassword;
        }

        public VelvetLeavesDbContext(DbContextOptions<VelvetLeavesDbContext> options)
            : base(options)
        {

        }

        
        public DbSet<Address> Addresses { get; set; } = null!;
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

            builder.SeedAdmin(adminEmail, adminPassword);
            if (seedDb)
            {
                builder.SeedDatabase();

            }

            builder.ConfigureRelations();

            base.OnModelCreating(builder);



        }
    }
}