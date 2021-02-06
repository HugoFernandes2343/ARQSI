using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class ProductHasDimensionLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Dimensions_DimensionsId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_DimensionsId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DimensionsId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Dimensions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_ProductId",
                table: "Dimensions",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dimensions_Product_ProductId",
                table: "Dimensions",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_Product_ProductId",
                table: "Dimensions");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_ProductId",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Dimensions");

            migrationBuilder.AddColumn<int>(
                name: "DimensionsId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_DimensionsId",
                table: "Product",
                column: "DimensionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Dimensions_DimensionsId",
                table: "Product",
                column: "DimensionsId",
                principalTable: "Dimensions",
                principalColumn: "DimensionsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}