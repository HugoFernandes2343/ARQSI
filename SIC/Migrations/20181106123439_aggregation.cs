using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIC.Migrations
{
    public partial class aggregation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aggregation",
                columns: table => new
                {
                    AggregationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    containedProductProductId = table.Column<int>(nullable: true),
                    containingProductProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aggregation", x => x.AggregationId);
                    table.ForeignKey(
                        name: "FK_Aggregation_Product_containedProductProductId",
                        column: x => x.containedProductProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aggregation_Product_containingProductProductId",
                        column: x => x.containingProductProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aggregation_containedProductProductId",
                table: "Aggregation",
                column: "containedProductProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Aggregation_containingProductProductId",
                table: "Aggregation",
                column: "containingProductProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aggregation");
        }
    }
}