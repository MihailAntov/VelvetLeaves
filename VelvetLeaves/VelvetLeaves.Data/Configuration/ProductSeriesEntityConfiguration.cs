

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public class ProductSeriesEntityConfiguration : IEntityTypeConfiguration<ProductSeries>
    {
        public void Configure(EntityTypeBuilder<ProductSeries> builder)
        {
            //old seed
            //var productSeriesList = new List<ProductSeries>
            //{
            //    new ProductSeries{Id = 1, Name = "Silver Earrings", SubcategoryId = 1, DefaultName="Silver Earrings", DefaultDescription = "Earrings with silver frames.", DefaultPrice = 50.00M},
            //    new ProductSeries{Id = 2, Name = "Steel Earrings", SubcategoryId = 1, DefaultName="Steel Earrings", DefaultDescription = "Earrings with steel frames.", DefaultPrice = 50.00M},
            //    new ProductSeries{Id = 3, Name = "Silver Necklace", SubcategoryId = 2, DefaultName="Silver Necklace", DefaultDescription = "Necklace with a silver frame.", DefaultPrice = 50.00M},
            //    new ProductSeries{Id = 4, Name = "Glass Ring", SubcategoryId = 3, DefaultName="Glass Ring", DefaultDescription = "Ring made out of glass and silver.", DefaultPrice = 50.00M},
            //    new ProductSeries{Id = 5, Name = "Traditional Bag", SubcategoryId = 4, DefaultName="Traditional Bag", DefaultDescription = "Hand bag with traditional sewing pattern.", DefaultPrice = 50.00M},
            //    new ProductSeries{Id = 6, Name = "Book Binding", SubcategoryId = 5, DefaultName="Book Binding", DefaultDescription = "Book binding.", DefaultPrice = 50.00M},
            //};

            var productSeriesList = new List<ProductSeries>
            {
                new ProductSeries{Id = 1, Name = "Чанта", SubcategoryId = 1, DefaultName="Ленена чанта", DefaultDescription = "Авторска ръчно изработена чанта от лен, с ръчна бродерия и памучна подплата. Всяка чанта е уникална и няма да бъде повторена в тази комбинация от модел и шевица.", DefaultPrice = 140.00M},
                new ProductSeries{Id = 2, Name = "Несесер", SubcategoryId = 2, DefaultName="Ленен несесер ", DefaultDescription = "Авторска ръчно изработен несесер от лен, с ръчна бродерия и памучна подплата. ", DefaultPrice = 40.00M},
                new ProductSeries{Id = 3, Name = "Подвързия", SubcategoryId = 3, DefaultName="Ленена подвързия", DefaultDescription = "Авторска ръчно изработенa подвързия за книга от лен, с ръчна бродерия и памучна подплата.", DefaultPrice = 45.00M},
                new ProductSeries{Id = 4, Name = "3ка до ухо", SubcategoryId = 4, DefaultName="Обици \"Букет\"", DefaultDescription = "Ръчно изработени обеци от естествени копринени пашкули и стомана", DefaultPrice = 25.00M},
                new ProductSeries{Id = 5, Name = "Гроздове", SubcategoryId = 4, DefaultName="Обеци \"Грозд\"", DefaultDescription = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", DefaultPrice = 60.00M},
                new ProductSeries{Id = 6, Name = "Дълги", SubcategoryId = 4, DefaultName="Дълги обеци", DefaultDescription = "Ръчно изработени обеци от естествени копринени пашкули, стоманена тел, сребро и полускъпоценни камъни", DefaultPrice = 50.00M}, 
                new ProductSeries{Id = 7, Name = "На синджир", SubcategoryId = 4, DefaultName="Обеци на синджир", DefaultDescription = "Ръчно изработени обеци от естествени копринени пашкули и стомана", DefaultPrice = 25.00M}, 
                new ProductSeries{Id = 8, Name = "Тромбон", SubcategoryId = 4, DefaultName="Обеци \"Тромбон\"", DefaultDescription = "Ръчно изработени обеци от естествени копринени пашкули, посребрена тел, сребро и кристали Сваровски", DefaultPrice = 35.00M}, 
                new ProductSeries{Id = 9, Name = "Гроздове", SubcategoryId = 5, DefaultName="Колие малък \"Грозд\"", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", DefaultPrice = 50.00M}, 
                new ProductSeries{Id = 10, Name = "На обръч", SubcategoryId = 5, DefaultName="Колие на обръч \"Мак\"", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули, посребрена тел и полускъпоценни камъни", DefaultPrice = 45.00M}, 
                new ProductSeries{Id = 11, Name = "Сребро", SubcategoryId = 5, DefaultName="Сребърно колие", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", DefaultPrice = 50.00M}, 
                new ProductSeries{Id = 12, Name = "Кожа", SubcategoryId = 5, DefaultName="Колие на кожа", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули, кожа, полускъпоценни камъни и с магнитна закопчалка", DefaultPrice = 50.00M}, 
                new ProductSeries{Id = 13, Name = "Велур", SubcategoryId = 5, DefaultName="Колие на велур", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули, велур и полускъпоценни камъни", DefaultPrice = 40.00M}, 
                new ProductSeries{Id = 14, Name = "Въже", SubcategoryId = 5, DefaultName="Колие \"Венец\"", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули с магнитна закопчалка", DefaultPrice = 50.00M}, 
                new ProductSeries{Id = 15, Name = "Стомана", SubcategoryId = 5, DefaultName="Стоманено колие", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули, стомана и речни перли", DefaultPrice = 45.00M}, 
                new ProductSeries{Id = 16, Name = "Сребро", SubcategoryId = 6, DefaultName="Сребърна гривна", DefaultDescription = "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и сребро", DefaultPrice = 45.00M}, 
                new ProductSeries{Id = 17, Name = "Кожа", SubcategoryId = 6, DefaultName="Кожена гривна", DefaultDescription = "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и кожа, с магнитна закопчалка", DefaultPrice = 45.00M}, 
                new ProductSeries{Id = 18, Name = "Сребро", SubcategoryId = 7, DefaultName="Сребърен пръстен с речна перла", DefaultDescription = "Ръчно изработен пръстен от естествени копринени пашкули, сладководни перли и сребро", DefaultPrice = 35.00M}, 
                new ProductSeries{Id = 19, Name = "Стомана", SubcategoryId = 7, DefaultName="Стоманен пръстен", DefaultDescription = "Ръчно изработен пръстен от естествени копринени пашкули и стомана", DefaultPrice = 25.00M}, 
            };


            builder.Property(p => p.DefaultPrice)
                .HasPrecision(18, 2);

            builder.HasData(productSeriesList);


        }
    }
}
