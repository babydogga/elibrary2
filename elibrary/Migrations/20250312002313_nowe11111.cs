using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace elibrary.Migrations
{
    /// <inheritdoc />
    public partial class nowe11111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazki_Autorzy_AutorId",
                table: "Ksiazki");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Ksiazki",
                newName: "AutId");

            migrationBuilder.RenameIndex(
                name: "IX_Ksiazki_AutorId",
                table: "Ksiazki",
                newName: "IX_Ksiazki_AutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazki_Autorzy_AutId",
                table: "Ksiazki",
                column: "AutId",
                principalTable: "Autorzy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazki_Autorzy_AutId",
                table: "Ksiazki");

            migrationBuilder.RenameColumn(
                name: "AutId",
                table: "Ksiazki",
                newName: "AutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Ksiazki_AutId",
                table: "Ksiazki",
                newName: "IX_Ksiazki_AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazki_Autorzy_AutorId",
                table: "Ksiazki",
                column: "AutorId",
                principalTable: "Autorzy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
