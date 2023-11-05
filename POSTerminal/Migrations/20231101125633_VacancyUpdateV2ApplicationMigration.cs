using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSTerminal.Migrations
{
    /// <inheritdoc />
    public partial class VacancyUpdateV2ApplicationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicSrc",
                table: "JobsItems",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicSrc",
                table: "JobsItems");
        }
    }
}
