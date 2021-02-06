using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class MaxDepth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "maxLength",
                table: "Dimensions",
                newName: "maxDepth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "maxDepth",
                table: "Dimensions",
                newName: "maxLength");
        }
    }
}