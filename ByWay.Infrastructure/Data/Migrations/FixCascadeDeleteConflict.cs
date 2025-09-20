using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByWay.Infrastructure.Migrations
{
    public partial class FixCascadeDeleteConflict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing foreign key that causes cascade conflict
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures");

            // Fix the column name from IsCompeleted to IsCompleted
            migrationBuilder.RenameColumn(
                name: "IsCompeleted",
                table: "Lectures", 
                newName: "IsCompleted");

            // Add LectureNumber column if it doesn't exist
            migrationBuilder.AddColumn<int>(
                name: "LectureNumber",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 1);

            // Recreate the foreign key with NO ACTION to prevent cascade conflicts
            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            // Create unique index for lecture ordering within a course
            migrationBuilder.CreateIndex(
                name: "IX_Lecture_CourseId_LectureNumber",
                table: "Lectures",
                columns: new[] { "CourseId", "LectureNumber" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the new foreign key
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures");

            // Drop the unique index
            migrationBuilder.DropIndex(
                name: "IX_Lecture_CourseId_LectureNumber",
                table: "Lectures");

            // Remove LectureNumber column
            migrationBuilder.DropColumn(
                name: "LectureNumber",
                table: "Lectures");

            // Revert column name
            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "Lectures",
                newName: "IsCompeleted");

            // Recreate original foreign key with cascade
            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}