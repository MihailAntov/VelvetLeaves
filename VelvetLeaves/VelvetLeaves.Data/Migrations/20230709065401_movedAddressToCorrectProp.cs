using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class movedAddressToCorrectProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Product_ProductId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ProductId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Address",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_ApplicationUserId",
                table: "Address",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_ApplicationUserId",
                table: "Address",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_ApplicationUserId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ApplicationUserId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_ProductId",
                table: "Address",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Product_ProductId",
                table: "Address",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
