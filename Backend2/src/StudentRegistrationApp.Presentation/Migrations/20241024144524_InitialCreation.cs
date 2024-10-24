using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentRegistrationApp.Presentation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Enrollment_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Name" },
                values: new object[,]
                {
                    { new Guid("3fc255e6-d2f7-47f1-9b79-35ebf03dd7d4"), "Andres Villamizar" },
                    { new Guid("812b7a9f-0c52-4717-b145-b5be80eed88d"), "Fernanda Salinas" },
                    { new Guid("9a16ab75-45f2-41f3-b918-4e4bbae71ee5"), "Luisa Torres" },
                    { new Guid("c8bff21b-0332-4d84-81a7-3941c18f1cc4"), "Julio Fernandez" },
                    { new Guid("f7f5fc7a-8061-48ca-9486-85adc6e0ed97"), "Martin Hernandez" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Credits", "Name", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("17119498-8bf9-4068-a5cf-dab7ddb55cd9"), 3, "Historia 1", new Guid("c8bff21b-0332-4d84-81a7-3941c18f1cc4") },
                    { new Guid("34cef1d4-b471-499d-969d-7747dfe057c4"), 3, "Fisica 1", new Guid("812b7a9f-0c52-4717-b145-b5be80eed88d") },
                    { new Guid("3e940134-4079-443e-b36a-da7319303f93"), 3, "Catedra universitaria", new Guid("9a16ab75-45f2-41f3-b918-4e4bbae71ee5") },
                    { new Guid("4a7f2c46-774b-41d9-8e6d-becc29a20a72"), 3, "Fisica 2", new Guid("812b7a9f-0c52-4717-b145-b5be80eed88d") },
                    { new Guid("508be8aa-ec1a-460d-84ac-3013e1ab43ed"), 3, "Quimica 2", new Guid("f7f5fc7a-8061-48ca-9486-85adc6e0ed97") },
                    { new Guid("93c08df5-3d32-495b-a470-e481b685a4a7"), 3, "Matematicas 1", new Guid("3fc255e6-d2f7-47f1-9b79-35ebf03dd7d4") },
                    { new Guid("a53ba00f-c330-4e4b-9d23-824f325b5f27"), 3, "Etica", new Guid("9a16ab75-45f2-41f3-b918-4e4bbae71ee5") },
                    { new Guid("be1d7182-1893-4f2a-b795-a8402398e605"), 3, "Historia 2", new Guid("c8bff21b-0332-4d84-81a7-3941c18f1cc4") },
                    { new Guid("c04348ed-e25a-4aae-a5b1-e0b497aafe15"), 3, "Quimica 1", new Guid("f7f5fc7a-8061-48ca-9486-85adc6e0ed97") },
                    { new Guid("f1752182-ed9b-4115-9ba4-a5bf9db62838"), 3, "Matematicas 2", new Guid("3fc255e6-d2f7-47f1-9b79-35ebf03dd7d4") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseId",
                table: "Enrollment",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
