using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class AddedAminNoteToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a03b887-a01d-48df-95ae-38083548041a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ce98453-8a6b-428f-aa1f-1ca53b8b5772");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcfc4b53-41b5-4fc7-9d47-2d0f74cd8f54");

            migrationBuilder.AddColumn<string>(
                name: "AdminNote",
                table: "Orders",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "AdminNote",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4a03b887-a01d-48df-95ae-38083548041a", 0, "3ab8b6e9-4ac3-43f2-a7f0-a63a9168d240", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEOhfy+byUGCrdP99FfXnAr5vFGyO94O+4y7xqBpOBJ25jfh/GMjUokLiZBxVYPlgzw==", null, false, "bbfd38d2-ff6a-4f11-9277-bfa1e2d41e45", false, "admin@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8ce98453-8a6b-428f-aa1f-1ca53b8b5772", 0, "2f5f845d-5333-423d-ade3-e747f672af8f", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEFQf5ES6imy1832kBzoRjzTOP0Z43FdMzF7rSygeXbk8+Tw2N98DJNvZh6nf74HpdQ==", null, false, "84f41edf-3e38-434b-a329-90d23e0ba0f4", false, "user@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dcfc4b53-41b5-4fc7-9d47-2d0f74cd8f54", 0, "0fe3c830-6629-4e10-a5b9-acf634cbc1d3", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEEk/6dT+iGduBhl4AMREWqnOMP8sNP5MlP6DYOphS2HbT9KHBnUbQa4SE5fmHqVDew==", null, false, "0aba482e-d562-42dd-b146-16c40b58d810", false, "moderator@vls.com" });
        }
    }
}
