using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class fixesForDtoCreations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Finish_FinishId",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Material_FinishId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "FinishId",
                table: "Material");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Finish",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Finish_MaterialId",
                table: "Finish",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Finish_Material_MaterialId",
                table: "Finish",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finish_Material_MaterialId",
                table: "Finish");

            migrationBuilder.DropIndex(
                name: "IX_Finish_MaterialId",
                table: "Finish");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Finish");

            migrationBuilder.AddColumn<int>(
                name: "FinishId",
                table: "Material",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_FinishId",
                table: "Material",
                column: "FinishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Finish_FinishId",
                table: "Material",
                column: "FinishId",
                principalTable: "Finish",
                principalColumn: "FinishId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}