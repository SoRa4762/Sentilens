using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserTopicControllersChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b56c7f8-8e2e-4163-bd08-f2a5a805d842");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a25e37-a373-48e1-a66b-d540d4ef121e");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubscribedDate",
                table: "UserTopics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63646cdb-913b-4a3b-bd2a-f68881a55f79", null, "Admin", "ADMIN" },
                    { "f703bf2a-078d-4e3e-85c1-bf14de4ea884", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63646cdb-913b-4a3b-bd2a-f68881a55f79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f703bf2a-078d-4e3e-85c1-bf14de4ea884");

            migrationBuilder.DropColumn(
                name: "SubscribedDate",
                table: "UserTopics");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b56c7f8-8e2e-4163-bd08-f2a5a805d842", null, "Admin", "ADMIN" },
                    { "63a25e37-a373-48e1-a66b-d540d4ef121e", null, "User", "USER" }
                });
        }
    }
}
