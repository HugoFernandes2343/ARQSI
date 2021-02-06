using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class CategoryRestucture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_CategoryId1",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Category",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CategoryId1",
                table: "Category",
                newName: "fatherCatCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_CategoryId1",
                table: "Category",
                newName: "IX_Category_fatherCatCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_fatherCatCategoryId",
                table: "Category",
                column: "fatherCatCategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_fatherCatCategoryId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Category",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "fatherCatCategoryId",
                table: "Category",
                newName: "CategoryId1");

            migrationBuilder.RenameIndex(
                name: "IX_Category_fatherCatCategoryId",
                table: "Category",
                newName: "IX_Category_CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_CategoryId1",
                table: "Category",
                column: "CategoryId1",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}