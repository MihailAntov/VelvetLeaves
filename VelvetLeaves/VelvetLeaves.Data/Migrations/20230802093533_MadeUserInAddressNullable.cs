using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class MadeUserInAddressNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "471dd061-7c7b-4ce6-be04-93679b4a8793");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f08d2b7-8595-4b5e-a59b-52ccdf175eac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "946bc073-7fe2-45ed-b17a-779307e52aeb");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4166a40c-8454-4f8c-986e-4b1d837bbccb", 0, "2c193160-4411-4185-9f6b-61cc66c2fbbe", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEHLVc7vp6HUyajTWRYIcYp9DKxrGnm2Cz1zT8Gyog2a25LIIU1VIxrywjBXEdykM5A==", null, false, "2e6c37ec-15f1-48ab-bbfd-664fd3af6de1", false, "user@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7e1c91bd-934f-4352-bd83-3f2d2b944b50", 0, "b646abbd-f2c4-4068-96d0-0348adaa633f", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEFFhok+C2u+7i6GLctOhiNsXmenZXSN9kNNfTkrBRxyk1ahBxX6txuiurw0JKrckeQ==", null, false, "df228e11-42a7-484f-94b2-559e43c27ddd", false, "moderator@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99121901-49f3-4817-98c0-3fe00985e9b5", 0, "12e58c0a-3b3f-4ef1-a806-245d82b5aab8", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEBkCj+oE88Tf9TM308lIhk7CD2RQZbo/leU+rPxXyZ4ldX+Pl6L+HFvulJ6JjykxPw==", null, false, "75a00d5f-8354-4b3a-8103-030a25698660", false, "admin@vls.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4166a40c-8454-4f8c-986e-4b1d837bbccb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e1c91bd-934f-4352-bd83-3f2d2b944b50");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99121901-49f3-4817-98c0-3fe00985e9b5");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "471dd061-7c7b-4ce6-be04-93679b4a8793", 0, "2e40f040-89ab-47b3-bcb6-86cb76ff673a", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEEpwqqxpCT6cJDr/QsWyzo9jbeO7p3wwnsO9sNLwshq1my+5q798ctvWNv0fJPqCgw==", null, false, "a4c293f5-27f1-46c4-b065-c4ab7baed17f", false, "admin@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4f08d2b7-8595-4b5e-a59b-52ccdf175eac", 0, "2e3edeec-6b15-4f48-ac45-2177d271f0cd", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEF9qDWeCS3A/8Qm1nu/at427vBVX6CCATzcICa5aehxxUm0j4f8qKe7nftiQQ/FGlg==", null, false, "7e160509-1c1d-47b2-bb6c-3703f5741282", false, "moderator@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "946bc073-7fe2-45ed-b17a-779307e52aeb", 0, "4471b2fc-ddfc-4ead-a6ba-81d1e78de824", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEAaI4Twel94W1ZJbYYG7VB5Nikm4ZtSzs4GB16TCd4ntNnwEhzLHEjbl5U7J70yvQQ==", null, false, "a9c4e7bf-ae2b-4627-92e8-c1fa45b82da7", false, "user@vls.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
