using Microsoft.EntityFrameworkCore.Migrations;

namespace Coterie.Db.Migrations
{
    public partial class StateHasDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "ShortName", "LongName", "PriceFactor" },
                values: new object[] { "FL", "FLORIDA", 1.2m });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "ShortName", "LongName", "PriceFactor" },
                values: new object[] { "OH", "OHIO", 1m });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "ShortName", "LongName", "PriceFactor" },
                values: new object[] { "TX", "TEXAS", 0.943m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "ShortName",
                keyValue: "FL");

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "ShortName",
                keyValue: "OH");

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "ShortName",
                keyValue: "TX");
        }
    }
}
