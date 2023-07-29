

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public class ProductSeriesEntityConfiguration : IEntityTypeConfiguration<ProductSeries>
    {
        public void Configure(EntityTypeBuilder<ProductSeries> builder)
        {
            var productSeriesList = new List<ProductSeries>
            {
                new ProductSeries{Id = 1, Name = "Silver Earrings", SubcategoryId = 1, DefaultName="Silver Earrings", DefaultDescription = "Earrings with silver frames.", DefaultPrice = 50.00M},
                new ProductSeries{Id = 2, Name = "Steel Earrings", SubcategoryId = 1, DefaultName="Steel Earrings", DefaultDescription = "Earrings with steel frames.", DefaultPrice = 50.00M},
                new ProductSeries{Id = 3, Name = "Silver Necklace", SubcategoryId = 2, DefaultName="Silver Necklace", DefaultDescription = "Necklace with a silver frame.", DefaultPrice = 50.00M},
                new ProductSeries{Id = 4, Name = "Glass Ring", SubcategoryId = 3, DefaultName="Glass Ring", DefaultDescription = "Ring made out of glass and silver.", DefaultPrice = 50.00M},
                new ProductSeries{Id = 5, Name = "Traditional Bag", SubcategoryId = 4, DefaultName="Traditional Bag", DefaultDescription = "Hand bag with traditional sewing pattern.", DefaultPrice = 50.00M},
                new ProductSeries{Id = 6, Name = "Book Binding", SubcategoryId = 5, DefaultName="Book Binding", DefaultDescription = "Book binding.", DefaultPrice = 50.00M},
            };


            builder.Property(p => p.DefaultPrice)
                .HasPrecision(18, 2);

            builder.HasData(productSeriesList);


        }
    }
}
