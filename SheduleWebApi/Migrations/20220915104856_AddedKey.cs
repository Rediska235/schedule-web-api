using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheduleWebApi.Migrations
{
    public partial class AddedKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DayOfWeek",
                table: "shedule",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shedule",
                table: "shedule",
                column: "DayOfWeek");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_shedule",
                table: "shedule");

            migrationBuilder.AlterColumn<int>(
                name: "DayOfWeek",
                table: "shedule",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
