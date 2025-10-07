using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByWay.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixCartItemCourseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Check if column exists before adding
            migrationBuilder.Sql(@"
            IF NOT EXISTS (SELECT * FROM sys.columns 
                          WHERE object_id = OBJECT_ID(N'[dbo].[CartItems]') 
                          AND name = 'CourseId')
            BEGIN
                ALTER TABLE [CartItems] ADD [CourseId] int NOT NULL DEFAULT 0;
            END
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "CourseId",
            table: "CartItems");

        }
    }
}
