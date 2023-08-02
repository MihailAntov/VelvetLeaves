using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class MadeZipCodeString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38b01a65-9ff5-40f5-b6dc-db506b06b964");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a6d23e6d-83fe-41bb-9d73-1d04aec4d56c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8eb2df5-8f9c-4eef-9b8a-19f0260a0b01");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Addresses",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "38b01a65-9ff5-40f5-b6dc-db506b06b964", 0, "4c35a003-c624-4952-b555-b54c4bf213f2", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEPC5IWEn6voDizaDSQEbpqyWRerZiXMsBjfXoZ2tn8z8eTFpeZ2ndCHKS7pnfd0WkA==", null, false, "4f957686-79be-4c59-9afd-6460a5c68d1a", false, "user@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a6d23e6d-83fe-41bb-9d73-1d04aec4d56c", 0, "ddc2b77f-01bb-4674-bd6b-a28b3c2bcc61", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEMb16uSEw1i9JgUjBnXwpjYWUgeL13aj5jJlhS/XdahZLa3JLrPwz8dyTk9y00dHcQ==", null, false, "920c4a7f-4a2f-4492-aa3e-b059314b29e3", false, "admin@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d8eb2df5-8f9c-4eef-9b8a-19f0260a0b01", 0, "f46335f3-77d6-4705-9c3e-5ca57e04dd19", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEIA61EsotEyK392gG0grdteQaW6nkS6pLxzXTSSJOM5TrwlAOXUz1Zl5w/fi+02/ZQ==", null, false, "6c91e300-0f96-403c-9898-5bcf00d26f23", false, "moderator@vls.com" });
        }
    }
}
