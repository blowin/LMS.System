using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.System.Migrations.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class Lesson_AddingFields_FilePDFPathAndMoviesPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePDFPath",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoviesPath",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePDFPath",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "MoviesPath",
                table: "Lessons");
        }
    }
}
