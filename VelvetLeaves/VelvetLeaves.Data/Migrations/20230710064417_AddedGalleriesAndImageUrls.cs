using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class AddedGalleriesAndImageUrls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Subcategory",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Product",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Category",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GalleryProduct",
                columns: table => new
                {
                    GalleryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryProduct", x => new { x.GalleryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_GalleryProduct_Gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Gallery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalleryProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryProduct_ProductId",
                table: "GalleryProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryProduct");

            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Subcategory");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Category");
        }
    }
}
