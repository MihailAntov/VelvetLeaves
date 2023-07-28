using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class ChangedColorValueLengthAndAddedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23fc4e2f-c3e4-40df-8170-72cf715d0141");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efc37556-f79f-499f-9cda-de95fe504fc6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5c5b6e5-6f3f-49e2-8e52-ddb1c9b5a210");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "373be7c3-e75b-472b-b6b0-7ad32acc4e3d", 0, "dd212bd7-19e8-4927-9723-7ba8cdedf1bc", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEAsPRYXruoG61lNdlkuznJn1H0DjL2ITh6h8eKKhhdGN3FaOOXTYSWN+DCgEfDnM2A==", null, false, "6ff44067-db80-4dbd-8f00-23db68fb4ec3", false, "moderator@vls.com" },
                    { "c1348bf0-02fa-4d1b-9dd6-e439f2baeb4e", 0, "bd9e98a9-82ba-4a55-b531-ca8b0727d0b0", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAENnSEmN5Gf/YZ+2Bdw9Daz/vJL/8++GSBnmH3lnMLKZd1K867GLm1DZXZN0E3mhRDg==", null, false, "b025589c-0a2f-4907-a45d-f72633a49dac", false, "admin@vls.com" },
                    { "d9ed1312-6050-4a6b-b60d-8ec7c902680c", 0, "3049ad53-1596-4629-8bf0-423541979daa", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEEBsi32+JE1NIurv+SN+sexrXQ/erOZ6Yj5MqnODIxDXlk31nj1QzJQpHJ22AXcRIQ==", null, false, "26aeadd8-a411-4504-86db-646cc12641cb", false, "user@vls.com" }
                });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ColorValue",
                value: "#ff0000");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ColorValue",
                value: "#0000ff");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "ColorValue",
                value: "#00ff00");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "23fc4e2f-c3e4-40df-8170-72cf715d0141", 0, "a973dbc3-8a86-4e89-b795-d13dc4b63190", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEDQAhYHvaeVPIDf6QXyc9K47oGVW9Jz/c21BbNZy+dOE5y/os/jxW8xRSeqFD1yNGQ==", null, false, "626989ce-afbb-44a8-ac3d-b7812e4edb1c", false, "user@vls.com" },
                    { "efc37556-f79f-499f-9cda-de95fe504fc6", 0, "415d6c6e-4ee4-47c4-9b08-337d9598b270", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEBexrKRjatoRetsT2fBkW93OloFwzq/+xT435uHVdbPefk9lOYrJvyXMnxpyhWa4Gw==", null, false, "9dc3905a-7b8b-4d83-9dac-188701598f06", false, "admin@vls.com" },
                    { "f5c5b6e5-6f3f-49e2-8e52-ddb1c9b5a210", 0, "33cdcc10-acc2-4d7e-9382-6bd8ad45601a", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEEaYKyH/z8bOSrYDCceBKS8G9JOXenn0uCNTjobeiePpE7uXMhvouv5u86nPc/l7Tg==", null, false, "3f50c6df-ed77-4eb2-876e-aea319602869", false, "moderator@vls.com" }
                });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ColorValue",
                value: "ff0000");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ColorValue",
                value: "0000ff");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "ColorValue",
                value: "00ff00");
        }
    }
}
