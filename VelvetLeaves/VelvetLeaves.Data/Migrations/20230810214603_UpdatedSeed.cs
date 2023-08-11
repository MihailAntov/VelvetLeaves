using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class UpdatedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b7fab5e-82de-417f-b7dd-90e81abcceda");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a1a0c6c-dd9c-49e0-8e35-d3c9738e8b11");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8e61ff6-0aff-4c34-9b42-042ef380b343");

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be89ae1409e5a61554e6ed");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8c68cac3fdf11a06fbbb");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8c6df878c3764a814981");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8c733df251037e15d70a");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8c7a0ef21ca57c247498");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8c813d909293463359d6");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8c870b7f086367ebb6a5");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8c8d7d5c466b820b73af");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8c9332b088f8d6063040");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8c99f991d074063b5098");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8c9f41c19cda7ab19853");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8ca5b7f1ea12383c364a");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8caa293917f47210277e");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8cae1813d7aff61e173b");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8cb3b390e17c62039322");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64be8cb81a39dd6ed0351ebb");

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesTags",
                keyColumns: new[] { "ProductSeriesId", "TagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesTags",
                keyColumns: new[] { "ProductSeriesId", "TagId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesTags",
                keyColumns: new[] { "ProductSeriesId", "TagId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesTags",
                keyColumns: new[] { "ProductSeriesId", "TagId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesTags",
                keyColumns: new[] { "ProductSeriesId", "TagId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1508917d-966b-4e32-b892-47070df86ebe", 0, "cfbeb86c-939f-4697-8998-b7df46d1ae1c", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEEfY85fZMrDdRctLi4ajd+ONEMKV0APyzhkL9Ulz3mcTtcQZg2M7+qEyA7jneex98Q==", null, false, "c86efe3c-c961-4188-983c-8ef94a5c5f20", false, "user@vls.com" },
                    { "1e7bc6b1-b26a-4d22-8b0f-8d850006f3e4", 0, "ec91b92b-53a8-448e-b14d-041f9a436674", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAELtfn73LI7yDhA7vkZ7jC7Rbmft7U5JFoVKOmbMJ48h8pgt2Uh+1VfMRlBFeif/f0A==", null, false, "a973ed67-3af5-41fe-99aa-5c878322a4d1", false, "moderator@vls.com" },
                    { "edb5df2b-e8e1-4cea-b4ef-c9f7f0333a37", 0, "a5da0089-aa2f-4f4f-a1ae-4cc2fab3fcc2", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEPZmwFqjebrJ3U0dpJDwKu4y8ddeo/72LYZhuGDsctqP9cux/SdoYu9Zca+12oICpQ==", null, false, "e5805180-f9c8-4cba-b258-86f520808cba", false, "admin@vls.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64d52335b30136c5a68bb051", "Текстил" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64d5238d2acacb9e2043c933", "Бижута" });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ColorValue", "Name" },
                values: new object[] { "#d0c442", "жълто" });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ColorValue", "Name" },
                values: new object[] { "#147b83", "тюркоаз" });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ColorValue", "Name" },
                values: new object[] { "#d03844", "червено" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "ColorValue", "IsActive", "Name" },
                values: new object[,]
                {
                    { 4, "#87cc4a", true, "светло зелено" },
                    { 5, "#46761b", true, "тъмно зелено" },
                    { 6, "#721cae", true, "лилаво" },
                    { 7, "#154978", true, "тъмно синьо" },
                    { 8, "#34b4df", true, "светло синьо" },
                    { 9, "#e6c89f", true, "шампанско" },
                    { 10, "#d8748c", true, "розово" },
                    { 11, "#f0eddc", true, "бяло" },
                    { 12, "#961243", true, "циклама" },
                    { 13, "#904236", true, "кафяво" },
                    { 14, "#000000", true, "черно" },
                    { 15, "#fe7612", true, "оранжево" }
                });

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageId", "Name" },
                values: new object[] { "Колиета и обеци от серия \"Грозд\"", "64d523b1a82f8b465badccfe", "Гроздове" });

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageId", "Name" },
                values: new object[] { "Бижута от серия \"Мак\"", "64d524415910ab1c2728156e", "Макове" });

            migrationBuilder.InsertData(
                table: "Galleries",
                columns: new[] { "Id", "Description", "ImageId", "IsActive", "Name" },
                values: new object[] { 3, "Разгледайте новите ни предложения", "64d5241b4efab879d2b98106", true, "Нова колекция" });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId" },
                values: new object[,]
                {
                    { "64d52335b30136c5a68bb051", 1 },
                    { "64d52338464ff67d85ff46a5", 1 },
                    { "64d5233c720097ef9dffa9ab", 1 },
                    { "64d523401c23834259ea6b65", 1 },
                    { "64d52343c1a58e96abb5c206", 1 },
                    { "64d523475af695148db6b205", 2 },
                    { "64d52349d406df65ce4b4e72", 2 },
                    { "64d5234ce3785f17243b411c", 2 },
                    { "64d5234f5a69fa9f747e5f18", 2 },
                    { "64d5235287a0f3693212c2a1", 3 },
                    { "64d523565b62f7aaf0663a98", 3 },
                    { "64d52359322458a957d81660", 3 },
                    { "64d5235bf6729604d509bc8a", 3 },
                    { "64d5235f274fb0fcf347d1b3", 4 },
                    { "64d52362ecdfe6871993e1e4", 4 },
                    { "64d52366fb8d548ef1e6a1cb", 4 },
                    { "64d5236abb6d8a6883aea6a5", 4 },
                    { "64d5236e334387ef86d99937", 5 },
                    { "64d52372fe1c9b730442e805", 5 }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId" },
                values: new object[,]
                {
                    { "64d523760ebe3629aa66effc", 5 },
                    { "64d5237b623df2b2ac3fc610", 5 },
                    { "64d5237ebfa052d5f7b7e3cb", 6 },
                    { "64d52381a7064dcc1dd461d5", 6 },
                    { "64d52385751a53bf32894fb4", 6 },
                    { "64d5238841449e1eef8fc29a", 6 },
                    { "64d5238d2acacb9e2043c933", 7 },
                    { "64d52392f6a5f8843a780460", 7 },
                    { "64d523961f6d033d54da856e", 7 }
                });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Лен");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Памук");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Стомана");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Сребро");

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 5, true, "Полускъпоценни камъни" },
                    { 6, true, "Кристали Сваровски" },
                    { 8, true, "Естествени копринени пашкули" },
                    { 9, true, "Посребрена тел" },
                    { 10, true, "Кожа" },
                    { 11, true, "Стоманена магнитна закопчалка" },
                    { 12, true, "Велур" },
                    { 13, true, "Дърво" },
                    { 14, true, "Речни перли" }
                });

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DefaultDescription", "DefaultName", "DefaultPrice", "Name" },
                values: new object[] { "Авторска ръчно изработена чанта от лен, с ръчна бродерия и памучна подплата. Всяка чанта е уникална и няма да бъде повторена в тази комбинация от модел и шевица.", "Ленена чанта", 140.00m, "Чанта" });

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DefaultDescription", "DefaultName", "DefaultPrice", "Name", "SubcategoryId" },
                values: new object[] { "Авторска ръчно изработен несесер от лен, с ръчна бродерия и памучна подплата. ", "Ленен несесер ", 40.00m, "Несесер", 2 });

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DefaultDescription", "DefaultName", "DefaultPrice", "Name", "SubcategoryId" },
                values: new object[] { "Авторска ръчно изработенa подвързия за книга от лен, с ръчна бродерия и памучна подплата.", "Ленена подвързия", 45.00m, "Подвързия", 3 });

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DefaultDescription", "DefaultName", "DefaultPrice", "Name", "SubcategoryId" },
                values: new object[] { "Ръчно изработени обеци от естествени копринени пашкули и стомана", "Обици \"Букет\"", 25.00m, "3ка до ухо", 4 });

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DefaultDescription", "DefaultName", "DefaultPrice", "Name" },
                values: new object[] { "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", "Обеци \"Грозд\"", 60.00m, "Гроздове" });

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DefaultDescription", "DefaultName", "Name", "SubcategoryId" },
                values: new object[] { "Ръчно изработени обеци от естествени копринени пашкули, стоманена тел, сребро и полускъпоценни камъни", "Дълги обеци", "Дълги", 4 });

            migrationBuilder.InsertData(
                table: "ProductSeries",
                columns: new[] { "Id", "DefaultDescription", "DefaultName", "DefaultPrice", "IsActive", "Name", "SubcategoryId" },
                values: new object[,]
                {
                    { 7, "Ръчно изработени обеци от естествени копринени пашкули и стомана", "Обеци на синджир", 25.00m, true, "На синджир", 4 },
                    { 8, "Ръчно изработени обеци от естествени копринени пашкули, посребрена тел, сребро и кристали Сваровски", "Обеци \"Тромбон\"", 35.00m, true, "Тромбон", 4 },
                    { 9, "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", "Колие малък \"Грозд\"", 50.00m, true, "Гроздове", 5 },
                    { 10, "Ръчно изработено колие от естествени копринени пашкули, посребрена тел и полускъпоценни камъни", "Колие на обръч \"Мак\"", 45.00m, true, "На обръч", 5 },
                    { 11, "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", "Сребърно колие", 50.00m, true, "Сребро", 5 },
                    { 12, "Ръчно изработено колие от естествени копринени пашкули, кожа, полускъпоценни камъни и с магнитна закопчалка", "Колие на кожа", 50.00m, true, "Кожа", 5 },
                    { 13, "Ръчно изработено колие от естествени копринени пашкули, велур и полускъпоценни камъни", "Колие на велур", 40.00m, true, "Велур", 5 },
                    { 14, "Ръчно изработено колие от естествени копринени пашкули с магнитна закопчалка", "Колие \"Венец\"", 50.00m, true, "Въже", 5 },
                    { 15, "Ръчно изработено колие от естествени копринени пашкули, стомана и речни перли", "Стоманено колие", 45.00m, true, "Стомана", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Авторска ръчно изработена чанта от лен, с ръчна бродерия и памучна подплата. Всяка чанта е уникална и няма да бъде повторена в тази комбинация от модел и шевица.", "Ленена чанта \"Слънце\"", 140.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price", "ProductSeriesId" },
                values: new object[] { "Авторска ръчно изработена чанта от лен, с ръчна бродерия и памучна подплата. Всяка чанта е уникална и няма да бъде повторена в тази комбинация от модел и шевица.", "Ленена чанта \" Синева\"", 150.00m, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price", "ProductSeriesId", "SubcategoryId" },
                values: new object[] { "Авторски ръчно изработен несесер от лен, с ръчна бродерия и памучна подплата. ", "Ленен несесер ", 40.00m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price", "ProductSeriesId", "SubcategoryId" },
                values: new object[] { "Авторски ръчно изработен несесер от лен, с ръчна бродерия и памучна подплата. ", "Ленен несесер ", 40.00m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price", "ProductSeriesId", "SubcategoryId" },
                values: new object[] { "Авторска ръчно изработенa подвързия за книга от лен, с ръчна бродерия и памучна подплата.", "Ленена подвързия за книга", 45.00m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Price", "ProductSeriesId", "SubcategoryId" },
                values: new object[] { "Авторска ръчно изработенa подвързия за електронна книга от лен, с ръчна бродерия и памучна подплата. ", "Ленена подвързия за Kindle", 45.00m, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "Price", "ProductSeriesId", "SubcategoryId" },
                values: new object[] { "Ръчно изработени обеци от естествени копринени пашкули и стомана", "Обици \"Букет\"", 25.00m, 1, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IsActive", "IsAvailable", "Name", "Price", "ProductSeriesId", "SubcategoryId" },
                values: new object[,]
                {
                    { 8, "Ръчно изработени обеци от естествени копринени пашкули и стомана", true, true, "Обици \"Букет\"", 25.00m, 1, 1 },
                    { 9, "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", true, true, "Големи обеци \"Грозд\"", 60.00m, 1, 1 },
                    { 10, "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", true, true, "Големи обеци \"Грозд\"", 60.00m, 1, 1 },
                    { 11, "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", true, true, "Средни обеци \"Грозд\"", 60.00m, 1, 1 },
                    { 12, "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", true, true, "Средни обеци \"Грозд\"", 60.00m, 1, 1 },
                    { 13, "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", true, true, "Малки обеци \"Грозд\"", 35.00m, 1, 1 },
                    { 14, "Ръчно изработени обеци от естествени копринени пашкули, сребро и полускъпоценни камъни", true, true, "Малки обеци \"Грозд\" ", 35.00m, 1, 1 },
                    { 15, "Ръчно изработени обеци от естествени копринени пашкули, стоманена тел, сребро и полускъпоценни камъни", true, true, "Дълги обеци", 50.00m, 1, 1 },
                    { 16, "Ръчно изработени обеци от естествени копринени пашкули, стоманена тел, сребро и полускъпоценни камъни", true, true, "Дълги обеци", 50.00m, 1, 1 },
                    { 17, "Ръчно изработени обеци от естествени копринени пашкули и стомана", true, true, "Обеци на синджир", 25.00m, 1, 1 },
                    { 18, "Ръчно изработени обеци от естествени копринени пашкули и стомана", true, true, "Обеци на синджир", 25.00m, 1, 1 },
                    { 19, "Ръчно изработени обеци от естествени копринени пашкули, посребрена тел, сребро и кристали Сваровски", true, true, "Обеци \"Тромбон\"", 35.00m, 1, 1 },
                    { 20, "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", true, true, "Колие малък \"Грозд\"", 50.00m, 1, 1 },
                    { 21, "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", true, true, "Колие малък \"Грозд\"", 50.00m, 1, 1 },
                    { 22, "Ръчно изработено колие от естествени копринени пашкули, посребрена тел и полускъпоценни камъни", true, true, "Колие на обръч \"Мак\"", 45.00m, 1, 1 },
                    { 23, "Ръчно изработено колие от естествени копринени пашкули, посребрена тел и полускъпоценни камъни", true, true, "Колие на обръч \"Мак\"", 45.00m, 1, 1 },
                    { 24, "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", true, true, "Сребърно колие", 50.00m, 1, 1 },
                    { 25, "Ръчно изработено колие от естествени копринени пашкули, сребро и полускъпоценни камъни", true, true, "Сребърно колие", 50.00m, 1, 1 },
                    { 26, "Ръчно изработено колие от естествени копринени пашкули, кожа, полускъпоценни камъни и с магнитна закопчалка", true, true, "Колие на кожа с цели пашкули", 50.00m, 1, 1 },
                    { 27, "Ръчно изработено колие от естествени копринени пашкули, кожа, полускъпоценни камъни и с магнитна закопчалка", true, true, "Колие на кожа с цели пашкули", 50.00m, 1, 1 },
                    { 28, "Ръчно изработено колие от естествени копринени пашкули, кожа, полускъпоценни камъни и с магнитна закопчалка", true, true, "Колие на кожа с цветя", 50.00m, 1, 1 },
                    { 29, "Ръчно изработено колие от естествени копринени пашкули, велур, ръчно изработен дървен елемент от орех, и полускъпоценни камъни", true, true, "Колие на велур с цветя", 35.00m, 1, 1 },
                    { 30, "Ръчно изработено колие от естествени копринени пашкули, велур и полускъпоценни камъни", true, true, "Колие на велур с цели пашкули", 40.00m, 1, 1 },
                    { 31, "Ръчно изработено колие от естествени копринени пашкули, велур и полускъпоценни камъни", true, true, "Колие на велур с цели пашкули", 40.00m, 1, 1 },
                    { 32, "Ръчно изработено колие от естествени копринени пашкули, велур и полускъпоценни камъни", true, true, "Колие на велур с цветя", 35.00m, 1, 1 },
                    { 33, "Ръчно изработено колие от естествени копринени пашкули, велур, ръчно изработен дървен елемент от орех, и полускъпоценни камъни", true, true, "Колие на велур с цветя", 35.00m, 1, 1 },
                    { 34, "Ръчно изработено колие от естествени копринени пашкули с магнитна закопчалка", true, true, "Колие \"Венец\"", 50.00m, 1, 1 },
                    { 35, "Ръчно изработено колие от естествени копринени пашкули с магнитна закопчалка", true, true, "Колие \"Венец\"", 50.00m, 1, 1 },
                    { 36, "Ръчно изработено колие от естествени копринени пашкули, стомана и речни перли", true, true, "Стоманено колие", 45.00m, 1, 1 },
                    { 37, "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и сребро", true, true, "Сребърна гривна", 45.00m, 1, 1 },
                    { 38, "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и сребро", true, true, "Сребърна гривна", 45.00m, 1, 1 },
                    { 39, "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и кожа, с магнитна закопчалка", true, true, "Кожена гривна", 45.00m, 1, 1 },
                    { 40, "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и кожа, с магнитна закопчалка", true, true, "Кожена гривна", 45.00m, 1, 1 },
                    { 41, "Ръчно изработен пръстен от естествени копринени пашкули, сладководни перли и сребро", true, true, "Сребърен пръстен с речна перла", 35.00m, 1, 1 },
                    { 42, "Ръчно изработен пръстен от естествени копринени пашкули, сладководни перли и сребро", true, true, "Сребърен пръстен с речна перла", 35.00m, 1, 1 },
                    { 43, "Ръчно изработен пръстен от естествени копринени пашкули и стомана", true, true, "Стоманен пръстен", 25.00m, 1, 1 },
                    { 44, "Ръчно изработен пръстен от естествени копринени пашкули и стомана", true, true, "Стоманен пръстен", 25.00m, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductsColors",
                columns: new[] { "ColorId", "ProductId" },
                values: new object[,]
                {
                    { 3, 4 },
                    { 1, 5 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "ProductsColors",
                columns: new[] { "ColorId", "ProductId" },
                values: new object[,]
                {
                    { 1, 6 },
                    { 3, 7 }
                });

            migrationBuilder.InsertData(
                table: "ProductsMaterials",
                columns: new[] { "MaterialId", "ProductId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.InsertData(
                table: "ProductsSeriesMaterials",
                columns: new[] { "MaterialId", "ProductSeriesId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64d52335b30136c5a68bb051", "Чанти" });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64d5235bf6729604d509bc8a", "Несесери" });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64d5237b623df2b2ac3fc610", "Подвързии" });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64d5238d2acacb9e2043c933", "Обеци" });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64d52421cfb2a66f5536dbc6", "Колиета" });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "ImageId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 6, 2, "64d524cb8237c4c8cab1c94d", true, "Гривни" },
                    { 7, 2, "64d524fa4584a8013259e40d", true, "Пръстени" }
                });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Мак");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Цели пашкули");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[] { 3, true, "Дълги" });

            migrationBuilder.InsertData(
                table: "GalleriesProducts",
                columns: new[] { "GalleryId", "ProductId", "Position" },
                values: new object[,]
                {
                    { 1, 9, 1 },
                    { 1, 10, 2 },
                    { 1, 11, 3 },
                    { 1, 12, 4 },
                    { 1, 13, 5 },
                    { 1, 20, 6 },
                    { 2, 22, 1 },
                    { 2, 23, 2 },
                    { 2, 43, 3 },
                    { 3, 19, 1 },
                    { 3, 34, 2 },
                    { 3, 35, 3 },
                    { 3, 36, 4 }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId" },
                values: new object[,]
                {
                    { "64d5239a46383aa6559ff15e", 8 },
                    { "64d5239dfb4154fc78c1b5f2", 8 },
                    { "64d523a091c723288ab2703f", 8 },
                    { "64d523a27541d354f5185ecf", 9 },
                    { "64d523a54482b6933b4b9641", 9 },
                    { "64d523a8417674952ae911aa", 9 },
                    { "64d523ac76b19d54b131024b", 10 },
                    { "64d523af7736cd67efd18bca", 10 },
                    { "64d523b1a82f8b465badccfe", 10 },
                    { "64d523b4aaae78c1fb2e0f19", 10 },
                    { "64d523c837c5cbc84815c6b2", 11 },
                    { "64d523cbc940befd0ef0bbea", 11 },
                    { "64d523ceda1ac0b8527ffd26", 12 },
                    { "64d523d1c01dda3483251e4c", 12 },
                    { "64d523d49319f1ab11955ee0", 13 },
                    { "64d523e02eab219eca427579", 13 },
                    { "64d523e30dd3878eccd3ea1e", 13 },
                    { "64d523e7d30950cc175d4ee5", 14 },
                    { "64d523e985893af2853dbaa4", 14 },
                    { "64d523ed880a2cfea4e5a29a", 14 },
                    { "64d523f115f347b097321f2a", 15 },
                    { "64d523f45251d2a11816195f", 15 },
                    { "64d523f7a6a8571b3eb12359", 15 },
                    { "64d523fabe152a47636bae7d", 16 },
                    { "64d523fdeb4444d63ab86a55", 16 },
                    { "64d523ff4215c2646cc8163e", 16 },
                    { "64d524022c22a7bf5d6fb592", 17 },
                    { "64d52405dd648aaccb6de56f", 17 },
                    { "64d524084074dd02c95d5612", 17 }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId" },
                values: new object[,]
                {
                    { "64d5240c0d0a9f46840215f4", 18 },
                    { "64d5240f1f6a4bf88ff5fe28", 18 },
                    { "64d52413ca2cdb86d5dc5061", 18 },
                    { "64d5241605cdc65069fb4e7c", 19 },
                    { "64d524194292962f1698b35d", 19 },
                    { "64d5241b4efab879d2b98106", 19 },
                    { "64d5241ec70acdc88d85b2cf", 19 },
                    { "64d52421cfb2a66f5536dbc6", 20 },
                    { "64d5242462bf6e246eef6de5", 20 },
                    { "64d5242760c55c37a36657d8", 20 },
                    { "64d5242b9278a4b37dcc630b", 21 },
                    { "64d5242e5935e047dede6793", 21 },
                    { "64d524315e7d9e628e279e40", 21 },
                    { "64d52434e25395fb8679db94", 22 },
                    { "64d5243d1a39817b5412e11d", 22 },
                    { "64d524415910ab1c2728156e", 22 },
                    { "64d524457ff5157cd75d74b1", 23 },
                    { "64d52448f4eb7a0a7f25a51a", 23 },
                    { "64d5244a9e32fb59f283d635", 23 },
                    { "64d5244e355f07301da86f9d", 24 },
                    { "64d524501bda417d5761bfca", 24 },
                    { "64d5245377429792e179d3bf", 24 },
                    { "64d52455958cb65afbfd6ae8", 24 },
                    { "64d5245b5f00130edb99f651", 25 },
                    { "64d5245e9b617cd236346b63", 25 },
                    { "64d52461873681ea5d64d875", 25 },
                    { "64d52464dac819b2d0d9651a", 25 },
                    { "64d52468d463b9450c90da10", 26 },
                    { "64d5246c78ebed5232e6790b", 26 },
                    { "64d5246f1c85d65d8278ed46", 27 },
                    { "64d52471ba01308173853a57", 27 },
                    { "64d524758723c98b4517d0e4", 28 },
                    { "64d52477d20e0caee58a1b13", 28 },
                    { "64d52479338c4bae74412ae2", 29 },
                    { "64d5247d00dfdad417f95d9a", 29 },
                    { "64d5247fce219f6b15944ce6", 29 },
                    { "64d52481af9cd319228bc03e", 32 },
                    { "64d524848355e8e0ca5c7c64", 32 },
                    { "64d524894f0d449e6e7f0be5", 33 },
                    { "64d5248ef11f97cf0d936c79", 33 },
                    { "64d52490c7197f5948d686e0", 33 },
                    { "64d5249591db48402680da4f", 30 }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId" },
                values: new object[,]
                {
                    { "64d524983f05edf1b19fbfcf", 30 },
                    { "64d5249cf2a4faf6783dcba7", 30 },
                    { "64d5249fbd5f98393548eaf3", 31 },
                    { "64d524a14f2def8ce5fe2053", 31 },
                    { "64d524a4d08826759b124b81", 31 },
                    { "64d524a8a106e8030a0f5810", 34 },
                    { "64d524ace356ce0f5b5e84c6", 34 },
                    { "64d524b05db296b5147b774a", 34 },
                    { "64d524b586fa7d40023defa1", 34 },
                    { "64d524b9579b4b54285e15ed", 35 },
                    { "64d524bc9c0bf598bdbe9551", 35 },
                    { "64d524bf2b882738a30506c5", 35 },
                    { "64d524c23a6c7f3087010b63", 36 },
                    { "64d524c58d113c6f7108c444", 36 },
                    { "64d524c8d973ed6ecd116daf", 36 },
                    { "64d524cb8237c4c8cab1c94d", 37 },
                    { "64d524ce181e34c33340dd05", 38 },
                    { "64d524d23b4f7df4df352f9f", 39 },
                    { "64d524d540e46b0cea6cc523", 39 },
                    { "64d524d99bb7990b020777b9", 39 },
                    { "64d524db4c9f4a9647db7009", 39 },
                    { "64d524de44d6b9ac55e41954", 40 },
                    { "64d524e1def6a193ed8df8f6", 40 },
                    { "64d524e404b5bd7f13be1c5b", 40 },
                    { "64d524e80992abcef8352a65", 40 },
                    { "64d524ebc6f3675710bbd9dd", 40 },
                    { "64d524fa4584a8013259e40d", 41 },
                    { "64d52504405b952082fb05d1", 41 },
                    { "64d52507173da7d7420d2657", 41 },
                    { "64d5250a13661437bd07c952", 41 },
                    { "64d5250e6b4ba5e401ed0500", 42 },
                    { "64d52512e2aa2cc2c81f5b6e", 42 },
                    { "64d52515302802a83f0af2e0", 42 },
                    { "64d5251be13c2530fda92d19", 43 },
                    { "64d5251e9c3ab859c753c597", 43 },
                    { "64d52521e58195d2403b6e15", 43 },
                    { "64d5252751ecfe48e09e1f15", 44 },
                    { "64d5252abf960bb7827bb75b", 44 },
                    { "64d5252d8c5ead2168fbd1cb", 44 },
                    { "64d525319813433aa6afe1ac", 44 }
                });

            migrationBuilder.InsertData(
                table: "ProductSeries",
                columns: new[] { "Id", "DefaultDescription", "DefaultName", "DefaultPrice", "IsActive", "Name", "SubcategoryId" },
                values: new object[,]
                {
                    { 16, "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и сребро", "Сребърна гривна", 45.00m, true, "Сребро", 6 },
                    { 17, "Ръчно изработена гривна от естествени копринени пашкули, полускъпоценни камъни и кожа, с магнитна закопчалка", "Кожена гривна", 45.00m, true, "Кожа", 6 }
                });

            migrationBuilder.InsertData(
                table: "ProductSeries",
                columns: new[] { "Id", "DefaultDescription", "DefaultName", "DefaultPrice", "IsActive", "Name", "SubcategoryId" },
                values: new object[,]
                {
                    { 18, "Ръчно изработен пръстен от естествени копринени пашкули, сладководни перли и сребро", "Сребърен пръстен с речна перла", 35.00m, true, "Сребро", 7 },
                    { 19, "Ръчно изработен пръстен от естествени копринени пашкули и стомана", "Стоманен пръстен", 25.00m, true, "Стомана", 7 }
                });

            migrationBuilder.InsertData(
                table: "ProductsColors",
                columns: new[] { "ColorId", "ProductId" },
                values: new object[,]
                {
                    { 7, 2 },
                    { 4, 3 },
                    { 7, 6 },
                    { 1, 8 },
                    { 9, 9 },
                    { 7, 10 },
                    { 8, 10 },
                    { 6, 11 },
                    { 1, 12 },
                    { 10, 13 },
                    { 1, 14 },
                    { 5, 15 },
                    { 11, 16 },
                    { 12, 16 },
                    { 3, 17 },
                    { 13, 18 },
                    { 5, 19 },
                    { 1, 20 },
                    { 10, 21 },
                    { 3, 22 },
                    { 4, 23 },
                    { 5, 23 },
                    { 11, 24 },
                    { 12, 24 },
                    { 9, 25 },
                    { 1, 26 },
                    { 5, 26 },
                    { 3, 27 },
                    { 14, 27 },
                    { 10, 28 },
                    { 12, 28 },
                    { 6, 29 },
                    { 6, 30 },
                    { 8, 30 },
                    { 1, 31 },
                    { 15, 31 },
                    { 2, 32 },
                    { 11, 33 },
                    { 14, 33 },
                    { 1, 34 }
                });

            migrationBuilder.InsertData(
                table: "ProductsColors",
                columns: new[] { "ColorId", "ProductId" },
                values: new object[,]
                {
                    { 7, 34 },
                    { 1, 35 },
                    { 3, 35 },
                    { 4, 35 },
                    { 4, 36 },
                    { 5, 36 },
                    { 10, 37 },
                    { 1, 38 },
                    { 4, 39 },
                    { 5, 39 },
                    { 1, 40 },
                    { 8, 40 },
                    { 11, 41 },
                    { 8, 42 },
                    { 3, 43 },
                    { 1, 44 },
                    { 15, 44 }
                });

            migrationBuilder.InsertData(
                table: "ProductsMaterials",
                columns: new[] { "MaterialId", "ProductId" },
                values: new object[,]
                {
                    { 8, 7 },
                    { 3, 8 },
                    { 8, 8 },
                    { 4, 9 },
                    { 5, 9 },
                    { 8, 9 },
                    { 3, 10 },
                    { 4, 10 },
                    { 5, 10 },
                    { 8, 10 },
                    { 3, 11 },
                    { 4, 11 },
                    { 5, 11 },
                    { 8, 11 },
                    { 3, 12 },
                    { 4, 12 },
                    { 5, 12 },
                    { 8, 12 },
                    { 3, 13 },
                    { 4, 13 },
                    { 5, 13 },
                    { 8, 13 },
                    { 3, 14 },
                    { 4, 14 },
                    { 5, 14 }
                });

            migrationBuilder.InsertData(
                table: "ProductsMaterials",
                columns: new[] { "MaterialId", "ProductId" },
                values: new object[,]
                {
                    { 8, 14 },
                    { 3, 15 },
                    { 4, 15 },
                    { 5, 15 },
                    { 8, 15 },
                    { 3, 16 },
                    { 4, 16 },
                    { 5, 16 },
                    { 8, 16 },
                    { 3, 17 },
                    { 8, 17 },
                    { 3, 18 },
                    { 8, 18 },
                    { 4, 19 },
                    { 6, 19 },
                    { 8, 19 },
                    { 9, 19 },
                    { 4, 20 },
                    { 5, 20 },
                    { 8, 20 },
                    { 4, 21 },
                    { 5, 21 },
                    { 8, 21 },
                    { 5, 22 },
                    { 8, 22 },
                    { 9, 22 },
                    { 5, 23 },
                    { 8, 23 },
                    { 9, 23 },
                    { 4, 24 },
                    { 5, 24 },
                    { 8, 24 },
                    { 3, 25 },
                    { 5, 25 },
                    { 8, 25 },
                    { 5, 26 },
                    { 8, 26 },
                    { 10, 26 },
                    { 11, 26 },
                    { 5, 27 },
                    { 8, 27 },
                    { 10, 27 }
                });

            migrationBuilder.InsertData(
                table: "ProductsMaterials",
                columns: new[] { "MaterialId", "ProductId" },
                values: new object[,]
                {
                    { 11, 27 },
                    { 5, 28 },
                    { 8, 28 },
                    { 10, 28 },
                    { 11, 28 },
                    { 5, 29 },
                    { 8, 29 },
                    { 12, 29 },
                    { 13, 29 },
                    { 5, 30 },
                    { 8, 30 },
                    { 12, 30 },
                    { 5, 31 },
                    { 8, 31 },
                    { 12, 31 },
                    { 5, 32 },
                    { 8, 32 },
                    { 12, 32 },
                    { 13, 32 },
                    { 5, 33 },
                    { 8, 33 },
                    { 12, 33 },
                    { 13, 33 },
                    { 8, 34 },
                    { 11, 34 },
                    { 8, 35 },
                    { 11, 35 },
                    { 3, 36 },
                    { 8, 36 },
                    { 14, 36 },
                    { 4, 37 },
                    { 5, 37 },
                    { 8, 37 },
                    { 4, 38 },
                    { 5, 38 },
                    { 8, 38 },
                    { 5, 39 },
                    { 8, 39 },
                    { 10, 39 },
                    { 11, 39 },
                    { 5, 40 },
                    { 8, 40 }
                });

            migrationBuilder.InsertData(
                table: "ProductsMaterials",
                columns: new[] { "MaterialId", "ProductId" },
                values: new object[,]
                {
                    { 10, 40 },
                    { 11, 40 },
                    { 4, 41 },
                    { 8, 41 },
                    { 14, 41 },
                    { 4, 42 },
                    { 8, 42 },
                    { 14, 42 },
                    { 3, 43 },
                    { 8, 43 },
                    { 3, 44 },
                    { 8, 44 }
                });

            migrationBuilder.InsertData(
                table: "ProductsSeriesMaterials",
                columns: new[] { "MaterialId", "ProductSeriesId" },
                values: new object[,]
                {
                    { 8, 4 },
                    { 5, 5 },
                    { 8, 5 },
                    { 5, 6 },
                    { 8, 6 },
                    { 3, 7 },
                    { 8, 7 },
                    { 4, 8 },
                    { 5, 8 },
                    { 6, 8 },
                    { 8, 8 },
                    { 9, 8 },
                    { 4, 9 },
                    { 5, 9 },
                    { 8, 9 },
                    { 5, 10 },
                    { 8, 10 },
                    { 9, 10 },
                    { 4, 11 },
                    { 5, 11 },
                    { 8, 11 },
                    { 5, 12 },
                    { 8, 12 },
                    { 10, 12 },
                    { 11, 12 },
                    { 5, 13 },
                    { 8, 13 },
                    { 12, 13 },
                    { 8, 14 },
                    { 11, 14 }
                });

            migrationBuilder.InsertData(
                table: "ProductsSeriesMaterials",
                columns: new[] { "MaterialId", "ProductSeriesId" },
                values: new object[,]
                {
                    { 3, 15 },
                    { 8, 15 },
                    { 14, 15 }
                });

            migrationBuilder.InsertData(
                table: "ProductsSeriesTags",
                columns: new[] { "ProductSeriesId", "TagId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "ProductsTags",
                columns: new[] { "ProductId", "TagId" },
                values: new object[,]
                {
                    { 9, 3 },
                    { 10, 3 },
                    { 15, 3 },
                    { 16, 3 },
                    { 22, 1 },
                    { 23, 1 },
                    { 26, 2 },
                    { 27, 2 },
                    { 30, 2 },
                    { 31, 2 },
                    { 43, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductsSeriesMaterials",
                columns: new[] { "MaterialId", "ProductSeriesId" },
                values: new object[,]
                {
                    { 4, 16 },
                    { 5, 16 },
                    { 8, 16 },
                    { 5, 17 },
                    { 8, 17 },
                    { 10, 17 },
                    { 11, 17 },
                    { 4, 18 },
                    { 8, 18 },
                    { 14, 18 },
                    { 3, 19 },
                    { 8, 19 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1508917d-966b-4e32-b892-47070df86ebe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e7bc6b1-b26a-4d22-8b0f-8d850006f3e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edb5df2b-e8e1-4cea-b4ef-c9f7f0333a37");

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 2, 43 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 3, 19 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 3, 34 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 3, 35 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 3, 36 });

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52335b30136c5a68bb051");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52338464ff67d85ff46a5");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5233c720097ef9dffa9ab");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523401c23834259ea6b65");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52343c1a58e96abb5c206");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523475af695148db6b205");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52349d406df65ce4b4e72");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5234ce3785f17243b411c");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5234f5a69fa9f747e5f18");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5235287a0f3693212c2a1");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523565b62f7aaf0663a98");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52359322458a957d81660");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5235bf6729604d509bc8a");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5235f274fb0fcf347d1b3");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52362ecdfe6871993e1e4");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52366fb8d548ef1e6a1cb");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5236abb6d8a6883aea6a5");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5236e334387ef86d99937");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52372fe1c9b730442e805");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523760ebe3629aa66effc");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5237b623df2b2ac3fc610");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5237ebfa052d5f7b7e3cb");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52381a7064dcc1dd461d5");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52385751a53bf32894fb4");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5238841449e1eef8fc29a");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5238d2acacb9e2043c933");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52392f6a5f8843a780460");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523961f6d033d54da856e");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5239a46383aa6559ff15e");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5239dfb4154fc78c1b5f2");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523a091c723288ab2703f");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523a27541d354f5185ecf");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523a54482b6933b4b9641");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523a8417674952ae911aa");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523ac76b19d54b131024b");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523af7736cd67efd18bca");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523b1a82f8b465badccfe");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523b4aaae78c1fb2e0f19");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523c837c5cbc84815c6b2");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523cbc940befd0ef0bbea");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523ceda1ac0b8527ffd26");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523d1c01dda3483251e4c");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523d49319f1ab11955ee0");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523e02eab219eca427579");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523e30dd3878eccd3ea1e");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523e7d30950cc175d4ee5");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523e985893af2853dbaa4");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523ed880a2cfea4e5a29a");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523f115f347b097321f2a");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523f45251d2a11816195f");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523f7a6a8571b3eb12359");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523fabe152a47636bae7d");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523fdeb4444d63ab86a55");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d523ff4215c2646cc8163e");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524022c22a7bf5d6fb592");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52405dd648aaccb6de56f");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524084074dd02c95d5612");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5240c0d0a9f46840215f4");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5240f1f6a4bf88ff5fe28");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52413ca2cdb86d5dc5061");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5241605cdc65069fb4e7c");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524194292962f1698b35d");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5241b4efab879d2b98106");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5241ec70acdc88d85b2cf");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52421cfb2a66f5536dbc6");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5242462bf6e246eef6de5");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5242760c55c37a36657d8");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5242b9278a4b37dcc630b");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5242e5935e047dede6793");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524315e7d9e628e279e40");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52434e25395fb8679db94");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5243d1a39817b5412e11d");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524415910ab1c2728156e");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524457ff5157cd75d74b1");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52448f4eb7a0a7f25a51a");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5244a9e32fb59f283d635");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5244e355f07301da86f9d");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524501bda417d5761bfca");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5245377429792e179d3bf");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52455958cb65afbfd6ae8");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5245b5f00130edb99f651");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5245e9b617cd236346b63");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52461873681ea5d64d875");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52464dac819b2d0d9651a");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52468d463b9450c90da10");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5246c78ebed5232e6790b");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5246f1c85d65d8278ed46");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52471ba01308173853a57");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524758723c98b4517d0e4");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52477d20e0caee58a1b13");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52479338c4bae74412ae2");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5247d00dfdad417f95d9a");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5247fce219f6b15944ce6");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52481af9cd319228bc03e");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524848355e8e0ca5c7c64");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524894f0d449e6e7f0be5");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5248ef11f97cf0d936c79");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52490c7197f5948d686e0");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5249591db48402680da4f");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524983f05edf1b19fbfcf");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5249cf2a4faf6783dcba7");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5249fbd5f98393548eaf3");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524a14f2def8ce5fe2053");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524a4d08826759b124b81");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524a8a106e8030a0f5810");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524ace356ce0f5b5e84c6");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524b05db296b5147b774a");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524b586fa7d40023defa1");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524b9579b4b54285e15ed");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524bc9c0bf598bdbe9551");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524bf2b882738a30506c5");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524c23a6c7f3087010b63");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524c58d113c6f7108c444");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524c8d973ed6ecd116daf");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524cb8237c4c8cab1c94d");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524ce181e34c33340dd05");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524d23b4f7df4df352f9f");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524d540e46b0cea6cc523");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524d99bb7990b020777b9");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524db4c9f4a9647db7009");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524de44d6b9ac55e41954");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524e1def6a193ed8df8f6");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524e404b5bd7f13be1c5b");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524e80992abcef8352a65");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524ebc6f3675710bbd9dd");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d524fa4584a8013259e40d");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52504405b952082fb05d1");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52507173da7d7420d2657");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5250a13661437bd07c952");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5250e6b4ba5e401ed0500");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52512e2aa2cc2c81f5b6e");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52515302802a83f0af2e0");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5251be13c2530fda92d19");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5251e9c3ab859c753c597");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d52521e58195d2403b6e15");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5252751ecfe48e09e1f15");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5252abf960bb7827bb75b");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d5252d8c5ead2168fbd1cb");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: "64d525319813433aa6afe1ac");

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 11, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 12, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 3, 17 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 13, 18 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 5, 19 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 10, 21 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 3, 22 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 4, 23 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 5, 23 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 11, 24 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 12, 24 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 9, 25 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 26 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 5, 26 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 3, 27 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 14, 27 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 10, 28 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 12, 28 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 6, 29 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 6, 30 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 8, 30 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 31 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 15, 31 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 2, 32 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 11, 33 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 14, 33 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 34 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 7, 34 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 35 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 3, 35 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 4, 35 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 4, 36 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 5, 36 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 10, 37 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 38 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 4, 39 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 5, 39 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 40 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 8, 40 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 11, 41 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 8, 42 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 3, 43 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 44 });

            migrationBuilder.DeleteData(
                table: "ProductsColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 15, 44 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 12 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 13 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 13 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 13 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 14 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 14 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 14 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 15 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 17 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 17 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 18 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 18 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 19 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 6, 19 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 19 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 9, 19 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 20 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 20 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 20 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 21 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 21 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 21 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 22 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 22 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 9, 22 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 23 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 23 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 9, 23 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 24 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 24 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 24 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 25 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 25 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 25 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 26 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 26 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 10, 26 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 11, 26 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 27 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 27 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 10, 27 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 11, 27 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 28 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 28 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 10, 28 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 11, 28 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 29 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 29 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 12, 29 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 13, 29 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 30 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 30 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 12, 30 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 31 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 31 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 12, 31 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 32 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 32 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 12, 32 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 13, 32 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 33 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 33 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 12, 33 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 13, 33 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 34 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 11, 34 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 35 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 11, 35 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 36 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 36 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 14, 36 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 37 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 37 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 37 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 38 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 38 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 38 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 39 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 39 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 10, 39 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 11, 39 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 5, 40 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 40 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 10, 40 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 11, 40 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 41 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 41 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 14, 41 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 4, 42 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 42 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 14, 42 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 43 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 43 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 3, 44 });

            migrationBuilder.DeleteData(
                table: "ProductsMaterials",
                keyColumns: new[] { "MaterialId", "ProductId" },
                keyValues: new object[] { 8, 44 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 12 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 10, 12 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 11, 12 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 5, 13 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 13 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 12, 13 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 14 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 11, 14 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 15 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 14, 15 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 5, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 16 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 5, 17 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 17 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 10, 17 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 11, 17 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 4, 18 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 18 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 14, 18 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 3, 19 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesMaterials",
                keyColumns: new[] { "MaterialId", "ProductSeriesId" },
                keyValues: new object[] { 8, 19 });

            migrationBuilder.DeleteData(
                table: "ProductsSeriesTags",
                keyColumns: new[] { "ProductSeriesId", "TagId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 23, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 26, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 27, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 30, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 31, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsTags",
                keyColumns: new[] { "ProductId", "TagId" },
                keyValues: new object[] { 43, 1 });

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2b7fab5e-82de-417f-b7dd-90e81abcceda", 0, "2007a09a-d8f2-4b48-8a08-b928d6eddb69", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEA+yYZj0Ii8spcmvxV3ixk0CWHJN/k0lzHHbtaS7deXvMeX7YpyEKY0j6Z5Fm5qcjA==", null, false, "da7b0fcd-6609-43cf-9ac1-e0e0e14b8d09", false, "admin@vls.com" },
                    { "4a1a0c6c-dd9c-49e0-8e35-d3c9738e8b11", 0, "3398a208-a57d-45ae-a762-f2344213c338", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEMEhcGWjaODxX9aq/0tmlPu41XCSt2npAnLM1ahvSEz1rdfXOjBKO6lkMDugOiiTQw==", null, false, "cc0ca0b0-e04a-4310-a121-edfd5fee24f4", false, "user@vls.com" },
                    { "c8e61ff6-0aff-4c34-9b42-042ef380b343", 0, "d230b875-97fc-4371-bd10-02a3758eb245", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEAB60EI90WEtPjEkKVKWg0H0sypHD25zPnqD9IiyBXDbHJHfPAN8/8Nv6dpvyUuD7w==", null, false, "50135b2b-cd79-4a16-ab23-0a49c69c48a9", false, "moderator@vls.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64be89ae1409e5a61554e6ed", "Jewelry" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64be8c9f41c19cda7ab19853", "Textile" });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ColorValue", "Name" },
                values: new object[] { "#ff0000", "Red" });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ColorValue", "Name" },
                values: new object[] { "#0000ff", "Blue" });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ColorValue", "Name" },
                values: new object[] { "#00ff00", "Green" });

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageId", "Name" },
                values: new object[] { "Handcrafted jewelry made of silk cocoons", "64be8c870b7f086367ebb6a5", "Silk Cocoons" });

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageId", "Name" },
                values: new object[] { "Handcrafted jewelry made of glass", "64be8c9332b088f8d6063040", "Glass" });

            migrationBuilder.InsertData(
                table: "GalleriesProducts",
                columns: new[] { "GalleryId", "ProductId", "Position" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 2 },
                    { 1, 3, 3 },
                    { 2, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId" },
                values: new object[,]
                {
                    { "64be89ae1409e5a61554e6ed", 1 },
                    { "64be8c68cac3fdf11a06fbbb", 1 },
                    { "64be8c6df878c3764a814981", 1 },
                    { "64be8c733df251037e15d70a", 2 },
                    { "64be8c7a0ef21ca57c247498", 2 },
                    { "64be8c813d909293463359d6", 2 },
                    { "64be8c870b7f086367ebb6a5", 3 },
                    { "64be8c8d7d5c466b820b73af", 3 },
                    { "64be8c9332b088f8d6063040", 4 },
                    { "64be8c99f991d074063b5098", 4 },
                    { "64be8c9f41c19cda7ab19853", 5 },
                    { "64be8ca5b7f1ea12383c364a", 5 },
                    { "64be8caa293917f47210277e", 6 },
                    { "64be8cae1813d7aff61e173b", 6 },
                    { "64be8cb3b390e17c62039322", 7 },
                    { "64be8cb81a39dd6ed0351ebb", 7 }
                });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Silver");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Steel");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Glass");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Textile");

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DefaultDescription", "DefaultName", "DefaultPrice", "Name" },
                values: new object[] { "Earrings with silver frames.", "Silver Earrings", 50.00m, "Silver Earrings" });

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DefaultDescription", "DefaultName", "DefaultPrice", "Name", "SubcategoryId" },
                values: new object[] { "Earrings with steel frames.", "Steel Earrings", 50.00m, "Steel Earrings", 1 });

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DefaultDescription", "DefaultName", "DefaultPrice", "Name", "SubcategoryId" },
                values: new object[] { "Necklace with a silver frame.", "Silver Necklace", 50.00m, "Silver Necklace", 2 });

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DefaultDescription", "DefaultName", "DefaultPrice", "Name", "SubcategoryId" },
                values: new object[] { "Ring made out of glass and silver.", "Glass Ring", 50.00m, "Glass Ring", 3 });

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DefaultDescription", "DefaultName", "DefaultPrice", "Name" },
                values: new object[] { "Hand bag with traditional sewing pattern.", "Traditional Bag", 50.00m, "Traditional Bag" });

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DefaultDescription", "DefaultName", "Name", "SubcategoryId" },
                values: new object[] { "Book binding.", "Book Binding", "Book Binding", 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Red earrings with silver frames.", "Red Silver Earrings", 50.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price", "ProductSeriesId" },
                values: new object[] { "Red-blue earrings with steel frames.", "Red-Blue Steel Earrings", 45.00m, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price", "ProductSeriesId", "SubcategoryId" },
                values: new object[] { "Green necklace with a silver frame.", "Green Silver Necklace", 35.00m, 3, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price", "ProductSeriesId", "SubcategoryId" },
                values: new object[] { "Blue ring made out of glass and silver.", "Blue Glass Ring", 25.00m, 4, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price", "ProductSeriesId", "SubcategoryId" },
                values: new object[] { "Hand bag with traditional sewing pattern.", "Traditional Hand Bag", 120.00m, 5, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Price", "ProductSeriesId", "SubcategoryId" },
                values: new object[] { "Hand bag with traditional sewing pattern.", "Traditional Hand Bag", 120.00m, 5, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "Price", "ProductSeriesId", "SubcategoryId" },
                values: new object[] { "Blue book binding.", "Blue Book Binding", 70.00m, 6, 5 });

            migrationBuilder.InsertData(
                table: "ProductsColors",
                columns: new[] { "ColorId", "ProductId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 3 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "ProductsMaterials",
                columns: new[] { "MaterialId", "ProductId" },
                values: new object[,]
                {
                    { 3, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 }
                });

            migrationBuilder.InsertData(
                table: "ProductsSeriesTags",
                columns: new[] { "ProductSeriesId", "TagId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 5, 1 },
                    { 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductsTags",
                columns: new[] { "ProductId", "TagId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 5, 1 },
                    { 6, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64be89ae1409e5a61554e6ed", "Earings" });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64be8c870b7f086367ebb6a5", "Necklaces" });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64be8c9332b088f8d6063040", "Rings" });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64be8ca5b7f1ea12383c364a", "Bags" });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageId", "Name" },
                values: new object[] { "64be8cb3b390e17c62039322", "Book Bindings" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Traditional Sewing Pattern");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Silk Cocoons");
        }
    }
}
