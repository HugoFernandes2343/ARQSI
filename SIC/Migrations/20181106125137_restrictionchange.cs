using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class restrictionchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restriction_Product_containedProductProductId",
                table: "Restriction");

            migrationBuilder.DropForeignKey(
                name: "FK_Restriction_Product_containingProductProductId",
                table: "Restriction");

            migrationBuilder.DropIndex(
                name: "IX_Restriction_containedProductProductId",
                table: "Restriction");

            migrationBuilder.DropColumn(
                name: "containedProductProductId",
                table: "Restriction");

            migrationBuilder.RenameColumn(
                name: "containingProductProductId",
                table: "Restriction",
                newName: "AggregationId");

            migrationBuilder.RenameIndex(
                name: "IX_Restriction_containingProductProductId",
                table: "Restriction",
                newName: "IX_Restriction_AggregationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restriction_Aggregation_AggregationId",
                table: "Restriction",
                column: "AggregationId",
                principalTable: "Aggregation",
                principalColumn: "AggregationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restriction_Aggregation_AggregationId",
                table: "Restriction");

            migrationBuilder.RenameColumn(
                name: "AggregationId",
                table: "Restriction",
                newName: "containingProductProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Restriction_AggregationId",
                table: "Restriction",
                newName: "IX_Restriction_containingProductProductId");

            migrationBuilder.AddColumn<int>(
                name: "containedProductProductId",
                table: "Restriction",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_containedProductProductId",
                table: "Restriction",
                column: "containedProductProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restriction_Product_containedProductProductId",
                table: "Restriction",
                column: "containedProductProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restriction_Product_containingProductProductId",
                table: "Restriction",
                column: "containingProductProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}