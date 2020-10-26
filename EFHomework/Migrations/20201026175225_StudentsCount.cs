using Microsoft.EntityFrameworkCore.Migrations;

namespace EFHomework.Migrations
{
    public partial class StudentsCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentsCount",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentsCount",
                table: "Faculties",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentsCount",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "StudentsCount",
                table: "Faculties");
        }
    }
}
