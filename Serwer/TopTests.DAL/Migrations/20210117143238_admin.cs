using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopTests.DAL.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "DateCreated", "DateModified", "Email", "FirstName", "HashPassword", "IsDeleted", "LastName", "ModifiedBy", "RoleOfUser", "Salt", "StatusOfVerification" },
                values: new object[] { 1, null, new DateTime(2021, 1, 17, 15, 32, 37, 690, DateTimeKind.Local).AddTicks(864), new DateTime(2021, 1, 17, 15, 32, 37, 694, DateTimeKind.Local).AddTicks(8), "admin@admin.com", "Admin", "yy+OiucDVuyxoqAAerlTgLrwvvim0wsd0duyRI0K6nw+Wq6GHNRjegMIHDdjzofx7oC8aLAmc+HvIVwJHT3tOAzuxY2kyl08HhH4u7smM75sjcMJ/hkQ+FSjfOb6hqESQVMFTughKfspr/K73XLaOsjW/HYBJORjI/9pGCMaR95Sju+Jw6WaFYdK9zex/xs07WrR/+ils8jP902eTmv4CyA6bsPnbmVYDREy0A5hoBaDkgwBwu3xrm37rD1Tg/uk0cWmSxTX7h8KywE1wWuAF/9oW18WM9Leia/ihtTQdBRoCCGsX/AcDqoMzdnkXTvzdPbqjBpVo12CnxZMz0YUkg==", false, "", null, 2, null, "Active" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
