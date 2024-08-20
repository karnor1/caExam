using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaExam.Migrations
{
    /// <inheritdoc />
    public partial class addedWorkingInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8b2d425f-81e5-442d-8045-dd28acdfd216"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Salt", "Username" },
                values: new object[] { new Guid("5e3268d1-7911-4acc-bf62-f3f5c7e1f038"), new byte[] { 106, 183, 187, 160, 69, 146, 147, 71, 26, 50, 41, 214, 255, 67, 241, 247, 124, 60, 109, 87, 29, 56, 82, 71, 2, 227, 67, 143, 219, 52, 166, 194 }, 0, new byte[] { 104, 88, 166, 31, 73, 34, 115, 59, 147, 237, 243, 4, 117, 167, 178, 26 }, "admin" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "ApartamentNumber", "City", "HouseNumber", "UserId", "street" },
                values: new object[] { new Guid("1c2cf5fb-eec0-4c96-8430-ba9a19583742"), "1", "Vilnius", "2", new Guid("5e3268d1-7911-4acc-bf62-f3f5c7e1f038"), "Kauno" });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "Id", "Email", "Name", "PersonalIdNumber", "PhoneNumber", "PicturePath", "Surname", "UserId" },
                values: new object[] { new Guid("c2c8cedc-1045-42f5-a04d-75daf71c79ed"), "tele2@hotmail.com", "zmogus", "37707727776", "8644785417", "somewhere in server", "zmogaitis", new Guid("5e3268d1-7911-4acc-bf62-f3f5c7e1f038") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("1c2cf5fb-eec0-4c96-8430-ba9a19583742"));

            migrationBuilder.DeleteData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: new Guid("c2c8cedc-1045-42f5-a04d-75daf71c79ed"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5e3268d1-7911-4acc-bf62-f3f5c7e1f038"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Salt", "Username" },
                values: new object[] { new Guid("8b2d425f-81e5-442d-8045-dd28acdfd216"), new byte[] { 73, 99, 243, 80, 207, 75, 212, 226, 114, 80, 145, 49, 183, 74, 199, 149, 54, 115, 202, 93, 192, 79, 129, 166, 147, 3, 209, 57, 102, 114, 198, 113 }, 0, new byte[] { 206, 60, 24, 205, 168, 170, 73, 192, 64, 85, 147, 54, 209, 75, 110, 19 }, "admin" });
        }
    }
}
