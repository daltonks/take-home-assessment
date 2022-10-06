using Microsoft.EntityFrameworkCore.Migrations;

namespace Coterie.Db.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PriceFactor = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    ShortName = table.Column<string>(type: "TEXT", nullable: false),
                    LongName = table.Column<string>(type: "TEXT", nullable: false),
                    PriceFactor = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.ShortName);
                });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "Name", "PriceFactor" },
                values: new object[] { "ARCHITECT", 1m });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "Name", "PriceFactor" },
                values: new object[] { "PLUMBER", 0.5m });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "Name", "PriceFactor" },
                values: new object[] { "PROGRAMMER", 1.25m });

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

            migrationBuilder.CreateIndex(
                name: "IX_States_LongName",
                table: "States",
                column: "LongName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
