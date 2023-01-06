using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationSystem.Migrations
{
    public partial class FixNamingForTableApplicationSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Описание",
                schema: "Identity",
                table: "ApplicationSettings",
                newName: "Alias");

            migrationBuilder.RenameColumn(
                name: "Имя",
                schema: "Identity",
                table: "ApplicationSettings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Значение",
                schema: "Identity",
                table: "ApplicationSettings",
                newName: "Value");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRead",
                schema: "Material",
                table: "UserLecture",
                type: "boolean",
                nullable: false,
                comment: "Статус прохождения лекции",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "todo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "Identity",
                table: "ApplicationSettings",
                newName: "Значение");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Identity",
                table: "ApplicationSettings",
                newName: "Имя");

            migrationBuilder.RenameColumn(
                name: "Alias",
                schema: "Identity",
                table: "ApplicationSettings",
                newName: "Описание");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRead",
                schema: "Material",
                table: "UserLecture",
                type: "boolean",
                nullable: false,
                comment: "todo",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "Статус прохождения лекции");
        }
    }
}
