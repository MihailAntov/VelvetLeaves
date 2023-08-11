using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class AddedCategoryIdsAndProductSeriesIdsToSeedAsWellAsBgImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "497da242-65b3-4e4f-bb35-d8cb130eb9b0", 0, "ca8662f1-d125-48da-a318-1c7589339165", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEJrL/8pVP2ic7i1CtkLYyXqBJpcunnIwCj4cfhPUB96HVsJ37G3F2cVqIMTskAhTeg==", null, false, "9ef084f2-a0ef-4c26-82b1-be88fb4a5f3f", false, "user@vls.com" },
                    { "e6a9b8a9-b386-4787-a39b-c8ee6a9c3a81", 0, "000e5ee2-4a39-42f6-b193-0350c7e5a805", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEKeSIfl/Bxc9t/VEXrPNIFijay5HKH6a6rPUUa2eV/8HvFc+ErIiFMwhO8JecpBa6w==", null, false, "0ccb3310-feaa-46f7-b2c6-cfb0d7343fa7", false, "admin@vls.com" },
                    { "f3010072-8c38-41f1-ac7e-ae5810f4b1bd", 0, "c93a0161-7b98-4484-b4f0-63880e17ea2f", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAECTnbz3R/ZZdAFSJRHLD/c/hcf4IoFliUW3sraenZlDfPP6V6e767lsWVOZoudOruA==", null, false, "06bca385-19d0-4ba9-a17d-cca08aee3c1b", false, "moderator@vls.com" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 5, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 5, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 5, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 5, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 5, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 5, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 6, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 6, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 7, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 7, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 8, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 9, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 9, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 10, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 10, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 11, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 11, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 12, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 12, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 12, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 13, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 13, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 13, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 13, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 13, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 14, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 14, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 15, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 16, 6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 16, 6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 17, 6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 17, 6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 18, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 18, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 19, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 19, 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "497da242-65b3-4e4f-bb35-d8cb130eb9b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6a9b8a9-b386-4787-a39b-c8ee6a9c3a81");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3010072-8c38-41f1-ac7e-ae5810f4b1bd");

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
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ProductSeriesId", "SubcategoryId" },
                values: new object[] { 1, 1 });
        }
    }
}
