using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class ChangedColorValueLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ColorValue",
                table: "Colors",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "23fc4e2f-c3e4-40df-8170-72cf715d0141", 0, "a973dbc3-8a86-4e89-b795-d13dc4b63190", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEDQAhYHvaeVPIDf6QXyc9K47oGVW9Jz/c21BbNZy+dOE5y/os/jxW8xRSeqFD1yNGQ==", null, false, "626989ce-afbb-44a8-ac3d-b7812e4edb1c", false, "user@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "efc37556-f79f-499f-9cda-de95fe504fc6", 0, "415d6c6e-4ee4-47c4-9b08-337d9598b270", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEBexrKRjatoRetsT2fBkW93OloFwzq/+xT435uHVdbPefk9lOYrJvyXMnxpyhWa4Gw==", null, false, "9dc3905a-7b8b-4d83-9dac-188701598f06", false, "admin@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f5c5b6e5-6f3f-49e2-8e52-ddb1c9b5a210", 0, "33cdcc10-acc2-4d7e-9382-6bd8ad45601a", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEEaYKyH/z8bOSrYDCceBKS8G9JOXenn0uCNTjobeiePpE7uXMhvouv5u86nPc/l7Tg==", null, false, "3f50c6df-ed77-4eb2-876e-aea319602869", false, "moderator@vls.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ColorValue",
                table: "Colors",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "028414b1-cdcf-47dd-9dff-5684dc7a54c5", 0, "7675c44f-52b7-4769-8ffe-bac2270ea225", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEG8Rc24APHMcWvv6pu1SAQcE/p5Je6psmyZWktWqSV/i9UL6/YVaj+l5Wxxsh8VWwg==", null, false, "74584acd-6c6f-4ebc-a7bc-6c0f02dc2a48", false, "admin@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb8e256d-7d59-4e41-9f19-1c3774592efe", 0, "2bc9d26c-bd9a-4d61-ac5b-b3119ba2e4ce", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEDkCEs/iEIhhqohGuRZ0IU8X7IbXWBdYCi9yL/B6t7Tlp5cAaJWD5UftN+Rp+wXbLg==", null, false, "5371a248-7e98-4703-a0c9-93d783c6600f", false, "user@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c73c4555-fb3a-4d2c-8d88-ed86cd73ccb0", 0, "ffa6ce3c-7e53-4b70-84a2-e917bc238c3a", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAED55B1aYLPXumDbPQUC0HoFsRvkwCfLKXzI0Y/3RHdaZhUvKHHur2c7OmK7IJ9sUTw==", null, false, "552c277d-8b7d-4e9b-a0cd-19eb5dfaeaa3", false, "moderator@vls.com" });
        }
    }
}
