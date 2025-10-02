using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByWay.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditRelationshipBtwCourseAndCartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

      
            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CourseId",
                table: "CartItems",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Courses_CourseId",
                table: "CartItems",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_CartItems_Courses_CourseId",
               table: "CartItems");


            migrationBuilder.DropIndex(
                name: "IX_CartItems_CourseId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CartItems");
        }
    }
}
