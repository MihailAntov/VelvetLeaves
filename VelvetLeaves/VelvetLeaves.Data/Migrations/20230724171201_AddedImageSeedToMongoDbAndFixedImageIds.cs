using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class AddedImageSeedToMongoDbAndFixedImageIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b97bc22-e107-4d1b-8822-6f078cb429b2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85c09e2a-381e-4a5b-a181-9145d15f30a1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f90863a7-c2f1-4b99-861a-d9ed65f4896c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "028414b1-cdcf-47dd-9dff-5684dc7a54c5", 0, "7675c44f-52b7-4769-8ffe-bac2270ea225", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEG8Rc24APHMcWvv6pu1SAQcE/p5Je6psmyZWktWqSV/i9UL6/YVaj+l5Wxxsh8VWwg==", null, false, "74584acd-6c6f-4ebc-a7bc-6c0f02dc2a48", false, "admin@vls.com" },
                    { "bb8e256d-7d59-4e41-9f19-1c3774592efe", 0, "2bc9d26c-bd9a-4d61-ac5b-b3119ba2e4ce", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEDkCEs/iEIhhqohGuRZ0IU8X7IbXWBdYCi9yL/B6t7Tlp5cAaJWD5UftN+Rp+wXbLg==", null, false, "5371a248-7e98-4703-a0c9-93d783c6600f", false, "user@vls.com" },
                    { "c73c4555-fb3a-4d2c-8d88-ed86cd73ccb0", 0, "ffa6ce3c-7e53-4b70-84a2-e917bc238c3a", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAED55B1aYLPXumDbPQUC0HoFsRvkwCfLKXzI0Y/3RHdaZhUvKHHur2c7OmK7IJ9sUTw==", null, false, "552c277d-8b7d-4e9b-a0cd-19eb5dfaeaa3", false, "moderator@vls.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageId",
                value: "64be89ae1409e5a61554e6ed");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageId",
                value: "64be8c9f41c19cda7ab19853");

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageId",
                value: "64be8c870b7f086367ebb6a5");

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageId",
                value: "64be8c9332b088f8d6063040");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageId",
                value: "64be89ae1409e5a61554e6ed");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageId",
                value: "64be8c870b7f086367ebb6a5");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageId",
                value: "64be8c9332b088f8d6063040");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageId",
                value: "64be8ca5b7f1ea12383c364a");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageId",
                value: "64be8cb3b390e17c62039322");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "028414b1-cdcf-47dd-9dff-5684dc7a54c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb8e256d-7d59-4e41-9f19-1c3774592efe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c73c4555-fb3a-4d2c-8d88-ed86cd73ccb0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0b97bc22-e107-4d1b-8822-6f078cb429b2", 0, "a3b4ac42-0480-415a-90c3-234e94376992", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEK8x073UBVnqzO2UkfTbQbtVffjW1AyymKoc5EfFm2Sr+VyMLeFEgrVsKLqrvYl3+w==", null, false, "6d0dc55b-a9dc-4f1a-81a6-95c3d1f89f86", false, "moderator@vls.com" },
                    { "85c09e2a-381e-4a5b-a181-9145d15f30a1", 0, "83789666-db0f-4884-bbdc-1ff952e18d82", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEKNxhqg+2YQaOjBBEauNXI2pLjsOKUEIjJCqe3SKjjrB691FIkOKIo72mVOEcxIGlw==", null, false, "d863cedc-8edc-470f-8f3c-f430d12ca1df", false, "admin@vls.com" },
                    { "f90863a7-c2f1-4b99-861a-d9ed65f4896c", 0, "6f03b79b-e4f5-45f5-aa4a-a4a3ab4b6ec4", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEGxypKGRYeuGx0se8MJbKspdgQc7iL93GlRA7Mf6GW7Jwu6YbA9gpnpjHG8b/iX/sQ==", null, false, "53bcf490-8555-4c67-869f-1cb2f276ed6b", false, "user@vls.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageId",
                value: "jewelry.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageId",
                value: "textile.jpg");

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageId",
                value: "silk.jpg");

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageId",
                value: "glass.jpg");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageId",
                value: "jewelry.jpg");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageId",
                value: "jewelry.jpg");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageId",
                value: "jewelry.jpg");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageId",
                value: "bag.jpg");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageId",
                value: "bag.jpg");
        }
    }
}
