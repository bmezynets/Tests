using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopTests.DAL.Migrations
{
    public partial class addFirstTestFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "FileContent", "FileName" },
                values: new object[] { 2, new byte[] { 78, 117, 109, 98, 101, 114, 79, 102, 81, 117, 101, 115, 116, 105, 111, 110, 44, 81, 117, 101, 115, 116, 105, 111, 110, 44, 79, 112, 116, 105, 111, 110, 65, 44, 79, 112, 116, 105, 111, 110, 66, 44, 79, 112, 116, 105, 111, 110, 67, 44, 65, 110, 115, 119, 101, 114, 44, 67, 111, 109, 112, 108, 101, 120, 105, 116, 121, 13, 10 }, "Test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "FileContent", "FileName" },
                values: new object[] { 1, new byte[] { 78, 117, 109, 98, 101, 114, 79, 102, 81, 117, 101, 115, 116, 105, 111, 110, 44, 81, 117, 101, 115, 116, 105, 111, 110, 44, 79, 112, 116, 105, 111, 110, 65, 44, 79, 112, 116, 105, 111, 110, 66, 44, 79, 112, 116, 105, 111, 110, 67, 44, 65, 110, 115, 119, 101, 114, 44, 67, 111, 109, 112, 108, 101, 120, 105, 116, 121, 13, 10 }, "Test" });
        }
    }
}
