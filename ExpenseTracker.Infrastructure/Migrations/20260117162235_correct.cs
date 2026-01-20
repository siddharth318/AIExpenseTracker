using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("00f56c43-2e73-46c4-8a72-0214c15f5519"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("04977432-f3de-44ce-a27a-bb6f0e7461b5"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "Description", "IsActive", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("99cc05c9-88dc-4ca2-b853-a47265297739"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, "Food" },
                    { new Guid("f0a0fe33-4ea1-4e06-932f-99f91e255c3d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, "Travel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("99cc05c9-88dc-4ca2-b853-a47265297739"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f0a0fe33-4ea1-4e06-932f-99f91e255c3d"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "Description", "IsActive", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00f56c43-2e73-46c4-8a72-0214c15f5519"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, "Food" },
                    { new Guid("04977432-f3de-44ce-a27a-bb6f0e7461b5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, "Travel" }
                });
        }
    }
}
