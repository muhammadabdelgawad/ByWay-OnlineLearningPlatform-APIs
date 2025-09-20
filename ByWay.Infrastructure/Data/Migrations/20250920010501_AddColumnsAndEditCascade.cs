using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByWay.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsAndEditCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompeleted",
                table: "Lectures");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Lectures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Lectures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lectures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LectureNumber",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Lectures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_CourseId_LectureNumber",
                table: "Lectures",
                columns: new[] { "CourseId", "LectureNumber" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lecture_CourseId_LectureNumber",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "LectureNumber",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Lectures");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompeleted",
                table: "Lectures",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
