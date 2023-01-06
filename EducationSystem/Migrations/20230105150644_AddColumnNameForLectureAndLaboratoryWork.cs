using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationSystem.Migrations
{
    public partial class AddColumnNameForLectureAndLaboratoryWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Material",
                table: "Lecture",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Название лекции");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Material",
                table: "LaboratoryWork",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Название лабораторной работы");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Material",
                table: "Lecture");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Material",
                table: "LaboratoryWork");
        }
    }
}
