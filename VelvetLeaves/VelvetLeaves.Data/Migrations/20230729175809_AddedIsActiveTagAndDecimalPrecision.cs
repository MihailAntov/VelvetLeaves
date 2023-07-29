using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class AddedIsActiveTagAndDecimalPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "373be7c3-e75b-472b-b6b0-7ad32acc4e3d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1348bf0-02fa-4d1b-9dd6-e439f2baeb4e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9ed1312-6050-4a6b-b60d-8ec7c902680c");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Subcategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProductSeries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Materials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Galleries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Colors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5aaa1e04-984e-4fbc-9f7e-f608f789a29e", 0, "f650f955-6d09-4c3c-8738-9cd75515b464", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEJ1eh0Pg1kzTYDvbEanBytZdb0zkM+BGyMJX5cPo+W5v5RORcu4m/OgmG6kBtXGVzA==", null, false, "4e0d9ad8-6adf-4ab0-a2d0-33c0b735248d", false, "admin@vls.com" },
                    { "87fa13dd-5889-44c9-9b65-0c39ccbbfbd4", 0, "3c9cb416-f96f-4bfb-90f8-ee6b08f8a219", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEF3LplmcK9fi5ftYN6KY5QjsABy/z/8B6q2vvrSLT+Dn9tP6z8bzymNkbKIOkG20og==", null, false, "1dc9f508-25b2-48ed-853c-6df779f05ed9", false, "user@vls.com" },
                    { "e255beb3-b7c3-4c27-a96f-579a32357c2b", 0, "a0ea26b9-20f1-4154-b194-d1377a9c6b42", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEMELmT95HTvAJ+enFP7NBMhEXSbaRgdTcXKbj2pdDE5ChyBjV77RyZIv/fHG3f4dag==", null, false, "3033be8c-bc41-4576-96f1-b60cd002685e", false, "moderator@vls.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductSeries",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5aaa1e04-984e-4fbc-9f7e-f608f789a29e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87fa13dd-5889-44c9-9b65-0c39ccbbfbd4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e255beb3-b7c3-4c27-a96f-579a32357c2b");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProductSeries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "373be7c3-e75b-472b-b6b0-7ad32acc4e3d", 0, "dd212bd7-19e8-4927-9723-7ba8cdedf1bc", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEAsPRYXruoG61lNdlkuznJn1H0DjL2ITh6h8eKKhhdGN3FaOOXTYSWN+DCgEfDnM2A==", null, false, "6ff44067-db80-4dbd-8f00-23db68fb4ec3", false, "moderator@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c1348bf0-02fa-4d1b-9dd6-e439f2baeb4e", 0, "bd9e98a9-82ba-4a55-b531-ca8b0727d0b0", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAENnSEmN5Gf/YZ+2Bdw9Daz/vJL/8++GSBnmH3lnMLKZd1K867GLm1DZXZN0E3mhRDg==", null, false, "b025589c-0a2f-4907-a45d-f72633a49dac", false, "admin@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d9ed1312-6050-4a6b-b60d-8ec7c902680c", 0, "3049ad53-1596-4629-8bf0-423541979daa", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEEBsi32+JE1NIurv+SN+sexrXQ/erOZ6Yj5MqnODIxDXlk31nj1QzJQpHJ22AXcRIQ==", null, false, "26aeadd8-a411-4504-86db-646cc12641cb", false, "user@vls.com" });
        }
    }
}
