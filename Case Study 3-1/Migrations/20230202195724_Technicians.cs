using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaseStudy31.Migrations
{
    /// <inheritdoc />
    public partial class Technicians : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "Email", "PhoneNumber", "TechnicianName" },
                values: new object[,]
                {
                    { 1, "alison@sportsprosoftware.com", "800-555-0443", "Alison Diaz" },
                    { 2, "awilson@sportsprosoftware.com", "800-555-0449", "Andrew Wilson" },
                    { 3, "gfiori@sportsprosoftware.com", "800-555-0459", "Gina Fiori" },
                    { 4, "gunter@sportsprosoftware.com", "800-555-0400", "Gunter Wendt" },
                    { 5, "jason@sportsprosoftware.com", "800-555-0444", "Jason Lee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Technicians");
        }
    }
}
