using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheduleWebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shedule",
                columns: table => new
                {
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    First = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Second = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Third = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fourth = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shedule");
        }
    }
}
