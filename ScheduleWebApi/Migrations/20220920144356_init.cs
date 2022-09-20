using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleWebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    DayOfWeek = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Second = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Third = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fourth = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.DayOfWeek);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");
        }
    }
}
