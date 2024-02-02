using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSTerminal.Migrations
{
    /// <inheritdoc />
    public partial class AddJobImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "JobsItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobsItems_ImageId",
                table: "JobsItems",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobsItems_ImageItems_ImageId",
                table: "JobsItems",
                column: "ImageId",
                principalTable: "ImageItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobsItems_ImageItems_ImageId",
                table: "JobsItems");

            migrationBuilder.DropIndex(
                name: "IX_JobsItems_ImageId",
                table: "JobsItems");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "JobsItems");
        }
    }
}
