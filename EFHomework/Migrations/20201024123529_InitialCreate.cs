using Microsoft.EntityFrameworkCore.Migrations;

namespace EFHomework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Технической кибернетики" });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Мостов и тунелей" });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[] { 1, 1, "1488" });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[] { 2, 1, "653" });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[] { 3, 2, "КБ12" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "GroupId", "Name" },
                values: new object[] { 1, 23, 1, "Tom" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "GroupId", "Name" },
                values: new object[] { 2, 26, 1, "Alice" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "GroupId", "Name" },
                values: new object[] { 3, 20, 2, "Nick" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "GroupId", "Name" },
                values: new object[] { 4, 21, 2, "Sam" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "GroupId", "Name" },
                values: new object[] { 5, 28, 3, "Jesus" });

            migrationBuilder.CreateIndex(
                name: "IX_Group_FacultyId",
                table: "Group",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GroupId",
                table: "Student",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
