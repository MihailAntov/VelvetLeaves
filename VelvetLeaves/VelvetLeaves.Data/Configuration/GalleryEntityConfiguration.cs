

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public static class GalleryEntityConfiguration 
    {
        public static void SeedGalleries(this ModelBuilder builder)
        {
            var galleryList = new List<Gallery>
            {
                new Gallery {Id = 1, Name = "Silk Cocoons",Description = "Handcrafted jewelry made of silk cocoons",ImageId="64be8c870b7f086367ebb6a5"},
                new Gallery {Id = 2, Name = "Glass",Description = "Handcrafted jewelry made of glass",ImageId="64be8c9332b088f8d6063040"}
            };

            builder.Entity<Gallery>()
                .HasData(galleryList);

            var galleryProductList = new List<GalleryProduct>
            {
                new GalleryProduct {GalleryId = 1, ProductId = 1, Position = 1},
                new GalleryProduct {GalleryId = 1, ProductId = 2, Position = 2},
                new GalleryProduct {GalleryId = 1, ProductId = 3, Position = 3},
                new GalleryProduct {GalleryId = 2, ProductId = 4, Position = 1}
            };

            builder.Entity<GalleryProduct>()
                .HasData(galleryProductList);
        }
    }
}
