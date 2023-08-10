

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public static class GalleryEntityConfiguration 
    {
        public static void SeedGalleries(this ModelBuilder builder)
        {
            //old seed
            //var galleryList = new List<Gallery>
            //{
            //    new Gallery {Id = 1, Name = "Silk Cocoons",Description = "Handcrafted jewelry made of silk cocoons",ImageId="64be8c870b7f086367ebb6a5"},
            //    new Gallery {Id = 2, Name = "Glass",Description = "Handcrafted jewelry made of glass",ImageId="64be8c9332b088f8d6063040"}
            //};

            var galleryList = new List<Gallery>
            {
                new Gallery {Id = 1, Name = "Гроздове",Description = "Колиета и обеци от серия \"Грозд\"",ImageId="64d523b1a82f8b465badccfe"},
                new Gallery {Id = 2, Name = "Макове",Description = "Бижута от серия \"Мак\"",ImageId="64d524415910ab1c2728156e"},
                new Gallery {Id = 2, Name = "Нова колекция",Description = "Разгледайте новите ни предложения",ImageId="64d5241b4efab879d2b98106"}
            };

            builder.Entity<Gallery>()
                .HasData(galleryList);

            //old seed
            //var galleryProductList = new List<GalleryProduct>
            //{
            //    new GalleryProduct {GalleryId = 1, ProductId = 1, Position = 1},
            //    new GalleryProduct {GalleryId = 1, ProductId = 2, Position = 2},
            //    new GalleryProduct {GalleryId = 1, ProductId = 3, Position = 3},
            //    new GalleryProduct {GalleryId = 2, ProductId = 4, Position = 1}
            //};

            var galleryProductList = new List<GalleryProduct>
            {
                new GalleryProduct {GalleryId = 1, ProductId = 9, Position = 1},
                new GalleryProduct {GalleryId = 1, ProductId = 10, Position = 2},
                new GalleryProduct {GalleryId = 1, ProductId = 11, Position = 3},
                new GalleryProduct {GalleryId = 1, ProductId = 12, Position = 4},
                new GalleryProduct {GalleryId = 1, ProductId = 13, Position = 5},
                new GalleryProduct {GalleryId = 1, ProductId = 20, Position = 6},
                new GalleryProduct {GalleryId = 2, ProductId = 22, Position = 1},
                new GalleryProduct {GalleryId = 2, ProductId = 23, Position = 2},
                new GalleryProduct {GalleryId = 2, ProductId = 43, Position = 3},
                new GalleryProduct {GalleryId = 3, ProductId = 19, Position = 1},
                new GalleryProduct {GalleryId = 3, ProductId = 34, Position = 2},
                new GalleryProduct {GalleryId = 3, ProductId = 35, Position = 3},
                new GalleryProduct {GalleryId = 3, ProductId = 36, Position = 4}
            };

            builder.Entity<GalleryProduct>()
                .HasData(galleryProductList);
        }
    }
}
