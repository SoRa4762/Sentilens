using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TopicEntityChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63646cdb-913b-4a3b-bd2a-f68881a55f79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f703bf2a-078d-4e3e-85c1-bf14de4ea884");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Topics",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eb3d146-5dd1-4ae8-8bba-3a8e07d46d51", null, "Admin", "ADMIN" },
                    { "ff80e7f5-7b8f-48ee-955c-71f20d721aba", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eb3d146-5dd1-4ae8-8bba-3a8e07d46d51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff80e7f5-7b8f-48ee-955c-71f20d721aba");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Topics");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63646cdb-913b-4a3b-bd2a-f68881a55f79", null, "Admin", "ADMIN" },
                    { "f703bf2a-078d-4e3e-85c1-bf14de4ea884", null, "User", "USER" }
                });
        }
    }
}
