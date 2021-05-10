using Microsoft.EntityFrameworkCore.Migrations;

namespace TopTests.DAL.Migrations
{
    public partial class addFieldAddAutomaticTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AutomaticTime",
                table: "Tests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_TestId",
                table: "FeedBacks",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Tests_TestId",
                table: "FeedBacks",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Tests_TestId",
                table: "FeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_TestId",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "AutomaticTime",
                table: "Tests");
        }
    }
}
