using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class MaterialAndFinishUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "finish",
                table: "Material");

            migrationBuilder.AddColumn<int>(
                name: "FinishId",
                table: "Material",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Finish",
                columns: table => new
                {
                    FinishId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finish", x => x.FinishId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Finish_FinishId",
                table: "Material");

            migrationBuilder.DropTable(
                name: "Finish");

            migrationBuilder.DropIndex(
                name: "IX_Material_FinishId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "FinishId",
                table: "Material");

            migrationBuilder.AddColumn<string>(
                name: "finish",
                table: "Material",
                nullable: true);
        }
    }
}