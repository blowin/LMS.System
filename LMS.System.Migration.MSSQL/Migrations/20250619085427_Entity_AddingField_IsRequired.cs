using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.System.Migrations.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class Entity_AddingField_IsRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Course_CourseId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_User_InstructorId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_CourseId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_User_StudentId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Course_CourseId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Submission_Assignment_AssignmentId",
                table: "Submission");

            migrationBuilder.DropForeignKey(
                name: "FK_Submission_User_StudentId",
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
                name: "FK_TestSubmission_TestAnswerOption_TestAnswerOptionId",
                table: "TestSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSubmission_TestQuestion_TestQuestionId",
                table: "TestSubmission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestSubmission",
                table: "TestSubmission");

            migrationBuilder.DropIndex(
                name: "IX_TestSubmission_TestAnswerOptionId",
                table: "TestSubmission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestQuestion",
                table: "TestQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestAnswerOption",
                table: "TestAnswerOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Submission",
                table: "Submission");

            migrationBuilder.DropIndex(
                name: "IX_Submission_StudentId",
                table: "Submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_InstructorId",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "TestAnswerOptionId",
                table: "TestSubmission");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TestSubmission",
                newName: "TestSubmissions");

            migrationBuilder.RenameTable(
                name: "TestQuestion",
                newName: "TestQuestions");

            migrationBuilder.RenameTable(
                name: "TestAnswerOption",
                newName: "TestAnswerOptions");

            migrationBuilder.RenameTable(
                name: "Submission",
                newName: "Submissions");

            migrationBuilder.RenameTable(
                name: "Lesson",
                newName: "Lessons");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "Enrollments");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Assignment",
                newName: "Assignments");

            migrationBuilder.RenameColumn(
                name: "UsersRole",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameIndex(
                name: "IX_TestSubmission_TestQuestionId",
                table: "TestSubmissions",
                newName: "IX_TestSubmissions_TestQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_TestSubmission_SubmissionId",
                table: "TestSubmissions",
                newName: "IX_TestSubmissions_SubmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_TestQuestion_AssignmentId",
                table: "TestQuestions",
                newName: "IX_TestQuestions_AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_TestAnswerOption_TestQuestionId",
                table: "TestAnswerOptions",
                newName: "IX_TestAnswerOptions_TestQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Submission_AssignmentId",
                table: "Submissions",
                newName: "IX_Submissions_AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_CourseId",
                table: "Lessons",
                newName: "IX_Lessons_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_CourseId",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseId");

            migrationBuilder.RenameColumn(
                name: "IsPubliched",
                table: "Courses",
                newName: "IsPublished");

            migrationBuilder.RenameIndex(
                name: "IX_Course_CategoryId",
                table: "Courses",
                newName: "IX_Courses_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignment_CourseId",
                table: "Assignments",
                newName: "IX_Assignments_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "0 = Admin , 1 = Teacher , 2 = Student");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionType",
                table: "TestQuestions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "0 = SingleChoice , 1 = MultiChoice");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TestQuestions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "OptionText",
                table: "TestAnswerOptions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCorrect",
                table: "TestAnswerOptions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Feedback",
                table: "Submissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserForSubId",
                table: "Submissions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "LessonType",
                table: "Lessons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "0 = Text , 1 = Video , 2 = PDF");

            migrationBuilder.AlterColumn<bool>(
                name: "Completed",
                table: "Enrollments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UsersForEnrollmentId",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublished",
                table: "Courses",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentType",
                table: "Assignments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "0 = Test , 1 = FileUpload , 2 = Text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestSubmissions",
                table: "TestSubmissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestQuestions",
                table: "TestQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestAnswerOptions",
                table: "TestAnswerOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Submissions",
                table: "Submissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_UserForSubId",
                table: "Submissions",
                column: "UserForSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_UsersForEnrollmentId",
                table: "Enrollments",
                column: "UsersForEnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UsersId",
                table: "Courses",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Courses_CourseId",
                table: "Assignments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_UsersId",
                table: "Courses",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_UsersForEnrollmentId",
                table: "Enrollments",
                column: "UsersForEnrollmentId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Assignments_AssignmentId",
                table: "Submissions",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Users_UserForSubId",
                table: "Submissions",
                column: "UserForSubId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestAnswerOptions_TestQuestions_TestQuestionId",
                table: "TestAnswerOptions",
                column: "TestQuestionId",
                principalTable: "TestQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Assignments_AssignmentId",
                table: "TestQuestions",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSubmissions_Submissions_SubmissionId",
                table: "TestSubmissions",
                column: "SubmissionId",
                principalTable: "Submissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSubmissions_TestQuestions_TestQuestionId",
                table: "TestSubmissions",
                column: "TestQuestionId",
                principalTable: "TestQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Courses_CourseId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_UsersId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_UsersForEnrollmentId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Assignments_AssignmentId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Users_UserForSubId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAnswerOptions_TestQuestions_TestQuestionId",
                table: "TestAnswerOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Assignments_AssignmentId",
                table: "TestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSubmissions_Submissions_SubmissionId",
                table: "TestSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSubmissions_TestQuestions_TestQuestionId",
                table: "TestSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestSubmissions",
                table: "TestSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestQuestions",
                table: "TestQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestAnswerOptions",
                table: "TestAnswerOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Submissions",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_UserForSubId",
                table: "Submissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_UsersForEnrollmentId",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UsersId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "UserForSubId",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "UsersForEnrollmentId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "TestSubmissions",
                newName: "TestSubmission");

            migrationBuilder.RenameTable(
                name: "TestQuestions",
                newName: "TestQuestion");

            migrationBuilder.RenameTable(
                name: "TestAnswerOptions",
                newName: "TestAnswerOption");

            migrationBuilder.RenameTable(
                name: "Submissions",
                newName: "Submission");

            migrationBuilder.RenameTable(
                name: "Lessons",
                newName: "Lesson");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Assignments",
                newName: "Assignment");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "User",
                newName: "UsersRole");

            migrationBuilder.RenameIndex(
                name: "IX_TestSubmissions_TestQuestionId",
                table: "TestSubmission",
                newName: "IX_TestSubmission_TestQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_TestSubmissions_SubmissionId",
                table: "TestSubmission",
                newName: "IX_TestSubmission_SubmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_TestQuestions_AssignmentId",
                table: "TestQuestion",
                newName: "IX_TestQuestion_AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_TestAnswerOptions_TestQuestionId",
                table: "TestAnswerOption",
                newName: "IX_TestAnswerOption_TestQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_AssignmentId",
                table: "Submission",
                newName: "IX_Submission_AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_CourseId",
                table: "Lesson",
                newName: "IX_Lesson_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollment",
                newName: "IX_Enrollment_CourseId");

            migrationBuilder.RenameColumn(
                name: "IsPublished",
                table: "Course",
                newName: "IsPubliched");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CategoryId",
                table: "Course",
                newName: "IX_Course_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_CourseId",
                table: "Assignment",
                newName: "IX_Assignment_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UsersRole",
                table: "User",
                type: "int",
                nullable: false,
                comment: "0 = Admin , 1 = Teacher , 2 = Student",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TestAnswerOptionId",
                table: "TestSubmission",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionType",
                table: "TestQuestion",
                type: "int",
                nullable: false,
                comment: "0 = SingleChoice , 1 = MultiChoice",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TestQuestion",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OptionText",
                table: "TestAnswerOption",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCorrect",
                table: "TestAnswerOption",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Feedback",
                table: "Submission",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Lesson",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LessonType",
                table: "Lesson",
                type: "int",
                nullable: false,
                comment: "0 = Text , 1 = Video , 2 = PDF",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Completed",
                table: "Enrollment",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Course",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Course",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPubliched",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Assignment",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assignment",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentType",
                table: "Assignment",
                type: "int",
                nullable: false,
                comment: "0 = Test , 1 = FileUpload , 2 = Text",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestSubmission",
                table: "TestSubmission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestQuestion",
                table: "TestQuestion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestAnswerOption",
                table: "TestAnswerOption",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Submission",
                table: "Submission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TestSubmission_TestAnswerOptionId",
                table: "TestSubmission",
                column: "TestAnswerOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_StudentId",
                table: "Submission",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_InstructorId",
                table: "Course",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Course_CourseId",
                table: "Assignment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_User_InstructorId",
                table: "Course",
                column: "InstructorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_CourseId",
                table: "Enrollment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_User_StudentId",
                table: "Enrollment",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Course_CourseId",
                table: "Lesson",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submission_Assignment_AssignmentId",
                table: "Submission",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submission_User_StudentId",
                table: "Submission",
                column: "StudentId",
                principalTable: "User",
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSubmission_TestAnswerOption_TestAnswerOptionId",
                table: "TestSubmission",
                column: "TestAnswerOptionId",
                principalTable: "TestAnswerOption",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestSubmission_TestQuestion_TestQuestionId",
                table: "TestSubmission",
                column: "TestQuestionId",
                principalTable: "TestQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
