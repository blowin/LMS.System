using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.System.Migrations.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class Course_AddingField_IsArchive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "Courses");
        }
    }
}
