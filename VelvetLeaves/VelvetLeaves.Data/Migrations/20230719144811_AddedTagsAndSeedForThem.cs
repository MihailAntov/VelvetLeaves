using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class AddedTagsAndSeedForThem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsTags",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsTags", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductsTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Red earrings with silver frames.", "Red Silver Earrings" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Red-blue earrings with steel frames.", "Red-Blue Steel Earrings" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Blue book binding.");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Traditional Sewing Pattern" },
                    { 2, "Silk Cocoons" }
                });

            migrationBuilder.InsertData(
                table: "ProductsTags",
                columns: new[] { "ProductId", "TagId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 5, 1 },
                    { 6, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTags_TagId",
                table: "ProductsTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Red earings with silver frames.", "Red Silver Earings" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Red-blue earings with steel frames.", "Red-Blue Steel Earings" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Blue book binding with traditional sewing pattern.");
        }
    }
}
