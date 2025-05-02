using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdentityError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0aea438d-a8ea-4dab-80fe-3c94b3cf9545");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d70034f5-84eb-4b2e-b423-2caaff2b3d96");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1309795b-a354-4e3d-9832-d6071a9091a8", null, "User", "USER" },
                    { "63015a95-5a43-4a82-92a3-a8ba115379e3", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1309795b-a354-4e3d-9832-d6071a9091a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63015a95-5a43-4a82-92a3-a8ba115379e3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0aea438d-a8ea-4dab-80fe-3c94b3cf9545", null, "Admin", "ADMIN" },
                    { "d70034f5-84eb-4b2e-b423-2caaff2b3d96", null, "User", "USER" }
                });
        }
    }
}
