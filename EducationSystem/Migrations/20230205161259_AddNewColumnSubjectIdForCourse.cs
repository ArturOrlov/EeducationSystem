using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationSystem.Migrations
{
    public partial class AddNewColumnSubjectIdForCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                schema: "Education",
                table: "Course",
                type: "integer",
                nullable: true,
                comment: "Уникальный идентификатор предмета");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectId",
                schema: "Education",
                table: "Course");
        }
    }
}
