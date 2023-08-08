using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class AddedIsAvailablePropertyToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsAvailable",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Products");

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
    }
}
