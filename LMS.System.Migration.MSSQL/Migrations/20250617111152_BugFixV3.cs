using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.System.Migrations.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class BugFixV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswerOption_TestSubmission_TestQuestionId",
                table: "TestAnswerOption");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Assignment_AssignmentId",
                table: "TestQuestion");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswerOption_TestSubmission_TestQuestionId",
                table: "TestAnswerOption",
                column: "TestQuestionId",
                principalTable: "TestSubmission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_Assignment_AssignmentId",
                table: "TestQuestion",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswerOption_TestSubmission_TestQuestionId",
                table: "TestAnswerOption");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Assignment_AssignmentId",
                table: "TestQuestion");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswerOption_TestSubmission_TestQuestionId",
                table: "TestAnswerOption",
                column: "TestQuestionId",
                principalTable: "TestSubmission",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_Assignment_AssignmentId",
                table: "TestQuestion",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
