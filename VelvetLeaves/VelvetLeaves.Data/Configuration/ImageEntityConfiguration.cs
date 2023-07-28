

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            var imageList = new List<Image>
            {
                new Image {Id = "64be89ae1409e5a61554e6ed", ProductId = 1},
                new Image {Id = "64be8c68cac3fdf11a06fbbb", ProductId = 1},
                new Image {Id = "64be8c6df878c3764a814981", ProductId = 1},
                new Image {Id = "64be8c733df251037e15d70a", ProductId = 2},
                new Image {Id = "64be8c7a0ef21ca57c247498", ProductId = 2},
                new Image {Id = "64be8c813d909293463359d6", ProductId = 2},
                new Image {Id = "64be8c870b7f086367ebb6a5", ProductId = 3},
                new Image {Id = "64be8c8d7d5c466b820b73af", ProductId = 3},
                new Image {Id = "64be8c9332b088f8d6063040", ProductId = 4},
                new Image {Id = "64be8c99f991d074063b5098", ProductId = 4},
                new Image {Id = "64be8c9f41c19cda7ab19853", ProductId = 5},
                new Image {Id = "64be8ca5b7f1ea12383c364a", ProductId = 5},
                new Image {Id = "64be8caa293917f47210277e", ProductId = 6},
                new Image {Id = "64be8cae1813d7aff61e173b", ProductId = 6},
                new Image {Id = "64be8cb3b390e17c62039322", ProductId = 7},
                new Image {Id = "64be8cb81a39dd6ed0351ebb", ProductId = 7}
            };

            builder.HasData(imageList);
        }
    }
}
