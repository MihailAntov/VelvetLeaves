

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public class SubCategoryEntityConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            //old seed
            //builder.HasData(new List<Subcategory>()
            //{
            //    {new Subcategory {Name = "Earings",Id = 1, CategoryId = 1, ImageId = "64be89ae1409e5a61554e6ed"} },
            //    {new Subcategory {Name = "Necklaces",Id = 2, CategoryId = 1, ImageId = "64be8c870b7f086367ebb6a5"} },
            //    {new Subcategory {Name = "Rings",Id = 3, CategoryId = 1, ImageId = "64be8c9332b088f8d6063040"} },
            //    {new Subcategory {Name = "Bags",Id = 4, CategoryId = 2, ImageId = "64be8ca5b7f1ea12383c364a"} },
            //    {new Subcategory {Name = "Book Bindings",Id = 5, CategoryId = 2, ImageId = "64be8cb3b390e17c62039322"} }
            //});

            builder.HasData(new List<Subcategory>()
            {
                {new Subcategory {Name = "Чанти",Id = 1, CategoryId = 1, ImageId = "64d52335b30136c5a68bb051"} },
                {new Subcategory {Name = "Несесери",Id = 2, CategoryId = 1, ImageId = "64d5235bf6729604d509bc8a"} },
                {new Subcategory {Name = "Подвързии",Id = 3, CategoryId = 1, ImageId = "64d5237b623df2b2ac3fc610"} },
                {new Subcategory {Name = "Обеци",Id = 4, CategoryId = 2, ImageId = "64d5238d2acacb9e2043c933"} },
                {new Subcategory {Name = "Колиета",Id = 5, CategoryId = 2, ImageId = "64d52421cfb2a66f5536dbc6"} },
                {new Subcategory {Name = "Гривни",Id = 6, CategoryId = 2, ImageId = "64d524cb8237c4c8cab1c94d"} },
                {new Subcategory {Name = "Пръстени",Id = 7, CategoryId = 2, ImageId = "64d524fa4584a8013259e40d"} }
            });
        }
    }
}
