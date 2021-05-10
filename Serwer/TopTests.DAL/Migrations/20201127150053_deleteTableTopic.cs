using Microsoft.EntityFrameworkCore.Migrations;

namespace TopTests.DAL.Migrations
{
    public partial class deleteTableTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Topics_TopicsId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Topics_TopicsId",
                table: "TestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Topics_TopicsId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Tests_TopicsId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestions_TopicsId",
                table: "TestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Results_TopicsId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TopicsId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "TopicsId",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "TopicsId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Answers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TopicsId",
                table: "Tests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "TestQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TopicsId",
                table: "TestQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TopicsId",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TopicsId",
                table: "Tests",
                column: "TopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_TopicsId",
                table: "TestQuestions",
                column: "TopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_TopicsId",
                table: "Results",
                column: "TopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_SubjectsId",
                table: "Topics",
                column: "SubjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Topics_TopicsId",
                table: "Results",
                column: "TopicsId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Topics_TopicsId",
                table: "TestQuestions",
                column: "TopicsId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Topics_TopicsId",
                table: "Tests",
                column: "TopicsId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
