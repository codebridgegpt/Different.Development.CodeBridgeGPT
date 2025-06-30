using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeBridgeGPT.DbContext.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeBridgeGptDbResponse",
                columns: table => new
                {
                    TaskResponseId = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeBridgeGptDbResponse", x => x.TaskResponseId);
                });

            migrationBuilder.CreateTable(
                name: "FilesModel",
                columns: table => new
                {
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CodeBridgeGptResponseModelTaskResponseId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesModel", x => x.FilePath);
                    table.ForeignKey(
                        name: "FK_FilesModel_CodeBridgeGptDbResponse_CodeBridgeGptResponseMod~",
                        column: x => x.CodeBridgeGptResponseModelTaskResponseId,
                        principalTable: "CodeBridgeGptDbResponse",
                        principalColumn: "TaskResponseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilesModel_CodeBridgeGptResponseModelTaskResponseId",
                table: "FilesModel",
                column: "CodeBridgeGptResponseModelTaskResponseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilesModel");

            migrationBuilder.DropTable(
                name: "CodeBridgeGptDbResponse");
        }
    }
}
