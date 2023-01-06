using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EducationSystem.Migrations
{
    public partial class AddNewTablesAndColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_DeviceId",
                schema: "Identity",
                table: "RefreshToken");

            migrationBuilder.EnsureSchema(
                name: "Education");

            migrationBuilder.EnsureSchema(
                name: "Material");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "VerificationToken",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "VerificationToken",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "UserRole",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "UserRole",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "UserInfo",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "UserInfo",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                schema: "Identity",
                table: "UserInfo",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Дата рождения пользователя",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldComment: "Дата рождения пользователя");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "UserClaim",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "UserClaim",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "RoleClaim",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "RoleClaim",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "Role",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Role",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "RefreshToken",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                schema: "Identity",
                table: "RefreshToken",
                type: "timestamp without time zone",
                nullable: false,
                comment: "Время истечения рефреш токена",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldComment: "Время истечения рефреш токена");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                schema: "Identity",
                table: "RefreshToken",
                type: "integer",
                nullable: false,
                comment: "Id устройства с которого был выполнен вход",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Id устройства");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "RefreshToken",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "Device",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginTime",
                schema: "Identity",
                table: "Device",
                type: "timestamp without time zone",
                nullable: false,
                comment: "Последние время входа в систему",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldComment: "Последние время входа в систему");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Device",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "ApplicationSettings",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "ApplicationSettings",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<string>(
                name: "Значение",
                schema: "Identity",
                table: "ApplicationSettings",
                type: "text",
                nullable: false,
                comment: "Значение настройки",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Имя",
                schema: "Identity",
                table: "ApplicationSettings",
                type: "text",
                nullable: false,
                comment: "Имя (название) настройки",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Описание",
                schema: "Identity",
                table: "ApplicationSettings",
                type: "text",
                nullable: false,
                comment: "Описание",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Course",
                schema: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор сущности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Название курса"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "Статус доступа к курсу"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата создания сущности"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата последнего обновления сущности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                schema: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор сущности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Название предмета"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата создания сущности"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата последнего обновления сущности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryWork",
                schema: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор сущности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор курса"),
                    MaterialUrl = table.Column<string>(type: "text", nullable: false, comment: "Ссылка на материал лабораторной работы"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "Статус доступа к курсу"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата создания сущности"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата последнего обновления сущности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryWork", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryWork_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Education",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lecture",
                schema: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор сущности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор курса"),
                    MaterialUrl = table.Column<string>(type: "text", nullable: false, comment: "Ссылка на материал лекции"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "Статус доступа к курсу"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата создания сущности"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата последнего обновления сущности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecture_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Education",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                schema: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор сущности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Название теста"),
                    Description = table.Column<string>(type: "text", nullable: false, comment: "Описание теста"),
                    CourseId = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор курса"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "Статус доступа к тесту"),
                    TimeForQuestion = table.Column<TimeSpan>(type: "interval", nullable: false, comment: "Время на один ответ"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата создания сущности"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата последнего обновления сущности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Education",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLaboratoryWork",
                schema: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор сущности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор пользователя"),
                    LaboratoryWorkId = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор леции"),
                    Value = table.Column<float>(type: "real", nullable: true, comment: "todo"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата создания сущности"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата последнего обновления сущности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLaboratoryWork", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLaboratoryWork_LaboratoryWork_LaboratoryWorkId",
                        column: x => x.LaboratoryWorkId,
                        principalSchema: "Material",
                        principalTable: "LaboratoryWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLaboratoryWork_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLecture",
                schema: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор сущности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор пользователя"),
                    LectureId = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор леции"),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false, comment: "todo"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата создания сущности"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата последнего обновления сущности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLecture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLecture_Lecture_LectureId",
                        column: x => x.LectureId,
                        principalSchema: "Material",
                        principalTable: "Lecture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLecture_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestion",
                schema: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор сущности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestId = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор теста"),
                    QuestionDescription = table.Column<string>(type: "text", nullable: false, comment: "Описание вопроса теста"),
                    Image = table.Column<string>(type: "text", nullable: false, comment: "Изображение для вопроса"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата создания сущности"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата последнего обновления сущности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestQuestion_Test_TestId",
                        column: x => x.TestId,
                        principalSchema: "Material",
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTestResult",
                schema: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор сущности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор пользовтеля"),
                    TestId = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор теста"),
                    Value = table.Column<float>(type: "real", nullable: false, comment: "Оценка по количеству правильных ответов"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата создания сущности"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата последнего обновления сущности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTestResult_Test_TestId",
                        column: x => x.TestId,
                        principalSchema: "Material",
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTestResult_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestAnswer",
                schema: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор сущности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestQuestionId = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор вопроса теста"),
                    QuestionAnswer = table.Column<string>(type: "text", nullable: false, comment: "Описание ответа"),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false, comment: "Флаг. является ли ответ правильным"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата создания сущности"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()", comment: "Дата последнего обновления сущности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAnswer_TestQuestion_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalSchema: "Material",
                        principalTable: "TestQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_DeviceId",
                schema: "Identity",
                table: "RefreshToken",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryWork_CourseId",
                schema: "Material",
                table: "LaboratoryWork",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_CourseId",
                schema: "Material",
                table: "Lecture",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_CourseId",
                schema: "Material",
                table: "Test",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswer_TestQuestionId",
                schema: "Material",
                table: "TestAnswer",
                column: "TestQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestion_TestId",
                schema: "Material",
                table: "TestQuestion",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratoryWork_LaboratoryWorkId",
                schema: "Material",
                table: "UserLaboratoryWork",
                column: "LaboratoryWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratoryWork_UserId",
                schema: "Material",
                table: "UserLaboratoryWork",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLecture_LectureId",
                schema: "Material",
                table: "UserLecture",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLecture_UserId",
                schema: "Material",
                table: "UserLecture",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestResult_TestId",
                schema: "Material",
                table: "UserTestResult",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestResult_UserId",
                schema: "Material",
                table: "UserTestResult",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subject",
                schema: "Education");

            migrationBuilder.DropTable(
                name: "TestAnswer",
                schema: "Material");

            migrationBuilder.DropTable(
                name: "UserLaboratoryWork",
                schema: "Material");

            migrationBuilder.DropTable(
                name: "UserLecture",
                schema: "Material");

            migrationBuilder.DropTable(
                name: "UserTestResult",
                schema: "Material");

            migrationBuilder.DropTable(
                name: "TestQuestion",
                schema: "Material");

            migrationBuilder.DropTable(
                name: "LaboratoryWork",
                schema: "Material");

            migrationBuilder.DropTable(
                name: "Lecture",
                schema: "Material");

            migrationBuilder.DropTable(
                name: "Test",
                schema: "Material");

            migrationBuilder.DropTable(
                name: "Course",
                schema: "Education");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_DeviceId",
                schema: "Identity",
                table: "RefreshToken");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "VerificationToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "VerificationToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "UserInfo",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "UserInfo",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                schema: "Identity",
                table: "UserInfo",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Дата рождения пользователя",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldComment: "Дата рождения пользователя");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "UserClaim",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "UserClaim",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "RoleClaim",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "RoleClaim",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                schema: "Identity",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                comment: "Время истечения рефреш токена",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldComment: "Время истечения рефреш токена");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                schema: "Identity",
                table: "RefreshToken",
                type: "integer",
                nullable: false,
                comment: "Id устройства",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Id устройства с которого был выполнен вход");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "RefreshToken",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "Device",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginTime",
                schema: "Identity",
                table: "Device",
                type: "timestamp with time zone",
                nullable: false,
                comment: "Последние время входа в систему",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldComment: "Последние время входа в систему");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Device",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "ApplicationSettings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата последнего обновления сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата последнего обновления сущности");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "ApplicationSettings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                comment: "Дата создания сущности",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()",
                oldComment: "Дата создания сущности");

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                schema: "Identity",
                table: "ApplicationSettings",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Описание");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Identity",
                table: "ApplicationSettings",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Имя (название) настройки");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "Identity",
                table: "ApplicationSettings",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Значение настройки");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_DeviceId",
                schema: "Identity",
                table: "RefreshToken",
                column: "DeviceId",
                unique: true);
        }
    }
}
