using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSTerminal.Migrations
{
    /// <inheritdoc />
    public partial class VacancyUpdateApplicationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "JobsItems",
                newName: "Vacancy");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "JobsItems",
                newName: "Responsibilities");

            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "JobsItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "JobsItems");

            migrationBuilder.RenameColumn(
                name: "Vacancy",
                table: "JobsItems",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Responsibilities",
                table: "JobsItems",
                newName: "Content");
        }
    }
}
