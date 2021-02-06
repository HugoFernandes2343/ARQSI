using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class dimensionschanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Material_MaterialId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Product_ProductId1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_MaterialId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Material",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "width",
                table: "Dimensions",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "height",
                table: "Dimensions",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "depth",
                table: "Dimensions",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<double>(
                name: "maxHeight",
                table: "Dimensions",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "maxLength",
                table: "Dimensions",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "maxWidth",
                table: "Dimensions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_ProductId",
                table: "Material",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Product_ProductId",
                table: "Material",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Product_ProductId",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Material_ProductId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "maxHeight",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "maxLength",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "maxWidth",
                table: "Dimensions");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Product",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "width",
                table: "Dimensions",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "height",
                table: "Dimensions",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "depth",
                table: "Dimensions",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.CreateIndex(
                name: "IX_Product_MaterialId",
                table: "Product",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductId1",
                table: "Product",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Material_MaterialId",
                table: "Product",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Product_ProductId1",
                table: "Product",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}