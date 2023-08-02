using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class AddedPhoneAndNamesToAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19bf656d-f94d-45ae-8c3b-703245256515");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "484f6a04-bdb0-4c4e-97ee-7c50186f529b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "846a280a-67d3-4fca-aa87-09f1f544a95d");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Addresses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Addresses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Addresses",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Addresses");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "19bf656d-f94d-45ae-8c3b-703245256515", 0, "1f01fe15-c1e6-4fad-a83b-51cf925f3e1c", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEDlqSVcWtrl4OUDlFLPuyWjyFxBHexv6RXumdvJmuqP8n6W4bc+Rcg2TUprO3CgtTw==", null, false, "9ddc5770-81a9-4f3c-85a4-15798ecf359a", false, "moderator@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "484f6a04-bdb0-4c4e-97ee-7c50186f529b", 0, "0d248817-33da-41d6-8feb-8ef85435965e", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEMgZefLKlCg18O9yQ/IaxDVh8eEs9Y52WTagu2L7NeXTXwK2C6UKrJHeqwCW3+AuSA==", null, false, "b0033406-cce9-46cd-96f6-0fdfa55e05bf", false, "user@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "846a280a-67d3-4fca-aa87-09f1f544a95d", 0, "f78fe31c-7931-42f2-8177-60a337677699", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEIG6vNhLx4TJ7exaEQQGpwEz6KfLKjKxt8rxZfapFdzJnZqjHFyfc3ud1hsBeLKiUg==", null, false, "27f24625-3fbf-4b44-9264-41fbaf0fdb7f", false, "admin@vls.com" });
        }
    }
}
