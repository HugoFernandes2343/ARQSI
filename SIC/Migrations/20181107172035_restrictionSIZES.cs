using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class restrictionSIZES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "Restriction",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "x",
                table: "Restriction",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "y",
                table: "Restriction",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "z",
                table: "Restriction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "x",
                table: "Restriction");

            migrationBuilder.DropColumn(
                name: "y",
                table: "Restriction");

            migrationBuilder.DropColumn(
                name: "z",
                table: "Restriction");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "Restriction",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}