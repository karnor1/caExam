using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaExam.Migrations
{
    /// <inheritdoc />
    public partial class initialData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Salt", "Username" },
                values: new object[] { new Guid("8b2d425f-81e5-442d-8045-dd28acdfd216"), new byte[] { 73, 99, 243, 80, 207, 75, 212, 226, 114, 80, 145, 49, 183, 74, 199, 149, 54, 115, 202, 93, 192, 79, 129, 166, 147, 3, 209, 57, 102, 114, 198, 113 }, 0, new byte[] { 206, 60, 24, 205, 168, 170, 73, 192, 64, 85, 147, 54, 209, 75, 110, 19 }, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8b2d425f-81e5-442d-8045-dd28acdfd216"));
        }
    }
}
