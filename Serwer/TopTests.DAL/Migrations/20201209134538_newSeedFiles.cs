using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopTests.DAL.Migrations
{
    public partial class newSeedFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "FileContent", "FileName", "TypeOfTest" },
                values: new object[] { 4, new byte[] { 78, 117, 109, 98, 101, 114, 79, 102, 81, 117, 101, 115, 116, 105, 111, 110, 44, 81, 117, 101, 115, 116, 105, 111, 110, 44, 79, 112, 116, 105, 111, 110, 65, 44, 79, 112, 116, 105, 111, 110, 66, 44, 79, 112, 116, 105, 111, 110, 67, 44, 70, 105, 114, 115, 116, 65, 110, 115, 119, 101, 114, 44, 83, 101, 99, 111, 110, 100, 65, 110, 115, 119, 101, 114, 44, 84, 104, 105, 114, 100, 65, 110, 115, 119, 101, 114, 44, 67, 111, 109, 112, 108, 101, 120, 105, 116, 121, 13, 10 }, "Multiple Choices Test", 0 });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "FileContent", "FileName", "TypeOfTest" },
                values: new object[] { 5, new byte[] { 78, 117, 109, 98, 101, 114, 79, 102, 81, 117, 101, 115, 116, 105, 111, 110, 44, 81, 117, 101, 115, 116, 105, 111, 110, 44, 79, 112, 116, 105, 111, 110, 65, 44, 79, 112, 116, 105, 111, 110, 66, 44, 79, 112, 116, 105, 111, 110, 67, 44, 65, 110, 115, 119, 101, 114, 44, 67, 111, 109, 112, 108, 101, 120, 105, 116, 121, 13, 10 }, "Single Selection Test", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "FileContent", "FileName", "TypeOfTest" },
                values: new object[] { 3, new byte[] { 78, 117, 109, 98, 101, 114, 79, 102, 81, 117, 101, 115, 116, 105, 111, 110, 44, 81, 117, 101, 115, 116, 105, 111, 110, 44, 79, 112, 116, 105, 111, 110, 65, 44, 79, 112, 116, 105, 111, 110, 66, 44, 79, 112, 116, 105, 111, 110, 67, 44, 65, 110, 115, 119, 101, 114, 44, 67, 111, 109, 112, 108, 101, 120, 105, 116, 121, 13, 10 }, "Multiple Test", 0 });
        }
    }
}
