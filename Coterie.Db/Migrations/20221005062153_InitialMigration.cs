using Microsoft.EntityFrameworkCore.Migrations;

namespace Coterie.Db.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_States_LongName",
                table: "States",
                column: "LongName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
