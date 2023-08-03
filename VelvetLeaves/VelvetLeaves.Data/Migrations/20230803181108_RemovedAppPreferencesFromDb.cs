using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class RemovedAppPreferencesFromDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "AppPreferences");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1b8b96a-c2ca-409b-9d23-80855b84f9ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d76adc46-5a07-49f6-9645-f3c1e9d4a0b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d82872c1-2583-44b9-991e-2270986761ef");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3cb17ce6-4a99-47c1-9c6f-a8b71b2d1414", 0, "813f88b4-f2d2-421c-8f22-18a3e20e2174", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEN4xVtxAr01MW7/r62fS/jcEvVeL0/zACYrwxWl16kajyfWsEUmkHQzx1A2L1R02Pw==", null, false, "61e59d93-15d9-42c3-a951-e281547c2f8c", false, "moderator@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ac83cf6a-e0d4-4009-9580-a9c9fc410c5a", 0, "5444c603-75c5-4ca7-8688-beede2638ba7", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEKqfDYT9Kl1bHU66ZXWGOeBr4W/CbEfyhm7XhLT2wVvZTVRPVod/VLrNZbbSi2hRuw==", null, false, "b9cfbf6a-a753-4798-ba48-f37335c1dbff", false, "user@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aef40c39-19bd-461b-b2ec-6dfad82fa5e0", 0, "3b9e2e23-4055-4660-85fe-e47dd7834733", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEHew0h63e7kEVdi+qhnTQfj5fa35xX4GfgJcsgbHqcjGJeH/vlhRg418xHJ4ik0Kpw==", null, false, "23d06423-9e97-418e-9508-76697f933661", false, "admin@vls.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cb17ce6-4a99-47c1-9c6f-a8b71b2d1414");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac83cf6a-e0d4-4009-9580-a9c9fc410c5a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aef40c39-19bd-461b-b2ec-6dfad82fa5e0");

            migrationBuilder.CreateTable(
                name: "AppPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackgroundUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaviconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RootProductsName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPreferences", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d1b8b96a-c2ca-409b-9d23-80855b84f9ea", 0, "dea8a58f-508e-475d-85cc-fb7fa03685c5", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEAC+3vefkrtAYPaQ8ZTSl6ayNcv+xl+omwpgPT8H4sC7lmq9BudRfn/MZ4nZ2B8Rtw==", null, false, "ead830c5-46f6-4680-bf27-58d58e8e004b", false, "admin@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d76adc46-5a07-49f6-9645-f3c1e9d4a0b4", 0, "37db7612-9a36-4af5-81e8-40b0524a6f58", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEK7thiO6OI+MHtAtzlCpXLza8nSpGmsnbyEO9pSKw98RjLiBXMck82uiFbacXP6EGA==", null, false, "6d4a9768-f165-4e98-9a89-0943fb5c368a", false, "user@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d82872c1-2583-44b9-991e-2270986761ef", 0, "7dd9e859-034c-448c-97a3-b780cf04421c", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEJ3IZXL3Ctrxvi5kON9JsaK4R1SJSZ9O+FqBUA2e+X+LOxbsEf03B6kjiEbblw13Og==", null, false, "b8dd8cf0-f62a-4f39-8ec6-09744e41b2ec", false, "moderator@vls.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
