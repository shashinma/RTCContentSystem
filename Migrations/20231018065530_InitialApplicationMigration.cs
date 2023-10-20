using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSTerminalWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialApplicationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "MenuItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "MenuItems");
        }
    }
}
