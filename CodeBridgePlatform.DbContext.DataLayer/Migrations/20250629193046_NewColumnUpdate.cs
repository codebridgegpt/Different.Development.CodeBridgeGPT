using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeBridgeGPT.DbContext.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CodeBridgeGptDbResponse",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CodeBridgeGptDbResponse");
        }
    }
}
