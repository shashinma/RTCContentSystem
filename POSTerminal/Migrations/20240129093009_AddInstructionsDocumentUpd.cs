using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSTerminal.Migrations
{
    /// <inheritdoc />
    public partial class AddInstructionsDocumentUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "InstructionItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructionItems_DocumentId",
                table: "InstructionItems",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructionItems_DocumentItems_DocumentId",
                table: "InstructionItems",
                column: "DocumentId",
                principalTable: "DocumentItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructionItems_DocumentItems_DocumentId",
                table: "InstructionItems");

            migrationBuilder.DropIndex(
                name: "IX_InstructionItems_DocumentId",
                table: "InstructionItems");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "InstructionItems");
        }
    }
}
