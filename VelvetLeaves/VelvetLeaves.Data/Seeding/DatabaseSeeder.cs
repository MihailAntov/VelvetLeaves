

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Seeding
{
    public static class DatabaseSeeder
    {
        public static void SeedDatabase(this ModelBuilder builder)
        {
            //builder.Entity<Category>().HasData(new List<Category>(){
            //    new Category { Name = "Текстил", ImageId = "64d52335b30136c5a68bb051", Id = 1 },
            //    new Category { Name = "Бижута", ImageId = "64d5238d2acacb9e2043c933", Id = 2},
            //});

            //builder.Entity<Subcategory>().HasData(new List<Subcategory>()
            //{
            //    {new Subcategory {Name = "Чанти",Id = 1, CategoryId = 1, ImageId = "64d52335b30136c5a68bb051"} },
            //    {new Subcategory {Name = "Несесери",Id = 2, CategoryId = 1, ImageId = "64d5235bf6729604d509bc8a"} },
            //    {new Subcategory {Name = "Подвързии",Id = 3, CategoryId = 1, ImageId = "64d5237b623df2b2ac3fc610"} },
            //    {new Subcategory {Name = "Обеци",Id = 4, CategoryId = 2, ImageId = "64d5238d2acacb9e2043c933"} },
            //    {new Subcategory {Name = "Колиета",Id = 5, CategoryId = 2, ImageId = "64d52421cfb2a66f5536dbc6"} },
            //    {new Subcategory {Name = "Гривни",Id = 6, CategoryId = 2, ImageId = "64d524cb8237c4c8cab1c94d"} },
            //    {new Subcategory {Name = "Пръстени",Id = 7, CategoryId = 2, ImageId = "64d524fa4584a8013259e40d"} }
            //});

            //var colorList = new List<Color>
            //{
            //    new Color {Id = 1,  ColorValue = "#d0c442", Name = "жълто"},
            //    new Color {Id = 2,  ColorValue = "#147b83", Name = "тюркоаз"},
            //    new Color {Id = 3,  ColorValue = "#d03844", Name = "червено"},
            //    new Color {Id = 4,  ColorValue = "#87cc4a", Name = "светло зелено"},
            //    new Color {Id = 5,  ColorValue = "#46761b", Name = "тъмно зелено"},
            //    new Color {Id = 6,  ColorValue = "#721cae", Name = "лилаво"},
            //    new Color {Id = 7,  ColorValue = "#154978", Name = "тъмно синьо"},
            //    new Color {Id = 8,  ColorValue = "#34b4df", Name = "светло синьо"},
            //    new Color {Id = 9,  ColorValue = "#e6c89f", Name = "шампанско"},
            //    new Color {Id = 10, ColorValue = "#d8748c", Name = "розово"},
            //    new Color {Id = 11, ColorValue = "#f0eddc", Name = "бяло"},
            //    new Color {Id = 12, ColorValue = "#961243", Name = "циклама"},
            //    new Color {Id = 13, ColorValue = "#904236", Name = "кафяво"},
            //    new Color {Id = 14, ColorValue = "#000000", Name = "черно"},
            //    new Color {Id = 15, ColorValue = "#fe7612", Name = "оранжево"},
            //};

            //builder.Entity<Color>().HasData(colorList);

            //var tagList = new List<Tag>
            //{
            //    //old seed
            //    //new Tag {Id = 1, Name = "Traditional Sewing Pattern"},
            //    //new Tag {Id = 2, Name = "Silk Cocoons"}

                

            //    new Tag {Id = 1, Name = "Мак"},
            //    new Tag {Id = 2, Name = "Цели пашкули"},
            //    new Tag {Id = 3, Name = "Дълги"}
            //};

            //builder.Entity<Tag>().HasData(tagList);

            //var materialList = new List<Material>
            //{
            //    //old seed
            //    //new Material {Id = 1, Name = "Silver"},
            //    //new Material {Id = 2, Name = "Steel"},
            //    //new Material {Id = 3, Name = "Glass"},
            //    //new Material {Id = 4, Name = "Textile"}


            //    new Material {Id = 1, Name = "Лен"},
            //    new Material {Id = 2, Name = "Памук"},
            //    new Material {Id = 3, Name = "Стомана"},
            //    new Material {Id = 4, Name = "Сребро"},
            //    new Material {Id = 5, Name = "Полускъпоценни камъни"},
            //    new Material {Id = 6, Name = "Кристали Сваровски"},
            //    new Material {Id = 8, Name = "Естествени копринени пашкули"},
            //    new Material {Id = 9, Name = "Посребрена тел"},
            //    new Material {Id = 10, Name = "Кожа"},
            //    new Material {Id = 11, Name = "Стоманена магнитна закопчалка"},
            //    new Material {Id = 12, Name = "Велур"},
            //    new Material {Id = 13, Name = "Дърво"},
            //    new Material {Id = 14, Name = "Речни перли"}


            //};
            //builder.Entity<Material>().HasData(materialList);

            //var productSeriesList = new List<ProductSeries>
            //{
            //    new ProductSeries{Id = 1, Name = "Чанта", SubcategoryId = 1, DefaultName="Ленена чанта", DefaultDescription = "Авторска ръчно изработена чанта от лен, с ръчна бродерия и памучна подплата. Всяка чанта е уникална и няма да бъде повторена в тази комбинация от модел и шевица.", DefaultPrice = 140.00M},
            //    new ProductSeries{Id = 2, Name = "Несесер", SubcategoryId = 2, DefaultName="Ленен несесер ", DefaultDescription = "Авторска ръчно изработен несесер от лен, с ръчна бродерия и памучна подплата. ", DefaultPrice = 40.00M},
            //    new ProductSeries{Id = 3, Name = "Подвързия", SubcategoryId = 3, DefaultName="Ленена подвързия", DefaultDescription = "Авторска ръчно изработенa подвързия за книга от лен, с ръчна бродерия и памучна подплата.", DefaultPrice = 45.00M},
            //    new ProductSeries{Id = 4, Name = "3ка до ухо", SubcategoryId = 4, DefaultName="Обици \"Букет\"", DefaultDescription = "Ръчно изработени обеци от естествени копринени пашкули и стомана", DefaultPrice = 25.00M},
            //    new ProductSeries{Id = 5, Name = "Гроздове", SubcategoryId = 4, DefaultName="Обеци \"Грозд\"", DefaultDescription = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", DefaultPrice = 60.00M},
            //    new ProductSeries{Id = 6, Name = "Дълги", SubcategoryId = 4, DefaultName="Дълги обеци", DefaultDescription = "Ръчно изработени обеци от естествени копринени пашкули, стоманена тел, сребро и полускъпоценни камъни", DefaultPrice = 50.00M},
            //    new ProductSeries{Id = 7, Name = "На синджир", SubcategoryId = 4, DefaultName="Обеци на синджир", DefaultDescription = "Ръчно изработени обеци от естествени копринени пашкули и стомана", DefaultPrice = 25.00M},
            //    new ProductSeries{Id = 8, Name = "Тромбон", SubcategoryId = 4, DefaultName="Обеци \"Тромбон\"", DefaultDescription = "Ръчно изработени обеци от естествени копринени пашкули, посребрена тел, сребро и кристали Сваровски", DefaultPrice = 35.00M},
            //    new ProductSeries{Id = 9, Name = "Гроздове", SubcategoryId = 5, DefaultName="Колие малък \"Грозд\"", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", DefaultPrice = 50.00M},
            //    new ProductSeries{Id = 10, Name = "На обръч", SubcategoryId = 5, DefaultName="Колие на обръч \"Мак\"", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули, посребрена тел и полускъпоценни камъни", DefaultPrice = 45.00M},
            //    new ProductSeries{Id = 11, Name = "Сребро", SubcategoryId = 5, DefaultName="Сребърно колие", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", DefaultPrice = 50.00M},
            //    new ProductSeries{Id = 12, Name = "Кожа", SubcategoryId = 5, DefaultName="Колие на кожа", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули, кожа, полускъпоценни камъни и с магнитна закопчалка", DefaultPrice = 50.00M},
            //    new ProductSeries{Id = 13, Name = "Велур", SubcategoryId = 5, DefaultName="Колие на велур", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули, велур и полускъпоценни камъни", DefaultPrice = 40.00M},
            //    new ProductSeries{Id = 14, Name = "Въже", SubcategoryId = 5, DefaultName="Колие \"Венец\"", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули с магнитна закопчалка", DefaultPrice = 50.00M},
            //    new ProductSeries{Id = 15, Name = "Стомана", SubcategoryId = 5, DefaultName="Стоманено колие", DefaultDescription = "Ръчно изработено колие от естествени копринени пашкули, стомана и речни перли", DefaultPrice = 45.00M},
            //    new ProductSeries{Id = 16, Name = "Сребро", SubcategoryId = 6, DefaultName="Сребърна гривна", DefaultDescription = "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и сребро", DefaultPrice = 45.00M},
            //    new ProductSeries{Id = 17, Name = "Кожа", SubcategoryId = 6, DefaultName="Кожена гривна", DefaultDescription = "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и кожа, с магнитна закопчалка", DefaultPrice = 45.00M},
            //    new ProductSeries{Id = 18, Name = "Сребро", SubcategoryId = 7, DefaultName="Сребърен пръстен с речна перла", DefaultDescription = "Ръчно изработен пръстен от естествени копринени пашкули, сладководни перли и сребро", DefaultPrice = 35.00M},
            //    new ProductSeries{Id = 19, Name = "Стомана", SubcategoryId = 7, DefaultName="Стоманен пръстен", DefaultDescription = "Ръчно изработен пръстен от естествени копринени пашкули и стомана", DefaultPrice = 25.00M},
            //};

            //builder.Entity<ProductSeries>().HasData(productSeriesList);

            //var imageList = new List<Image>
            //{
            //    //old seed : 
            //    //new Image {Id = "64be89ae1409e5a61554e6ed", ProductId = 1},
            //    //new Image {Id = "64be8c68cac3fdf11a06fbbb", ProductId = 1},
            //    //new Image {Id = "64be8c6df878c3764a814981", ProductId = 1},
            //    //new Image {Id = "64be8c733df251037e15d70a", ProductId = 2},
            //    //new Image {Id = "64be8c7a0ef21ca57c247498", ProductId = 2},
            //    //new Image {Id = "64be8c813d909293463359d6", ProductId = 2},
            //    //new Image {Id = "64be8c870b7f086367ebb6a5", ProductId = 3},
            //    //new Image {Id = "64be8c8d7d5c466b820b73af", ProductId = 3},
            //    //new Image {Id = "64be8c9332b088f8d6063040", ProductId = 4},
            //    //new Image {Id = "64be8c99f991d074063b5098", ProductId = 4},
            //    //new Image {Id = "64be8c9f41c19cda7ab19853", ProductId = 5},
            //    //new Image {Id = "64be8ca5b7f1ea12383c364a", ProductId = 5},
            //    //new Image {Id = "64be8caa293917f47210277e", ProductId = 6},
            //    //new Image {Id = "64be8cae1813d7aff61e173b", ProductId = 6},
            //    //new Image {Id = "64be8cb3b390e17c62039322", ProductId = 7},
            //    //new Image {Id = "64be8cb81a39dd6ed0351ebb", ProductId = 7}
            //    //end of old seed: 
            //    //Текстил
            //        //чанти
            //            //ленена чанта
            //                //слънце
                       
            //                new Image {Id = "64d52335b30136c5a68bb051", ProductId = 1},
            //                new Image {Id = "64d52338464ff67d85ff46a5", ProductId = 1},
            //                new Image {Id = "64d5233c720097ef9dffa9ab", ProductId = 1},
            //                new Image {Id = "64d523401c23834259ea6b65", ProductId = 1},
            //                new Image {Id = "64d52343c1a58e96abb5c206", ProductId = 1},
            //                //синева
                            
            //                new Image {Id = "64d5234f5a69fa9f747e5f18", ProductId = 2},
            //                new Image {Id = "64d5234ce3785f17243b411c", ProductId = 2},
            //                new Image {Id = "64d52349d406df65ce4b4e72", ProductId = 2},
            //                new Image {Id = "64d523475af695148db6b205", ProductId = 2},

            //        //несесери
            //            //ленен несесер
            //                //ленен несесер
                            
            //                new Image {Id = "64d5235bf6729604d509bc8a", ProductId = 3},
            //                new Image {Id = "64d52359322458a957d81660", ProductId = 3},
            //                new Image {Id = "64d523565b62f7aaf0663a98", ProductId = 3},
            //                new Image {Id = "64d5235287a0f3693212c2a1", ProductId = 3},
            //                //ленен несесер
                            
            //                new Image {Id = "64d5236abb6d8a6883aea6a5", ProductId = 4},
            //                new Image {Id = "64d52366fb8d548ef1e6a1cb", ProductId = 4},
            //                new Image {Id = "64d52362ecdfe6871993e1e4", ProductId = 4},
            //                new Image {Id = "64d5235f274fb0fcf347d1b3", ProductId = 4},
            //        //подвързии
            //            //ленена подвързия
            //                //ленена подвързия за книга
                            
            //                new Image {Id = "64d5237b623df2b2ac3fc610", ProductId = 5},
            //                new Image {Id = "64d523760ebe3629aa66effc", ProductId = 5},
            //                new Image {Id = "64d52372fe1c9b730442e805", ProductId = 5},
            //                new Image {Id = "64d5236e334387ef86d99937", ProductId = 5},
            //                //ленена подвързия за Kindle
                            
            //                new Image {Id = "64d5237ebfa052d5f7b7e3cb", ProductId = 6},
            //                new Image {Id = "64d52385751a53bf32894fb4", ProductId = 6},
            //                new Image {Id = "64d52381a7064dcc1dd461d5", ProductId = 6},
            //                new Image {Id = "64d5238841449e1eef8fc29a", ProductId = 6},
            //    //Бижута
            //        //обеци
            //            //3ка до ухо
            //                //червени
                            
            //                new Image {Id = "64d5238d2acacb9e2043c933", ProductId = 7},
            //                new Image {Id = "64d52392f6a5f8843a780460", ProductId = 7},
            //                new Image {Id = "64d523961f6d033d54da856e", ProductId = 7},
            //                //жълти
                           
            //                new Image {Id = "64d5239a46383aa6559ff15e", ProductId = 8},
            //                new Image {Id = "64d5239dfb4154fc78c1b5f2", ProductId = 8},
            //                new Image {Id = "64d523a091c723288ab2703f", ProductId = 8},
            //            //гроздове
            //                //шампанско
                            
            //                new Image {Id = "64d523a27541d354f5185ecf", ProductId = 9},
            //                new Image {Id = "64d523a54482b6933b4b9641", ProductId = 9},
            //                new Image {Id = "64d523a8417674952ae911aa", ProductId = 9},
            //                //сини
                          
            //                new Image {Id = "64d523ac76b19d54b131024b", ProductId = 10},
            //                new Image {Id = "64d523af7736cd67efd18bca", ProductId = 10},
            //                new Image {Id = "64d523b1a82f8b465badccfe", ProductId = 10},
            //                new Image {Id = "64d523b4aaae78c1fb2e0f19", ProductId = 10},
            //                //лилави
                          
            //                new Image {Id = "64d523c837c5cbc84815c6b2", ProductId = 11},
            //                new Image {Id = "64d523cbc940befd0ef0bbea", ProductId = 11},
            //                //жълти
                            
            //                new Image {Id = "64d523ceda1ac0b8527ffd26", ProductId = 12},
            //                new Image {Id = "64d523d1c01dda3483251e4c", ProductId = 12},
            //                //розови
                            
            //                new Image {Id = "64d523d49319f1ab11955ee0", ProductId = 13},
            //                new Image {Id = "64d523e02eab219eca427579", ProductId = 13},
            //                new Image {Id = "64d523e30dd3878eccd3ea1e", ProductId = 13},
            //                //жълти
                            
            //                new Image {Id = "64d523e7d30950cc175d4ee5", ProductId = 14},
            //                new Image {Id = "64d523e985893af2853dbaa4", ProductId = 14},
            //                new Image {Id = "64d523ed880a2cfea4e5a29a", ProductId = 14},
            //            //дълги
            //                //зелено
                          
            //                new Image {Id = "64d523f115f347b097321f2a", ProductId = 15},
            //                new Image {Id = "64d523f45251d2a11816195f", ProductId = 15},
            //                new Image {Id = "64d523f7a6a8571b3eb12359", ProductId = 15},
            //                //сакура
                           
            //                new Image {Id = "64d523fabe152a47636bae7d", ProductId = 16},
            //                new Image {Id = "64d523fdeb4444d63ab86a55", ProductId = 16},
            //                new Image {Id = "64d523ff4215c2646cc8163e", ProductId = 16},
            //            //на синджир
            //                //червени
                           
            //                new Image {Id = "64d524022c22a7bf5d6fb592", ProductId = 17},
            //                new Image {Id = "64d52405dd648aaccb6de56f", ProductId = 17},
            //                new Image {Id = "64d524084074dd02c95d5612", ProductId = 17},
            //                //бронз
                            
            //                new Image {Id = "64d5240c0d0a9f46840215f4", ProductId = 18},
            //                new Image {Id = "64d5240f1f6a4bf88ff5fe28", ProductId = 18},
            //                new Image {Id = "64d52413ca2cdb86d5dc5061", ProductId = 18},
            //            //тромбон
            //                //тромбон
                           
            //                new Image {Id = "64d5241605cdc65069fb4e7c", ProductId = 19},
            //                new Image {Id = "64d524194292962f1698b35d", ProductId = 19},
            //                new Image {Id = "64d5241b4efab879d2b98106", ProductId = 19},
            //                new Image {Id = "64d5241ec70acdc88d85b2cf", ProductId = 19},
            //        //колиета
            //            //гроздове
            //                //жълто
                           
            //                new Image {Id = "64d52421cfb2a66f5536dbc6", ProductId = 20},
            //                new Image {Id = "64d5242462bf6e246eef6de5", ProductId = 20},
            //                new Image {Id = "64d5242760c55c37a36657d8", ProductId = 20},
            //                //розово
                           
            //                new Image {Id = "64d5242b9278a4b37dcc630b", ProductId = 21},
            //                new Image {Id = "64d5242e5935e047dede6793", ProductId = 21},
            //                new Image {Id = "64d524315e7d9e628e279e40", ProductId = 21},
            //            //на обръч
            //                //червен
                            
            //                new Image {Id = "64d52434e25395fb8679db94", ProductId = 22},
            //                new Image {Id = "64d5243d1a39817b5412e11d", ProductId = 22},
            //                new Image {Id = "64d524415910ab1c2728156e", ProductId = 22},
            //                //зелен
                            
            //                new Image {Id = "64d524457ff5157cd75d74b1", ProductId = 23},
            //                new Image {Id = "64d52448f4eb7a0a7f25a51a", ProductId = 23},
            //                new Image {Id = "64d5244a9e32fb59f283d635", ProductId = 23},
            //            //сребро
            //                //сребърно колие
                            
            //                new Image {Id = "64d52455958cb65afbfd6ae8", ProductId = 24},
            //                new Image {Id = "64d5245377429792e179d3bf", ProductId = 24},
            //                new Image {Id = "64d524501bda417d5761bfca", ProductId = 24},
            //                new Image {Id = "64d5244e355f07301da86f9d", ProductId = 24},
            //                //сребърно колие
                           
            //                new Image {Id = "64d52464dac819b2d0d9651a", ProductId = 25},
            //                new Image {Id = "64d52461873681ea5d64d875", ProductId = 25},
            //                new Image {Id = "64d5245e9b617cd236346b63", ProductId = 25},
            //                new Image {Id = "64d5245b5f00130edb99f651", ProductId = 25},
            //            //кожа
            //                //зелено
                            
            //                new Image {Id = "64d52468d463b9450c90da10", ProductId = 26},
            //                new Image {Id = "64d5246c78ebed5232e6790b", ProductId = 26},
            //                //червено
                            
            //                new Image {Id = "64d5246f1c85d65d8278ed46", ProductId = 27},
            //                new Image {Id = "64d52471ba01308173853a57", ProductId = 27},
            //                //колие на кожа с цветя
                           
            //                new Image {Id = "64d524758723c98b4517d0e4", ProductId = 28},
            //                new Image {Id = "64d52477d20e0caee58a1b13", ProductId = 28},
            //            //велур
            //                //лилаво
                            
            //                new Image {Id = "64d52479338c4bae74412ae2", ProductId = 29},
            //                new Image {Id = "64d5247d00dfdad417f95d9a", ProductId = 29},
            //                new Image {Id = "64d5247fce219f6b15944ce6", ProductId = 29},
            //                //синьо-лилаво
                           
            //                new Image {Id = "64d5249591db48402680da4f", ProductId = 30},
            //                new Image {Id = "64d524983f05edf1b19fbfcf", ProductId = 30},
            //                new Image {Id = "64d5249cf2a4faf6783dcba7", ProductId = 30},
            //                //оранжево
                           
            //                new Image {Id = "64d5249fbd5f98393548eaf3", ProductId = 31},
            //                new Image {Id = "64d524a14f2def8ce5fe2053", ProductId = 31},
            //                new Image {Id = "64d524a4d08826759b124b81", ProductId = 31},
            //                //тюркоаз
                           
            //                new Image {Id = "64d52481af9cd319228bc03e", ProductId = 32},
            //                new Image {Id = "64d524848355e8e0ca5c7c64", ProductId = 32},
            //                //черно-бяло
                            
            //                new Image {Id = "64d52490c7197f5948d686e0", ProductId = 33},
            //                new Image {Id = "64d5248ef11f97cf0d936c79", ProductId = 33},
            //                new Image {Id = "64d524894f0d449e6e7f0be5", ProductId = 33},
            //            //въже
            //                //жълто-синьо
                           
            //                new Image {Id = "64d524b586fa7d40023defa1", ProductId = 34},
            //                new Image {Id = "64d524b05db296b5147b774a", ProductId = 34},
            //                new Image {Id = "64d524ace356ce0f5b5e84c6", ProductId = 34},
            //                new Image {Id = "64d524a8a106e8030a0f5810", ProductId = 34},
            //                //пролет
                            
            //                new Image {Id = "64d524b9579b4b54285e15ed", ProductId = 35},
            //                new Image {Id = "64d524bc9c0bf598bdbe9551", ProductId = 35},
            //                new Image {Id = "64d524bf2b882738a30506c5", ProductId = 35},
            //            //стомана
            //                //листо
                            
            //                new Image {Id = "64d524c23a6c7f3087010b63", ProductId = 36},
            //                new Image {Id = "64d524c58d113c6f7108c444", ProductId = 36},
            //                new Image {Id = "64d524c8d973ed6ecd116daf", ProductId = 36},
            //        //гривни
            //            //сребро
            //                //розова
            //                new Image {Id = "64d524cb8237c4c8cab1c94d", ProductId = 37},
            //                //жълта
            //                new Image {Id = "64d524ce181e34c33340dd05", ProductId = 38},
            //            //кожа
            //                //зелена
                           
            //                new Image {Id = "64d524d23b4f7df4df352f9f", ProductId = 39},
            //                new Image {Id = "64d524d540e46b0cea6cc523", ProductId = 39},
            //                new Image {Id = "64d524d99bb7990b020777b9", ProductId = 39},
            //                new Image {Id = "64d524db4c9f4a9647db7009", ProductId = 39},
            //                //синьо-жълта 
                          
            //                new Image {Id = "64d524de44d6b9ac55e41954", ProductId = 40},
            //                new Image {Id = "64d524e1def6a193ed8df8f6", ProductId = 40},
            //                new Image {Id = "64d524e404b5bd7f13be1c5b", ProductId = 40},
            //                new Image {Id = "64d524e80992abcef8352a65", ProductId = 40},
            //                new Image {Id = "64d524ebc6f3675710bbd9dd", ProductId = 40},
            //        //пръстени
            //            //сребро
            //                //бял
                           
            //                new Image {Id = "64d524fa4584a8013259e40d", ProductId = 41},
            //                new Image {Id = "64d52504405b952082fb05d1", ProductId = 41},
            //                new Image {Id = "64d52507173da7d7420d2657", ProductId = 41},
            //                new Image {Id = "64d5250a13661437bd07c952", ProductId = 41},
            //                //син
                           
            //                new Image {Id = "64d5250e6b4ba5e401ed0500", ProductId = 42},
            //                new Image {Id = "64d52512e2aa2cc2c81f5b6e", ProductId = 42},
            //                new Image {Id = "64d52515302802a83f0af2e0", ProductId = 42},
            //            //стомана
            //                //мак
                           
            //                new Image {Id = "64d5251be13c2530fda92d19", ProductId = 43},
            //                new Image {Id = "64d5251e9c3ab859c753c597", ProductId = 43},
            //                new Image {Id = "64d52521e58195d2403b6e15", ProductId = 43},
            //                //жълт
                           
            //                new Image {Id = "64d5252751ecfe48e09e1f15", ProductId = 44},
            //                new Image {Id = "64d5252abf960bb7827bb75b", ProductId = 44},
            //                new Image {Id = "64d5252d8c5ead2168fbd1cb", ProductId = 44},
            //                new Image {Id = "64d525319813433aa6afe1ac", ProductId = 44},
            //};


            //builder.Entity<Image>().HasData(imageList);


            //var galleryList = new List<Gallery>
            //{
            //    new Gallery {Id = 1, Name = "Гроздове",Description = "Колиета и обеци от серия \"Грозд\"",ImageId="64d523b1a82f8b465badccfe"},
            //    new Gallery {Id = 2, Name = "Макове",Description = "Бижута от серия \"Мак\"",ImageId="64d524415910ab1c2728156e"},
            //    new Gallery {Id = 3, Name = "Нова колекция",Description = "Разгледайте новите ни предложения",ImageId="64d5241b4efab879d2b98106"}
            //};

            //builder.Entity<Gallery>()
            //    .HasData(galleryList);

            ////old seed
            ////var galleryProductList = new List<GalleryProduct>
            ////{
            ////    new GalleryProduct {GalleryId = 1, ProductId = 1, Position = 1},
            ////    new GalleryProduct {GalleryId = 1, ProductId = 2, Position = 2},
            ////    new GalleryProduct {GalleryId = 1, ProductId = 3, Position = 3},
            ////    new GalleryProduct {GalleryId = 2, ProductId = 4, Position = 1}
            ////};

            //var galleryProductList = new List<GalleryProduct>
            //{
            //    new GalleryProduct {GalleryId = 1, ProductId = 9, Position = 1},
            //    new GalleryProduct {GalleryId = 1, ProductId = 10, Position = 2},
            //    new GalleryProduct {GalleryId = 1, ProductId = 11, Position = 3},
            //    new GalleryProduct {GalleryId = 1, ProductId = 12, Position = 4},
            //    new GalleryProduct {GalleryId = 1, ProductId = 13, Position = 5},
            //    new GalleryProduct {GalleryId = 1, ProductId = 20, Position = 6},
            //    new GalleryProduct {GalleryId = 2, ProductId = 22, Position = 1},
            //    new GalleryProduct {GalleryId = 2, ProductId = 23, Position = 2},
            //    new GalleryProduct {GalleryId = 2, ProductId = 43, Position = 3},
            //    new GalleryProduct {GalleryId = 3, ProductId = 19, Position = 1},
            //    new GalleryProduct {GalleryId = 3, ProductId = 34, Position = 2},
            //    new GalleryProduct {GalleryId = 3, ProductId = 35, Position = 3},
            //    new GalleryProduct {GalleryId = 3, ProductId = 36, Position = 4}
            //};

            //builder.Entity<GalleryProduct>()
            //    .HasData(galleryProductList);

            //var hasher = new PasswordHasher<ApplicationUser>();

            //var user = new ApplicationUser
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    UserName = "user@vls.com",
            //    NormalizedUserName = "USER@VLS.COM",
            //    Email = "user@vls.com",
            //    NormalizedEmail = "USER@VLS.COM",
            //};
            //user.PasswordHash = hasher.HashPassword(user, "123456");

            //var moderator = new ApplicationUser
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    UserName = "moderator@vls.com",
            //    NormalizedUserName = "MODERATOR@VLS.COM",
            //    Email = "moderator@vls.com",
            //    NormalizedEmail = "MODERATOR@VLS.COM",
            //};
            //moderator.PasswordHash = hasher.HashPassword(moderator, "123456");

            

            //builder.Entity<ApplicationUser>()
            //    .HasData(new List<ApplicationUser> { user, moderator });


            ////old seed
            ////var productList = new List<Product> {
            ////    new Product {Id = 1, Name = "Red Silver Earrings", Description = "Red earrings with silver frames.", SubcategoryId = 1, Price = 50.00M, ProductSeriesId = 1 }, 
            ////    new Product {Id = 2, Name = "Red-Blue Steel Earrings", Description = "Red-blue earrings with steel frames.", SubcategoryId = 1, Price = 45.00M, ProductSeriesId = 2 }, 
            ////    new Product {Id = 3, Name = "Green Silver Necklace", Description = "Green necklace with a silver frame.", SubcategoryId = 2, Price = 35.00M, ProductSeriesId = 3 }, 
            ////    new Product {Id = 4, Name = "Blue Glass Ring", Description = "Blue ring made out of glass and silver.", SubcategoryId = 3 , Price = 25.00M, ProductSeriesId = 4 }, 
            ////    new Product {Id = 5, Name = "Traditional Hand Bag", Description = "Hand bag with traditional sewing pattern.", SubcategoryId = 4, Price = 120.00M, ProductSeriesId = 5 }, 
            ////    new Product {Id = 6, Name = "Traditional Hand Bag", Description = "Hand bag with traditional sewing pattern.", SubcategoryId = 4, Price = 120.00M, ProductSeriesId = 5 }, 
            ////    new Product {Id = 7, Name = "Blue Book Binding", Description = "Blue book binding.", SubcategoryId = 5, Price = 70.00M, ProductSeriesId = 6 }, 
            ////};

            //var productList = new List<Product> {
            //    new Product {Id = 1, Name = "Ленена чанта \"Слънце\"",  Description = "Авторска ръчно изработена чанта от лен, с ръчна бродерия и памучна подплата. Всяка чанта е уникална и няма да бъде повторена в тази комбинация от модел и шевица.", SubcategoryId = 1, Price = 140.00M, ProductSeriesId = 1 },
            //    new Product {Id = 2, Name = "Ленена чанта \" Синева\"", Description = "Авторска ръчно изработена чанта от лен, с ръчна бродерия и памучна подплата. Всяка чанта е уникална и няма да бъде повторена в тази комбинация от модел и шевица.", SubcategoryId = 1, Price = 150.00M, ProductSeriesId = 1 },
            //    new Product {Id = 3, Name = "Ленен несесер ",           Description = "Авторски ръчно изработен несесер от лен, с ръчна бродерия и памучна подплата. ", SubcategoryId = 2, Price = 40.00M, ProductSeriesId = 2 },
            //    new Product {Id = 4, Name = "Ленен несесер ",           Description = "Авторски ръчно изработен несесер от лен, с ръчна бродерия и памучна подплата. ", SubcategoryId = 2, Price = 40.00M, ProductSeriesId = 2 },
            //    new Product {Id = 5, Name = "Ленена подвързия за книга", Description = "Авторска ръчно изработенa подвързия за книга от лен, с ръчна бродерия и памучна подплата.", SubcategoryId = 3, Price = 45.00M, ProductSeriesId = 3 },
            //    new Product {Id = 6, Name = "Ленена подвързия за Kindle", Description = "Авторска ръчно изработенa подвързия за електронна книга от лен, с ръчна бродерия и памучна подплата. ", SubcategoryId = 3, Price = 45.00M, ProductSeriesId = 3 },
            //    new Product {Id = 7, Name = "Обици \"Букет\"",          Description = "Ръчно изработени обеци от естествени копринени пашкули и стомана", SubcategoryId = 4, Price = 25.00M, ProductSeriesId = 4 },
            //    new Product {Id = 8, Name = "Обици \"Букет\"",          Description = "Ръчно изработени обеци от естествени копринени пашкули и стомана", SubcategoryId = 4, Price = 25.00M, ProductSeriesId = 4 },
            //    new Product {Id = 9, Name = "Големи обеци \"Грозд\"",   Description = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 4, Price = 60.00M, ProductSeriesId = 5 },
            //    new Product {Id = 10, Name = "Големи обеци \"Грозд\"", Description = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 4, Price = 60.00M, ProductSeriesId = 5 },
            //    new Product {Id = 11, Name = "Средни обеци \"Грозд\"", Description = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 4, Price = 60.00M, ProductSeriesId = 5 },
            //    new Product {Id = 12, Name = "Средни обеци \"Грозд\"", Description = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 4, Price = 60.00M, ProductSeriesId = 5 },
            //    new Product {Id = 13, Name = "Малки обеци \"Грозд\"",   Description = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 4, Price = 35.00M, ProductSeriesId = 5 },
            //    new Product {Id = 14, Name = "Малки обеци \"Грозд\" ", Description = "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 4, Price = 35.00M, ProductSeriesId = 5 },
            //    new Product {Id = 15, Name = "Дълги обеци",             Description = "Ръчно изработени обеци от естествени копринени пашкули, стоманена тел, сребро и полускъпоценни камъни", SubcategoryId = 4, Price = 50.00M, ProductSeriesId = 6 },
            //    new Product {Id = 16, Name = "Дълги обеци",             Description = "Ръчно изработени обеци от естествени копринени пашкули, стоманена тел, сребро и полускъпоценни камъни", SubcategoryId = 4, Price = 50.00M, ProductSeriesId = 6 },
            //    new Product {Id = 17, Name = "Обеци на синджир",        Description = "Ръчно изработени обеци от естествени копринени пашкули и стомана", SubcategoryId = 4, Price = 25.00M, ProductSeriesId = 7 },
            //    new Product {Id = 18, Name = "Обеци на синджир",        Description = "Ръчно изработени обеци от естествени копринени пашкули и стомана", SubcategoryId = 4, Price = 25.00M, ProductSeriesId = 7 },
            //    new Product {Id = 19, Name = "Обеци \"Тромбон\"",       Description = "Ръчно изработени обеци от естествени копринени пашкули, посребрена тел, сребро и кристали Сваровски", SubcategoryId = 4, Price = 35.00M, ProductSeriesId = 8 },
            //    new Product {Id = 20, Name = "Колие малък \"Грозд\"",   Description = "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 5, Price = 50.00M, ProductSeriesId = 9 },
            //    new Product {Id = 21, Name = "Колие малък \"Грозд\"",   Description = "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 5, Price = 50.00M, ProductSeriesId = 9 },
            //    new Product {Id = 22, Name = "Колие на обръч \"Мак\"",  Description = "Ръчно изработено колие от естествени копринени пашкули, посребрена тел и полускъпоценни камъни", SubcategoryId = 5, Price = 45.00M, ProductSeriesId = 10 },
            //    new Product {Id = 23, Name = "Колие на обръч \"Мак\"",  Description = "Ръчно изработено колие от естествени копринени пашкули, посребрена тел и полускъпоценни камъни", SubcategoryId = 5, Price = 45.00M, ProductSeriesId = 10 },
            //    new Product {Id = 24, Name = "Сребърно колие",          Description = "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 5, Price = 50.00M, ProductSeriesId = 11 },
            //    new Product {Id = 25, Name = "Сребърно колие",          Description = "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", SubcategoryId = 5, Price = 50.00M, ProductSeriesId = 11 },
            //    new Product {Id = 26, Name = "Колие на кожа с цели пашкули", Description = "Ръчно изработено колие от естествени копринени пашкули, кожа, полускъпоценни камъни и с магнитна закопчалка", SubcategoryId = 5, Price = 50.00M, ProductSeriesId = 12 },
            //    new Product {Id = 27, Name = "Колие на кожа с цели пашкули", Description = "Ръчно изработено колие от естествени копринени пашкули, кожа, полускъпоценни камъни и с магнитна закопчалка", SubcategoryId = 5, Price = 50.00M, ProductSeriesId = 12 },
            //    new Product {Id = 28, Name = "Колие на кожа с цветя", Description = "Ръчно изработено колие от естествени копринени пашкули, кожа, полускъпоценни камъни и с магнитна закопчалка", SubcategoryId = 5, Price = 50.00M, ProductSeriesId = 12 },
            //    new Product {Id = 29, Name = "Колие на велур с цветя", Description = "Ръчно изработено колие от естествени копринени пашкули, велур, ръчно изработен дървен елемент от орех, и полускъпоценни камъни", SubcategoryId = 5, Price = 35.00M, ProductSeriesId = 13 },
            //    new Product {Id = 30, Name = "Колие на велур с цели пашкули", Description = "Ръчно изработено колие от естествени копринени пашкули, велур и полускъпоценни камъни", SubcategoryId = 5, Price = 40.00M, ProductSeriesId = 13 },
            //    new Product {Id = 31, Name = "Колие на велур с цели пашкули", Description = "Ръчно изработено колие от естествени копринени пашкули, велур и полускъпоценни камъни", SubcategoryId = 5, Price = 40.00M, ProductSeriesId = 13 },
            //    new Product {Id = 32, Name = "Колие на велур с цветя", Description = "Ръчно изработено колие от естествени копринени пашкули, велур и полускъпоценни камъни", SubcategoryId = 5, Price = 35.00M, ProductSeriesId = 13 },
            //    new Product {Id = 33, Name = "Колие на велур с цветя", Description = "Ръчно изработено колие от естествени копринени пашкули, велур, ръчно изработен дървен елемент от орех, и полускъпоценни камъни", SubcategoryId = 5, Price = 35.00M, ProductSeriesId = 13 },
            //    new Product {Id = 34, Name = "Колие \"Венец\"",         Description = "Ръчно изработено колие от естествени копринени пашкули с магнитна закопчалка", SubcategoryId = 5, Price = 50.00M, ProductSeriesId = 14 },
            //    new Product {Id = 35, Name = "Колие \"Венец\"",         Description = "Ръчно изработено колие от естествени копринени пашкули с магнитна закопчалка", SubcategoryId = 5, Price = 50.00M, ProductSeriesId = 14 },
            //    new Product {Id = 36, Name = "Стоманено колие",         Description = "Ръчно изработено колие от естествени копринени пашкули, стомана и речни перли", SubcategoryId = 5, Price = 45.00M, ProductSeriesId = 15 },
            //    new Product {Id = 37, Name = "Сребърна гривна",         Description = "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и сребро", SubcategoryId = 6, Price = 45.00M, ProductSeriesId = 16 },
            //    new Product {Id = 38, Name = "Сребърна гривна",         Description = "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и сребро", SubcategoryId = 6, Price = 45.00M, ProductSeriesId = 16 },
            //    new Product {Id = 39, Name = "Кожена гривна",           Description = "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и кожа, с магнитна закопчалка", SubcategoryId = 6, Price = 45.00M, ProductSeriesId = 17 },
            //    new Product {Id = 40, Name = "Кожена гривна",           Description = "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и кожа, с магнитна закопчалка", SubcategoryId = 6, Price = 45.00M, ProductSeriesId = 17 },
            //    new Product {Id = 41, Name = "Сребърен пръстен с речна перла", Description = "Ръчно изработен пръстен от естествени копринени пашкули, сладководни перли и сребро", SubcategoryId = 7, Price = 35.00M, ProductSeriesId = 18 },
            //    new Product {Id = 42, Name = "Сребърен пръстен с речна перла", Description = "Ръчно изработен пръстен от естествени копринени пашкули, сладководни перли и сребро", SubcategoryId = 7, Price = 35.00M, ProductSeriesId = 18 },
            //    new Product {Id = 43, Name = "Стоманен пръстен",        Description = "Ръчно изработен пръстен от естествени копринени пашкули и стомана", SubcategoryId = 7, Price = 25.00M, ProductSeriesId = 19 },
            //    new Product {Id = 44, Name = "Стоманен пръстен",        Description = "Ръчно изработен пръстен от естествени копринени пашкули и стомана", SubcategoryId = 7, Price = 25.00M, ProductSeriesId = 19 }

            //};


            //builder.Entity<Product>().HasData(productList);

            //builder.Entity<Tag>()
            //   .HasMany(c => c.ProductSeries)
            //   .WithMany(p => p.DefaultTags)
            //   .UsingEntity<Dictionary<string, object>>("ProductsSeriesTags",
            //   r => r.HasOne<ProductSeries>().WithMany().HasForeignKey("ProductSeriesId"),
            //       l => l.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
            //       mt =>
            //       {
            //           {

            //               mt.HasData(
            //                   new { ProductSeriesId = 6, TagId = 3 });
            //           }
            //       });


            //builder.Entity<Material>()
            //    .HasMany(c => c.ProductSeries)
            //    .WithMany(p => p.DefaultMaterials)
            //    .UsingEntity<Dictionary<string, object>>("ProductsSeriesMaterials",
            //    r => r.HasOne<ProductSeries>().WithMany().HasForeignKey("ProductSeriesId"),
            //        l => l.HasOne<Material>().WithMany().HasForeignKey("MaterialId"),
            //        mt =>
            //        {
            //            mt.HasKey("ProductSeriesId", "MaterialId");

                       


            //                mt.HasData(
            //                    new { ProductSeriesId = 1, MaterialId = 1 },
            //                    new { ProductSeriesId = 1, MaterialId = 2 },
            //                    new { ProductSeriesId = 2, MaterialId = 1 },
            //                    new { ProductSeriesId = 2, MaterialId = 2 },
            //                    new { ProductSeriesId = 3, MaterialId = 1 },
            //                    new { ProductSeriesId = 3, MaterialId = 2 },
            //                    new { ProductSeriesId = 4, MaterialId = 8 },
            //                    new { ProductSeriesId = 4, MaterialId = 3 },
            //                    new { ProductSeriesId = 5, MaterialId = 8 },
            //                    new { ProductSeriesId = 5, MaterialId = 4 },
            //                    new { ProductSeriesId = 5, MaterialId = 5 },
            //                    new { ProductSeriesId = 6, MaterialId = 8 },
            //                    new { ProductSeriesId = 6, MaterialId = 3 },
            //                    new { ProductSeriesId = 6, MaterialId = 4 },
            //                    new { ProductSeriesId = 6, MaterialId = 5 },
            //                    new { ProductSeriesId = 7, MaterialId = 8 },
            //                    new { ProductSeriesId = 7, MaterialId = 3 },
            //                    new { ProductSeriesId = 8, MaterialId = 5 },
            //                    new { ProductSeriesId = 8, MaterialId = 8 },
            //                    new { ProductSeriesId = 8, MaterialId = 9 },
            //                    new { ProductSeriesId = 8, MaterialId = 4 },
            //                    new { ProductSeriesId = 8, MaterialId = 6 },
            //                    new { ProductSeriesId = 9, MaterialId = 5 },
            //                    new { ProductSeriesId = 9, MaterialId = 8 },
            //                    new { ProductSeriesId = 9, MaterialId = 4 },
            //                    new { ProductSeriesId = 10, MaterialId = 8 },
            //                    new { ProductSeriesId = 10, MaterialId = 5 },
            //                    new { ProductSeriesId = 10, MaterialId = 9 },
            //                    new { ProductSeriesId = 11, MaterialId = 8 },
            //                    new { ProductSeriesId = 11, MaterialId = 5 },
            //                    new { ProductSeriesId = 11, MaterialId = 4 },
            //                    new { ProductSeriesId = 12, MaterialId = 8 },
            //                    new { ProductSeriesId = 12, MaterialId = 5 },
            //                    new { ProductSeriesId = 12, MaterialId = 10 },
            //                    new { ProductSeriesId = 12, MaterialId = 11 },
            //                    new { ProductSeriesId = 13, MaterialId = 8 },
            //                    new { ProductSeriesId = 13, MaterialId = 5 },
            //                    new { ProductSeriesId = 13, MaterialId = 12 },
            //                    new { ProductSeriesId = 14, MaterialId = 8 },
            //                    new { ProductSeriesId = 14, MaterialId = 11 },
            //                    new { ProductSeriesId = 15, MaterialId = 8 },
            //                    new { ProductSeriesId = 15, MaterialId = 3 },
            //                    new { ProductSeriesId = 15, MaterialId = 14 },
            //                    new { ProductSeriesId = 16, MaterialId = 8 },
            //                    new { ProductSeriesId = 16, MaterialId = 4 },
            //                    new { ProductSeriesId = 16, MaterialId = 5 },
            //                    new { ProductSeriesId = 17, MaterialId = 8 },
            //                    new { ProductSeriesId = 17, MaterialId = 5 },
            //                    new { ProductSeriesId = 17, MaterialId = 10 },
            //                    new { ProductSeriesId = 17, MaterialId = 11 },
            //                    new { ProductSeriesId = 18, MaterialId = 8 },
            //                    new { ProductSeriesId = 18, MaterialId = 4 },
            //                    new { ProductSeriesId = 18, MaterialId = 14 },
            //                    new { ProductSeriesId = 19, MaterialId = 8 },
            //                    new { ProductSeriesId = 19, MaterialId = 3 });
                        
            //        });

            //builder.Entity<Color>()
            //    .HasMany(c => c.Products)
            //    .WithMany(p => p.Colors)
            //    .UsingEntity<Dictionary<string, object>>("ProductsColors",
            //    r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
            //        l => l.HasOne<Color>().WithMany().HasForeignKey("ColorId"),
            //        mt =>
            //        {
            //            mt.HasKey("ProductId", "ColorId");

                        
            //                mt.HasData(
            //                    new { ProductId = 1, ColorId = 1 },
            //                    new { ProductId = 2, ColorId = 7 },
            //                    new { ProductId = 3, ColorId = 4 },
            //                    new { ProductId = 4, ColorId = 3 },
            //                    new { ProductId = 5, ColorId = 1 },
            //                    new { ProductId = 5, ColorId = 3 },
            //                    new { ProductId = 6, ColorId = 1 },
            //                    new { ProductId = 6, ColorId = 7 },
            //                    new { ProductId = 7, ColorId = 3 },
            //                    new { ProductId = 8, ColorId = 1 },
            //                    new { ProductId = 9, ColorId = 9 },
            //                    new { ProductId = 10, ColorId = 7 },
            //                    new { ProductId = 10, ColorId = 8 },
            //                    new { ProductId = 11, ColorId = 6 },
            //                    new { ProductId = 12, ColorId = 1 },
            //                    new { ProductId = 13, ColorId = 10 },
            //                    new { ProductId = 14, ColorId = 1 },
            //                    new { ProductId = 15, ColorId = 5 },
            //                    new { ProductId = 16, ColorId = 11 },
            //                    new { ProductId = 16, ColorId = 12 },
            //                    new { ProductId = 17, ColorId = 3 },
            //                    new { ProductId = 18, ColorId = 13 },
            //                    new { ProductId = 19, ColorId = 5 },
            //                    new { ProductId = 20, ColorId = 1 },
            //                    new { ProductId = 21, ColorId = 10 },
            //                    new { ProductId = 22, ColorId = 3 },
            //                    new { ProductId = 23, ColorId = 4 },
            //                    new { ProductId = 23, ColorId = 5 },
            //                    new { ProductId = 24, ColorId = 11 },
            //                    new { ProductId = 24, ColorId = 12 },
            //                    new { ProductId = 25, ColorId = 9 },
            //                    new { ProductId = 26, ColorId = 1 },
            //                    new { ProductId = 26, ColorId = 5 },
            //                    new { ProductId = 27, ColorId = 3 },
            //                    new { ProductId = 27, ColorId = 14 },
            //                    new { ProductId = 28, ColorId = 10 },
            //                    new { ProductId = 28, ColorId = 12 },
            //                    new { ProductId = 29, ColorId = 6 },
            //                    new { ProductId = 30, ColorId = 6 },
            //                    new { ProductId = 30, ColorId = 8 },
            //                    new { ProductId = 31, ColorId = 1 },
            //                    new { ProductId = 31, ColorId = 15 },
            //                    new { ProductId = 32, ColorId = 2 },
            //                    new { ProductId = 33, ColorId = 11 },
            //                    new { ProductId = 33, ColorId = 14 },
            //                    new { ProductId = 34, ColorId = 1 },
            //                    new { ProductId = 34, ColorId = 7 },
            //                    new { ProductId = 35, ColorId = 1 },
            //                    new { ProductId = 35, ColorId = 3 },
            //                    new { ProductId = 35, ColorId = 4 },
            //                    new { ProductId = 36, ColorId = 4 },
            //                    new { ProductId = 36, ColorId = 5 },
            //                    new { ProductId = 37, ColorId = 10 },
            //                    new { ProductId = 38, ColorId = 1 },
            //                    new { ProductId = 39, ColorId = 4 },
            //                    new { ProductId = 39, ColorId = 5 },
            //                    new { ProductId = 40, ColorId = 1 },
            //                    new { ProductId = 40, ColorId = 8 },
            //                    new { ProductId = 41, ColorId = 11 },
            //                    new { ProductId = 42, ColorId = 8 },
            //                    new { ProductId = 43, ColorId = 3 },
            //                    new { ProductId = 44, ColorId = 1 },
            //                    new { ProductId = 44, ColorId = 15 });
                        
            //        });


            //builder.Entity<Material>()
            //    .HasMany(c => c.Products)
            //    .WithMany(p => p.Materials)
            //    .UsingEntity<Dictionary<string, object>>("ProductsMaterials",
            //    r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
            //        l => l.HasOne<Material>().WithMany().HasForeignKey("MaterialId"),
            //        mt =>
            //        {
            //            mt.HasKey("ProductId", "MaterialId");
            //                mt.HasData(
            //                    new { ProductId = 1, MaterialId = 1 },
            //                    new { ProductId = 1, MaterialId = 2 },
            //                    new { ProductId = 2, MaterialId = 1 },
            //                    new { ProductId = 2, MaterialId = 2 },
            //                    new { ProductId = 3, MaterialId = 1 },
            //                    new { ProductId = 3, MaterialId = 2 },
            //                    new { ProductId = 4, MaterialId = 1 },
            //                    new { ProductId = 4, MaterialId = 2 },
            //                    new { ProductId = 5, MaterialId = 1 },
            //                    new { ProductId = 5, MaterialId = 2 },
            //                    new { ProductId = 6, MaterialId = 1 },
            //                    new { ProductId = 6, MaterialId = 2 },
            //                    new { ProductId = 7, MaterialId = 8 },
            //                    new { ProductId = 7, MaterialId = 3 },
            //                    new { ProductId = 8, MaterialId = 8 },
            //                    new { ProductId = 8, MaterialId = 3 },
            //                    new { ProductId = 9, MaterialId = 8 },
            //                    new { ProductId = 9, MaterialId = 4 },
            //                    new { ProductId = 9, MaterialId = 5 },
            //                    new { ProductId = 10, MaterialId = 8 },
            //                    new { ProductId = 10, MaterialId = 3 },
            //                    new { ProductId = 10, MaterialId = 4 },
            //                    new { ProductId = 10, MaterialId = 5 },
            //                    new { ProductId = 11, MaterialId = 8 },
            //                    new { ProductId = 11, MaterialId = 3 },
            //                    new { ProductId = 11, MaterialId = 4 },
            //                    new { ProductId = 11, MaterialId = 5 },
            //                    new { ProductId = 12, MaterialId = 8 },
            //                    new { ProductId = 12, MaterialId = 3 },
            //                    new { ProductId = 12, MaterialId = 4 },
            //                    new { ProductId = 12, MaterialId = 5 },
            //                    new { ProductId = 13, MaterialId = 8 },
            //                    new { ProductId = 13, MaterialId = 3 },
            //                    new { ProductId = 13, MaterialId = 4 },
            //                    new { ProductId = 13, MaterialId = 5 },
            //                    new { ProductId = 14, MaterialId = 8 },
            //                    new { ProductId = 14, MaterialId = 3 },
            //                    new { ProductId = 14, MaterialId = 4 },
            //                    new { ProductId = 14, MaterialId = 5 },
            //                    new { ProductId = 15, MaterialId = 8 },
            //                    new { ProductId = 15, MaterialId = 3 },
            //                    new { ProductId = 15, MaterialId = 4 },
            //                    new { ProductId = 15, MaterialId = 5 },
            //                    new { ProductId = 16, MaterialId = 8 },
            //                    new { ProductId = 16, MaterialId = 3 },
            //                    new { ProductId = 16, MaterialId = 4 },
            //                    new { ProductId = 16, MaterialId = 5 },
            //                    new { ProductId = 17, MaterialId = 8 },
            //                    new { ProductId = 17, MaterialId = 3 },
            //                    new { ProductId = 18, MaterialId = 8 },
            //                    new { ProductId = 18, MaterialId = 3 },
            //                    new { ProductId = 19, MaterialId = 8 },
            //                    new { ProductId = 19, MaterialId = 9 },
            //                    new { ProductId = 19, MaterialId = 4 },
            //                    new { ProductId = 19, MaterialId = 6 },
            //                    new { ProductId = 20, MaterialId = 8 },
            //                    new { ProductId = 20, MaterialId = 5 },
            //                    new { ProductId = 20, MaterialId = 4 },
            //                    new { ProductId = 21, MaterialId = 8 },
            //                    new { ProductId = 21, MaterialId = 5 },
            //                    new { ProductId = 21, MaterialId = 4 },
            //                    new { ProductId = 22, MaterialId = 8 },
            //                    new { ProductId = 22, MaterialId = 5 },
            //                    new { ProductId = 22, MaterialId = 9 },
            //                    new { ProductId = 23, MaterialId = 8 },
            //                    new { ProductId = 23, MaterialId = 5 },
            //                    new { ProductId = 23, MaterialId = 9 },
            //                    new { ProductId = 24, MaterialId = 8 },
            //                    new { ProductId = 24, MaterialId = 5 },
            //                    new { ProductId = 24, MaterialId = 4 },
            //                    new { ProductId = 25, MaterialId = 8 },
            //                    new { ProductId = 25, MaterialId = 5 },
            //                    new { ProductId = 25, MaterialId = 3 },
            //                    new { ProductId = 26, MaterialId = 8 },
            //                    new { ProductId = 26, MaterialId = 5 },
            //                    new { ProductId = 26, MaterialId = 10 },
            //                    new { ProductId = 26, MaterialId = 11 },
            //                    new { ProductId = 27, MaterialId = 8 },
            //                    new { ProductId = 27, MaterialId = 5 },
            //                    new { ProductId = 27, MaterialId = 10 },
            //                    new { ProductId = 27, MaterialId = 11 },
            //                    new { ProductId = 28, MaterialId = 8 },
            //                    new { ProductId = 28, MaterialId = 5 },
            //                    new { ProductId = 28, MaterialId = 10 },
            //                    new { ProductId = 28, MaterialId = 11 },
            //                    new { ProductId = 29, MaterialId = 8 },
            //                    new { ProductId = 29, MaterialId = 5 },
            //                    new { ProductId = 29, MaterialId = 12 },
            //                    new { ProductId = 29, MaterialId = 13 },
            //                    new { ProductId = 30, MaterialId = 8 },
            //                    new { ProductId = 30, MaterialId = 5 },
            //                    new { ProductId = 30, MaterialId = 12 },
            //                    new { ProductId = 31, MaterialId = 8 },
            //                    new { ProductId = 31, MaterialId = 5 },
            //                    new { ProductId = 31, MaterialId = 12 },
            //                    new { ProductId = 32, MaterialId = 8 },
            //                    new { ProductId = 32, MaterialId = 12 },
            //                    new { ProductId = 32, MaterialId = 13 },
            //                    new { ProductId = 32, MaterialId = 5 },
            //                    new { ProductId = 33, MaterialId = 8 },
            //                    new { ProductId = 33, MaterialId = 12 },
            //                    new { ProductId = 33, MaterialId = 13 },
            //                    new { ProductId = 33, MaterialId = 5 },
            //                    new { ProductId = 34, MaterialId = 8 },
            //                    new { ProductId = 34, MaterialId = 11 },
            //                    new { ProductId = 35, MaterialId = 8 },
            //                    new { ProductId = 35, MaterialId = 11 },
            //                    new { ProductId = 36, MaterialId = 8 },
            //                    new { ProductId = 36, MaterialId = 3 },
            //                    new { ProductId = 36, MaterialId = 14 },
            //                    new { ProductId = 37, MaterialId = 8 },
            //                    new { ProductId = 37, MaterialId = 4 },
            //                    new { ProductId = 37, MaterialId = 5 },
            //                    new { ProductId = 38, MaterialId = 8 },
            //                    new { ProductId = 38, MaterialId = 4 },
            //                    new { ProductId = 38, MaterialId = 5 },
            //                    new { ProductId = 39, MaterialId = 8 },
            //                    new { ProductId = 39, MaterialId = 5 },
            //                    new { ProductId = 39, MaterialId = 10 },
            //                    new { ProductId = 39, MaterialId = 11 },
            //                    new { ProductId = 40, MaterialId = 8 },
            //                    new { ProductId = 40, MaterialId = 5 },
            //                    new { ProductId = 40, MaterialId = 10 },
            //                    new { ProductId = 40, MaterialId = 11 },
            //                    new { ProductId = 41, MaterialId = 8 },
            //                    new { ProductId = 41, MaterialId = 4 },
            //                    new { ProductId = 41, MaterialId = 14 },
            //                    new { ProductId = 42, MaterialId = 8 },
            //                    new { ProductId = 42, MaterialId = 4 },
            //                    new { ProductId = 42, MaterialId = 14 },
            //                    new { ProductId = 43, MaterialId = 8 },
            //                    new { ProductId = 43, MaterialId = 3 },
            //                    new { ProductId = 44, MaterialId = 8 },
            //                    new { ProductId = 44, MaterialId = 3 });
                        
            //        });

            //builder.Entity<Tag>()
            //    .HasMany(t => t.Products)
            //    .WithMany(p => p.Tags)
            //    .UsingEntity<Dictionary<string, object>>("ProductsTags",
            //    r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
            //    l => l.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
            //    mt =>
            //    {
            //        mt.HasKey("ProductId", "TagId");

                    


            //            mt.HasData(
            //                new { ProductId = 9, TagId = 3 },
            //                new { ProductId = 10, TagId = 3 },
            //                new { ProductId = 15, TagId = 3 },
            //                new { ProductId = 16, TagId = 3 },
            //                new { ProductId = 22, TagId = 1 },
            //                new { ProductId = 23, TagId = 1 },
            //                new { ProductId = 26, TagId = 2 },
            //                new { ProductId = 27, TagId = 2 },
            //                new { ProductId = 30, TagId = 2 },
            //                new { ProductId = 31, TagId = 2 },
            //                new { ProductId = 43, TagId = 1 });
                    
            //    });
        }
    }
}
