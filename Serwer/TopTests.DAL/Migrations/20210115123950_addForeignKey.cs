using Microsoft.EntityFrameworkCore.Migrations;

namespace TopTests.DAL.Migrations
{
    public partial class addForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "TimeRemainingOfTests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectsId",
                table: "Answers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeRemainingOfTests_TestId",
                table: "TimeRemainingOfTests",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeRemainingOfTests_UsersId",
                table: "TimeRemainingOfTests",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SubjectsId",
                table: "Answers",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TestId",
                table: "Answers",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Subjects_SubjectsId",
                table: "Answers",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Tests_TestId",
                table: "Answers",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeRemainingOfTests_Tests_TestId",
                table: "TimeRemainingOfTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeRemainingOfTests_Users_UsersId",
                table: "TimeRemainingOfTests",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Subjects_SubjectsId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Tests_TestId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeRemainingOfTests_Tests_TestId",
                table: "TimeRemainingOfTests");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeRemainingOfTests_Users_UsersId",
                table: "TimeRemainingOfTests");

            migrationBuilder.DropIndex(
                name: "IX_TimeRemainingOfTests_TestId",
                table: "TimeRemainingOfTests");

            migrationBuilder.DropIndex(
                name: "IX_TimeRemainingOfTests_UsersId",
                table: "TimeRemainingOfTests");

            migrationBuilder.DropIndex(
                name: "IX_Answers_SubjectsId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_TestId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "TimeRemainingOfTests");

            migrationBuilder.DropColumn(
                name: "SubjectsId",
                table: "Answers");
        }
    }
}
