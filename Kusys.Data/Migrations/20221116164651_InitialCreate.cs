using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kusys.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => x.StudentCourseId);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName" },
                values: new object[,]
                {
                    { 101, "Introduction to Computer Science" },
                    { 102, "Algorithms" },
                    { 103, "Calculus" },
                    { 104, "Physics" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "BirthDate", "FirstName", "LastName", "RoleID", "password", "username" },
                values: new object[] { 1, new DateTime(2022, 11, 16, 19, 46, 50, 886, DateTimeKind.Local).AddTicks(5226), "Semih", "Özhan", 1, "password", "username" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "BirthDate", "FirstName", "LastName", "RoleID", "password", "username" },
                values: new object[] { 2, new DateTime(2022, 11, 16, 19, 46, 50, 886, DateTimeKind.Local).AddTicks(5235), "Semih2", "Özhan2", 1, "password", "username" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "BirthDate", "FirstName", "LastName", "RoleID", "password", "username" },
                values: new object[] { 3, new DateTime(2022, 11, 16, 19, 46, 50, 886, DateTimeKind.Local).AddTicks(5236), "Semih3", "Özhan3", 1, "password", "username" });

            migrationBuilder.InsertData(
                table: "StudentCourse",
                columns: new[] { "StudentCourseId", "CourseId", "StudentId" },
                values: new object[] { 1, 101, 1 });

            migrationBuilder.InsertData(
                table: "StudentCourse",
                columns: new[] { "StudentCourseId", "CourseId", "StudentId" },
                values: new object[] { 2, 102, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentId",
                table: "StudentCourse",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoleID",
                table: "Students",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
