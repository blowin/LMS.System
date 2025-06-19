using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.System.Migrations.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class Entity_ChangingEventAndPK_OnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submission_Assignment_AssignmentId",
                table: "Submission");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswerOption_TestQuestion_TestQuestionId",
                table: "TestAnswerOption");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswerOption_TestSubmission_TestQuestionId",
                table: "TestAnswerOption");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Assignment_AssignmentId",
                table: "TestQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSubmission_Submission_SubmissionId",
                table: "TestSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSubmission_TestQuestion_TestQuestionId",
                table: "TestSubmission");

            migrationBuilder.AlterColumn<int>(
                name: "TestQuestionId",
                table: "TestSubmission",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubmissionId",
                table: "TestSubmission",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SelectedOptionId",
                table: "TestSubmission",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TestSubmission",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TestSubmission",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "TestQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TestQuestionId",
                table: "TestAnswerOption",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Submission",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Submission",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Enrollment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Enrollment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Submission_Assignment_AssignmentId",
                table: "Submission",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswerOption_TestQuestion_TestQuestionId",
                table: "TestAnswerOption",
                column: "TestQuestionId",
                principalTable: "TestQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSubmission_Submission_SubmissionId",
                table: "TestSubmission",
                column: "SubmissionId",
                principalTable: "Submission",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSubmission_TestQuestion_TestQuestionId",
                table: "TestSubmission",
                column: "TestQuestionId",
                principalTable: "TestQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submission_Assignment_AssignmentId",
                table: "Submission");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswerOption_TestQuestion_TestQuestionId",
                table: "TestAnswerOption");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswerOption_TestSubmission_TestQuestionId",
                table: "TestAnswerOption");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Assignment_AssignmentId",
                table: "TestQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSubmission_Submission_SubmissionId",
                table: "TestSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSubmission_TestQuestion_TestQuestionId",
                table: "TestSubmission");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TestSubmission");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TestSubmission");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Enrollment");

            migrationBuilder.AlterColumn<int>(
                name: "TestQuestionId",
                table: "TestSubmission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SubmissionId",
                table: "TestSubmission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedOptionId",
                table: "TestSubmission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "TestQuestion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TestQuestionId",
                table: "TestAnswerOption",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Submission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Submission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Enrollment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Enrollment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Submission_Assignment_AssignmentId",
                table: "Submission",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswerOption_TestQuestion_TestQuestionId",
                table: "TestAnswerOption",
                column: "TestQuestionId",
                principalTable: "TestQuestion",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TestSubmission_Submission_SubmissionId",
                table: "TestSubmission",
                column: "SubmissionId",
                principalTable: "Submission",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestSubmission_TestQuestion_TestQuestionId",
                table: "TestSubmission",
                column: "TestQuestionId",
                principalTable: "TestQuestion",
                principalColumn: "Id");
        }
    }
}
