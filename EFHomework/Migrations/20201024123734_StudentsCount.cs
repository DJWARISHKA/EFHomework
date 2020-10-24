using Microsoft.EntityFrameworkCore.Migrations;

namespace EFHomework.Migrations
{
    public partial class StudentsCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentsCount",
                table: "Group",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentsCount",
                table: "Faculty",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: 1,
                column: "StudentsCount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: 2,
                column: "StudentsCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1,
                column: "StudentsCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 2,
                column: "StudentsCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3,
                column: "StudentsCount",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentsCount",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "StudentsCount",
                table: "Faculty");
        }
    }
}
