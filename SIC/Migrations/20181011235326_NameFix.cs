using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class NameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Product",
                newName: "Name");
        }
    }
}