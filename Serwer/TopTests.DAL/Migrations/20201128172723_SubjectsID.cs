using Microsoft.EntityFrameworkCore.Migrations;

namespace TopTests.DAL.Migrations
{
    public partial class SubjectsID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectsId",
                table: "Tests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SubjectsId",
                table: "Tests",
                column: "SubjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Subjects_SubjectsId",
                table: "Tests",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Subjects_SubjectsId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_SubjectsId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "SubjectsId",
                table: "Tests");
        }
    }
}
