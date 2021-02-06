using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class restrictionMAt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restriction_Material_containedMaterialMaterialId",
                table: "Restriction");

            migrationBuilder.DropForeignKey(
                name: "FK_Restriction_Material_containingMaterialMaterialId",
                table: "Restriction");

            migrationBuilder.DropIndex(
                name: "IX_Restriction_containedMaterialMaterialId",
                table: "Restriction");

            migrationBuilder.DropIndex(
                name: "IX_Restriction_containingMaterialMaterialId",
                table: "Restriction");

            migrationBuilder.DropColumn(
                name: "containedMaterialMaterialId",
                table: "Restriction");

            migrationBuilder.DropColumn(
                name: "containingMaterialMaterialId",
                table: "Restriction");

            migrationBuilder.AddColumn<int>(
                name: "containedMaterial",
                table: "Restriction",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "containingMaterial",
                table: "Restriction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "containedMaterial",
                table: "Restriction");

            migrationBuilder.DropColumn(
                name: "containingMaterial",
                table: "Restriction");

            migrationBuilder.AddColumn<int>(
                name: "containedMaterialMaterialId",
                table: "Restriction",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "containingMaterialMaterialId",
                table: "Restriction",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_containedMaterialMaterialId",
                table: "Restriction",
                column: "containedMaterialMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_containingMaterialMaterialId",
                table: "Restriction",
                column: "containingMaterialMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restriction_Material_containedMaterialMaterialId",
                table: "Restriction",
                column: "containedMaterialMaterialId",
                principalTable: "Material",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restriction_Material_containingMaterialMaterialId",
                table: "Restriction",
                column: "containingMaterialMaterialId",
                principalTable: "Material",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}