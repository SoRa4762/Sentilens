using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "FeedSource");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "FeedSource",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "FeedSource");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "FeedSource",
                type: "text",
                nullable: true);
        }
    }
}
