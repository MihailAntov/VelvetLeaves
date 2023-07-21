using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetLeaves.Data.Migrations
{
    public partial class AddedProductSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductSeriesId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DefaultDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DefaultPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DefaultName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSeries_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorProductSeries",
                columns: table => new
                {
                    DefaultColorsId = table.Column<int>(type: "int", nullable: false),
                    ProductSeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorProductSeries", x => new { x.DefaultColorsId, x.ProductSeriesId });
                    table.ForeignKey(
                        name: "FK_ColorProductSeries_Colors_DefaultColorsId",
                        column: x => x.DefaultColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorProductSeries_ProductSeries_ProductSeriesId",
                        column: x => x.ProductSeriesId,
                        principalTable: "ProductSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsSeriesMaterials",
                columns: table => new
                {
                    ProductSeriesId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSeriesMaterials", x => new { x.ProductSeriesId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_ProductsSeriesMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsSeriesMaterials_ProductSeries_ProductSeriesId",
                        column: x => x.ProductSeriesId,
                        principalTable: "ProductSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsSeriesTags",
                columns: table => new
                {
                    ProductSeriesId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSeriesTags", x => new { x.ProductSeriesId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductsSeriesTags_ProductSeries_ProductSeriesId",
                        column: x => x.ProductSeriesId,
                        principalTable: "ProductSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsSeriesTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductSeries",
                columns: new[] { "Id", "DefaultDescription", "DefaultName", "DefaultPrice", "Name", "SubcategoryId" },
                values: new object[,]
                {
                    { 1, "Earrings with silver frames.", "Silver Earrings", 50.00m, "Silver Earrings", 1 },
                    { 2, "Earrings with steel frames.", "Steel Earrings", 50.00m, "Steel Earrings", 1 },
                    { 3, "Necklace with a silver frame.", "Silver Necklace", 50.00m, "Silver Necklace", 2 },
                    { 4, "Ring made out of glass and silver.", "Glass Ring", 50.00m, "Glass Ring", 3 },
                    { 5, "Hand bag with traditional sewing pattern.", "Traditional Bag", 50.00m, "Traditional Bag", 4 },
                    { 6, "Book binding.", "Book Binding", 50.00m, "Book Binding", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductSeriesId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductSeriesId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductSeriesId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductSeriesId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProductSeriesId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductSeriesId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProductSeriesId",
                value: 6);

            migrationBuilder.InsertData(
                table: "ProductsSeriesMaterials",
                columns: new[] { "MaterialId", "ProductSeriesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 1, 3 },
                    { 3, 4 },
                    { 4, 5 },
                    { 4, 6 }
                });

            migrationBuilder.InsertData(
                table: "ProductsSeriesTags",
                columns: new[] { "ProductSeriesId", "TagId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 5, 1 },
                    { 6, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSeriesId",
                table: "Products",
                column: "ProductSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorProductSeries_ProductSeriesId",
                table: "ColorProductSeries",
                column: "ProductSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSeries_SubcategoryId",
                table: "ProductSeries",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSeriesMaterials_MaterialId",
                table: "ProductsSeriesMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSeriesTags_TagId",
                table: "ProductsSeriesTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSeries_ProductSeriesId",
                table: "Products",
                column: "ProductSeriesId",
                principalTable: "ProductSeries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSeries_ProductSeriesId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ColorProductSeries");

            migrationBuilder.DropTable(
                name: "ProductsSeriesMaterials");

            migrationBuilder.DropTable(
                name: "ProductsSeriesTags");

            migrationBuilder.DropTable(
                name: "ProductSeries");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductSeriesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductSeriesId",
                table: "Products");
        }
    }
}
