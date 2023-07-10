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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GalleryProduct>().HasKey(gp => new { gp.GalleryId, gp.ProductId });
            
            base.OnModelCreating(builder);
        }
    }
}