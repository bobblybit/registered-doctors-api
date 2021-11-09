using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisteredDoctors.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "registeredDoctors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Specailty = table.Column<string>(type: "TEXT", nullable: true),
                    ResgitrationNumber = table.Column<string>(type: "TEXT", nullable: true),
                    SanctionStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<string>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registeredDoctors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registeredDoctors");
        }
    }
}
