using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class CatalogId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Catalog",
                newName: "CatalogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CatalogId",
                table: "Catalog",
                newName: "Id");
        }
    }
}