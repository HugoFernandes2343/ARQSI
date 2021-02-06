using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class AggregBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "mandatory",
                table: "Aggregation",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mandatory",
                table: "Aggregation");
        }
    }
}
