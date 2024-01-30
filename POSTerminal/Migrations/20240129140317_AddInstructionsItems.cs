using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSTerminal.Migrations
{
    /// <inheritdoc />
    public partial class AddInstructionsItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructionItemsId",
                table: "ViewerItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ViewerItems_InstructionItemsId",
                table: "ViewerItems",
                column: "InstructionItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ViewerItems_InstructionItems_InstructionItemsId",
                table: "ViewerItems",
                column: "InstructionItemsId",
                principalTable: "InstructionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViewerItems_InstructionItems_InstructionItemsId",
                table: "ViewerItems");

            migrationBuilder.DropIndex(
                name: "IX_ViewerItems_InstructionItemsId",
                table: "ViewerItems");

            migrationBuilder.DropColumn(
                name: "InstructionItemsId",
                table: "ViewerItems");
        }
    }
}
