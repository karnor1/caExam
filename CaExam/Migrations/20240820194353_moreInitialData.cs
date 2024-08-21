using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaExam.Migrations
{
    /// <inheritdoc />
    public partial class moreInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { new Guid("5d157de3-314e-4c7d-9565-b1730abc81c0"), new byte[] { 216, 236, 72, 99, 227, 209, 156, 21, 182, 244, 246, 52, 200, 218, 12, 63, 126, 60, 219, 210, 185, 236, 11, 99, 46, 133, 217, 138, 27, 226, 188, 193 }, 2, new byte[] { 81, 246, 140, 13, 87, 98, 16, 21, 181, 118, 44, 232, 198, 72, 24, 111 }, "userGuest" },
                    { new Guid("b60448a5-c635-447b-8b58-8d529b7f3651"), new byte[] { 236, 72, 48, 219, 225, 69, 39, 94, 21, 33, 50, 0, 78, 118, 199, 124, 138, 56, 136, 60, 36, 231, 255, 41, 199, 252, 106, 221, 11, 243, 78, 75 }, 0, new byte[] { 140, 34, 163, 86, 75, 16, 205, 187, 20, 9, 121, 242, 13, 59, 103, 132 }, "admin" },
                    { new Guid("dc074a65-c9a8-4771-81cd-0e42f4b20185"), new byte[] { 85, 12, 204, 170, 52, 8, 37, 12, 235, 89, 239, 214, 34, 116, 57, 182, 172, 71, 16, 77, 140, 68, 221, 159, 30, 60, 83, 196, 118, 153, 58, 150 }, 1, new byte[] { 36, 27, 66, 160, 153, 24, 3, 13, 59, 112, 225, 113, 68, 176, 117, 118 }, "userUser1" },
                    { new Guid("e8b43192-251f-4ecd-97ce-a44b38f087bc"), new byte[] { 109, 57, 248, 119, 58, 198, 34, 137, 72, 207, 130, 102, 251, 182, 35, 53, 84, 150, 84, 187, 114, 77, 109, 177, 218, 147, 80, 24, 202, 86, 139, 104 }, 1, new byte[] { 72, 196, 101, 31, 129, 84, 183, 140, 205, 194, 186, 91, 148, 49, 221, 151 }, "userUser" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "ApartamentNumber", "City", "HouseNumber", "UserId", "street" },
                values: new object[,]
                {
                    { new Guid("4efbcdba-e68d-4d5c-b5d5-d204aea0c820"), "96119", "New Willfort", "5833", new Guid("b60448a5-c635-447b-8b58-8d529b7f3651"), "Lesly Ports" },
                    { new Guid("68ff04ed-8bdb-47c9-91b8-987cd36c789c"), "71930", "Bartellchester", "747", new Guid("dc074a65-c9a8-4771-81cd-0e42f4b20185"), "Arnold Rest" },
                    { new Guid("c2fa9d2a-d565-4650-9fe8-b2fcf35d1929"), "741", "Lanceport", "80818", new Guid("5d157de3-314e-4c7d-9565-b1730abc81c0"), "Hazel Prairie" },
                    { new Guid("d416bc4f-6359-458d-bbc0-33f64aac4b61"), "572", "North Mike", "761", new Guid("e8b43192-251f-4ecd-97ce-a44b38f087bc"), "Darrin Pike" }
                });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "Id", "Email", "Name", "PersonalIdNumber", "PhoneNumber", "PicturePath", "Surname", "UserId" },
                values: new object[,]
                {
                    { new Guid("02ce0718-a9a8-4d92-9684-5ee2b8db642a"), "Larry99@yahoo.com", "Larry", "199809233498", "(991) 960-0384", "somewhere in server", "Cummings", new Guid("5d157de3-314e-4c7d-9565-b1730abc81c0") },
                    { new Guid("17ca93ac-766f-41f6-a30c-7c0125566500"), "Larry99@yahoo.com", "Larry", "199809233498", "784-720-2857 x76427", "somewhere in server", "Cummings", new Guid("e8b43192-251f-4ecd-97ce-a44b38f087bc") },
                    { new Guid("402b9a3a-5690-4138-aa9d-10ccd256e87c"), "Larry99@yahoo.com", "Larry", "199809233498", "1-822-629-7403", "somewhere in server", "Cummings", new Guid("b60448a5-c635-447b-8b58-8d529b7f3651") },
                    { new Guid("4c286d5c-6ede-4c15-8c79-b809406e1509"), "Larry99@yahoo.com", "Larry", "199809233498", "(518) 452-2954 x3649", "somewhere in server", "Cummings", new Guid("dc074a65-c9a8-4771-81cd-0e42f4b20185") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("4efbcdba-e68d-4d5c-b5d5-d204aea0c820"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("68ff04ed-8bdb-47c9-91b8-987cd36c789c"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("c2fa9d2a-d565-4650-9fe8-b2fcf35d1929"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("d416bc4f-6359-458d-bbc0-33f64aac4b61"));

            migrationBuilder.DeleteData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: new Guid("02ce0718-a9a8-4d92-9684-5ee2b8db642a"));

            migrationBuilder.DeleteData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: new Guid("17ca93ac-766f-41f6-a30c-7c0125566500"));

            migrationBuilder.DeleteData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: new Guid("402b9a3a-5690-4138-aa9d-10ccd256e87c"));

            migrationBuilder.DeleteData(
                table: "UserDetails",
                keyColumn: "Id",
                keyValue: new Guid("4c286d5c-6ede-4c15-8c79-b809406e1509"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5d157de3-314e-4c7d-9565-b1730abc81c0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b60448a5-c635-447b-8b58-8d529b7f3651"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dc074a65-c9a8-4771-81cd-0e42f4b20185"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e8b43192-251f-4ecd-97ce-a44b38f087bc"));

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
    }
}
