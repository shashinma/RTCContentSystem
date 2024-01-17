using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSTerminal.Migrations
{
    /// <inheritdoc />
    public partial class AddImageIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "NewsItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImageItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Image = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_ImageId",
                table: "NewsItems",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsItems_ImageItems_ImageId",
                table: "NewsItems",
                column: "ImageId",
                principalTable: "ImageItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsItems_ImageItems_ImageId",
                table: "NewsItems");

            migrationBuilder.DropTable(
                name: "ImageItems");

            migrationBuilder.DropIndex(
                name: "IX_NewsItems_ImageId",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "NewsItems");
        }
    }
}
