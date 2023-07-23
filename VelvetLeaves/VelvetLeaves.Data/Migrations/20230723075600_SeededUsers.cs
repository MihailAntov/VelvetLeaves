using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class SeededUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "096e1c0c-2d77-4680-980b-1ea878007b9c", 0, "ff92dafe-64b7-45c3-a3bc-d23bc9c58b75", "admin@vls.com", false, false, null, "ADMIN@VLS.COM", "ADMIN@VLS.COM", "AQAAAAEAACcQAAAAEIaxGuaT6g7tgjbIlTUpE1GGVMBUVxNAqT0kUl4734zM+Tot6fF0r7Op0dpPMtRLMA==", null, false, "64ede6aa-79f8-4aed-b164-0d0f712405ac", false, "admin@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0c14119a-80ca-40af-b2b0-ac77f3074015", 0, "364296ba-f592-4a6b-a22e-c9b4ef9e86ba", "moderator@vls.com", false, false, null, "MODERATOR@VLS.COM", "MODERATOR@VLS.COM", "AQAAAAEAACcQAAAAEMbvrU0QJHMiW2rIIjeR1hALFIHXhSrp1SUOyDisB96d4c31zRFDVnLMuzFZKKBw8w==", null, false, "163770a9-38ca-485c-85b2-5b8745198c2a", false, "moderator@vls.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d5efb630-a753-4137-b699-b8f6d833fdd4", 0, "c31230be-a2ee-48d6-9a00-9aa279f03467", "user@vls.com", false, false, null, "USER@VLS.COM", "USER@VLS.COM", "AQAAAAEAACcQAAAAEFf3p8COJACRgb9nQsZgvL3aM71mzk+yw0mSBnskcQMhHdx8FMqcIHbZei5CNnPNbw==", null, false, "eb464959-0248-4825-8022-89c720bcc2d3", false, "user@vls.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "096e1c0c-2d77-4680-980b-1ea878007b9c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c14119a-80ca-40af-b2b0-ac77f3074015");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5efb630-a753-4137-b699-b8f6d833fdd4");
        }
    }
}
