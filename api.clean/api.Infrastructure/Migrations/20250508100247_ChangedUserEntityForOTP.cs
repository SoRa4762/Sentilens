using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserEntityForOTP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1309795b-a354-4e3d-9832-d6071a9091a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63015a95-5a43-4a82-92a3-a8ba115379e3");

            migrationBuilder.AddColumn<int>(
                name: "OtpAttemptCount",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OtpExpiration",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtpSecret",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b56c7f8-8e2e-4163-bd08-f2a5a805d842", null, "Admin", "ADMIN" },
                    { "63a25e37-a373-48e1-a66b-d540d4ef121e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b56c7f8-8e2e-4163-bd08-f2a5a805d842");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63a25e37-a373-48e1-a66b-d540d4ef121e");

            migrationBuilder.DropColumn(
                name: "OtpAttemptCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OtpExpiration",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OtpSecret",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1309795b-a354-4e3d-9832-d6071a9091a8", null, "User", "USER" },
                    { "63015a95-5a43-4a82-92a3-a8ba115379e3", null, "Admin", "ADMIN" }
                });
        }
    }
}
