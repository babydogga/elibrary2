using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace elibrary.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Biblioteki",
                newName: "BibId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BibId",
                table: "Biblioteki",
                newName: "Id");
        }
    }
}
