using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductModel.Migrations
{
    /// <inheritdoc />
    public partial class addingGRNtablesfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRNs",
                columns: table => new
                {
                    GrnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StockUpdated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRNs", x => x.GrnID);
                });

            migrationBuilder.CreateTable(
                name: "GRNLines",
                columns: table => new
                {
                    LineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrnID = table.Column<int>(type: "int", nullable: false),
                    StockID = table.Column<int>(type: "int", nullable: false),
                    QtyDelivered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRNLines", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_GRNLines_GRNs_GrnID",
                        column: x => x.GrnID,
                        principalTable: "GRNs",
                        principalColumn: "GrnID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRNLines_Products_StockID",
                        column: x => x.StockID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRNLines_GrnID",
                table: "GRNLines",
                column: "GrnID");

            migrationBuilder.CreateIndex(
                name: "IX_GRNLines_StockID",
                table: "GRNLines",
                column: "StockID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRNLines");

            migrationBuilder.DropTable(
                name: "GRNs");
        }
    }
}
