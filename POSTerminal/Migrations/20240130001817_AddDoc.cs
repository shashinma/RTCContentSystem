using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSTerminal.Migrations
{
    /// <inheritdoc />
    public partial class AddDoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViewerItems");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Document",
                table: "DocumentItems",
                type: "BLOB",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Document",
                table: "DocumentItems",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ViewerItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InstructionItemsId = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewerItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewerItems_InstructionItems_InstructionItemsId",
                        column: x => x.InstructionItemsId,
                        principalTable: "InstructionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ViewerItems_InstructionItemsId",
                table: "ViewerItems",
                column: "InstructionItemsId");
        }
    }
}
