using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class AddedEmailToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(320)",
                maxLength: 320,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "66a294f3-dcb2-4fdb-bc3e-9ab2b66cfbf7", 0, "ad775b56-5b0b-4ac1-a33d-25ba48925019", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEN1cLiWcC3LpYK00gfAN6sE/Eb4TxlvmWC1rxgpT2hcErIB6ettGP5ugpNPn1N2z1w==", null, false, "12994dc2-a1b7-4ae9-ace3-7d3d74fc4e8c", false, "admin@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b4095d53-0cbd-4286-9d4b-0254fa083bda", 0, "105aff70-b00b-4eaa-bfc8-6a27f0530a92", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAECmid62ORJpCE8BYdTBQfkAufinR1aO6DMcIVJ6P8ZTiEdbHEmMi9sDJDk5D1S4LtA==", null, false, "7f584e9e-2fb2-4286-bc7b-e97de261168a", false, "moderator@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e60e1249-4044-4345-8c61-87b8b3df9df4", 0, "b34eb7ce-06c4-4a8f-8cff-a44738511dc0", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEKvdQntoAAdQALjJXVACkFkewAIWs3/Uj9y3AMABCfttjsjKoHfgKoodhzFKGD2Hqw==", null, false, "e98027c4-e1e2-44db-ba10-bb10c2453c1a", false, "user@vls.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66a294f3-dcb2-4fdb-bc3e-9ab2b66cfbf7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4095d53-0cbd-4286-9d4b-0254fa083bda");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e60e1249-4044-4345-8c61-87b8b3df9df4");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

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
        }
    }
}
