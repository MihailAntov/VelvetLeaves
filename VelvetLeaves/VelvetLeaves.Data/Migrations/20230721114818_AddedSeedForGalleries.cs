using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class AddedSeedForGalleries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Galleries",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[] { 1, "Handcrafted jewelry made of silk cocoons", "silk.jpg", "Silk Cocoons" });

            migrationBuilder.InsertData(
                table: "Galleries",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[] { 2, "Handcrafted jewelry made of glass", "glass.jpg", "Glass" });

            migrationBuilder.InsertData(
                table: "GalleriesProducts",
                columns: new[] { "GalleryId", "ProductId", "Position" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 2 },
                    { 1, 3, 3 },
                    { 2, 4, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GalleriesProducts",
                keyColumns: new[] { "GalleryId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
