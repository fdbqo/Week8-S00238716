using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductModel.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GRNs",
                columns: new[] { "GrnID", "DeliveryDate", "OrderDate", "StockUpdated" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 2, null, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false }
                });

            migrationBuilder.InsertData(
                table: "GRNLines",
                columns: new[] { "LineID", "GrnID", "QtyDelivered", "StockID" },
                values: new object[,]
                {
                    { 1, 1, 20, 1 },
                    { 2, 1, 40, 2 },
                    { 3, 1, 70, 3 },
                    { 4, 2, 20, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GRNLines",
                keyColumn: "LineID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GRNLines",
                keyColumn: "LineID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GRNLines",
                keyColumn: "LineID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GRNLines",
                keyColumn: "LineID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GRNs",
                keyColumn: "GrnID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GRNs",
                keyColumn: "GrnID",
                keyValue: 2);
        }
    }
}
