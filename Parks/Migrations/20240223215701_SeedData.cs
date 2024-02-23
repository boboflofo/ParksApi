using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parks.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatePark",
                columns: table => new
                {
                    StateParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatePark", x => x.StateParkId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "NationalParks",
                columns: new[] { "NationalParkId", "Name" },
                values: new object[,]
                {
                    { 3, "Volcano" },
                    { 4, "Ocean" }
                });

            migrationBuilder.InsertData(
                table: "StatePark",
                columns: new[] { "StateParkId", "Name" },
                values: new object[,]
                {
                    { 1, "Waterfall" },
                    { 2, "Mountain" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatePark");

            migrationBuilder.DeleteData(
                table: "NationalParks",
                keyColumn: "NationalParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NationalParks",
                keyColumn: "NationalParkId",
                keyValue: 4);
        }
    }
}
