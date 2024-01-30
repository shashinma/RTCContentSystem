using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSTerminal.Migrations
{
    /// <inheritdoc />
    public partial class AddInstructionsImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "InstructionItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructionItems_ImageId",
                table: "InstructionItems",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructionItems_ImageItems_ImageId",
                table: "InstructionItems",
                column: "ImageId",
                principalTable: "ImageItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructionItems_ImageItems_ImageId",
                table: "InstructionItems");

            migrationBuilder.DropIndex(
                name: "IX_InstructionItems_ImageId",
                table: "InstructionItems");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "InstructionItems");
        }
    }
}
