using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace elibrary.Migrations
{
    /// <inheritdoc />
    public partial class addingnewname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazki_Autorzy_AutorId",
                table: "Ksiazki");

            migrationBuilder.DropTable(
                name: "Bib_Ksiazki");

            migrationBuilder.RenameColumn(
                name: "WydawnictwoId",
                table: "Wydawnictwa",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Ksiazki",
                newName: "BibId");

            migrationBuilder.RenameColumn(
                name: "KsiazkaId",
                table: "Ksiazki",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ksiazki_AutorId",
                table: "Ksiazki",
                newName: "IX_Ksiazki_BibId");

            migrationBuilder.RenameColumn(
                name: "BibId",
                table: "Biblioteki",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Autorzy",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Autor_Ksiazki",
                columns: table => new
                {
                    KsiazkaId = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor_Ksiazki", x => new { x.KsiazkaId, x.AutorId });
                    table.ForeignKey(
                        name: "FK_Autor_Ksiazki_Autorzy_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autorzy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autor_Ksiazki_Ksiazki_KsiazkaId",
                        column: x => x.KsiazkaId,
                        principalTable: "Ksiazki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autor_Ksiazki_AutorId",
                table: "Autor_Ksiazki",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazki_Biblioteki_BibId",
                table: "Ksiazki",
                column: "BibId",
                principalTable: "Biblioteki",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazki_Biblioteki_BibId",
                table: "Ksiazki");

            migrationBuilder.DropTable(
                name: "Autor_Ksiazki");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Wydawnictwa",
                newName: "WydawnictwoId");

            migrationBuilder.RenameColumn(
                name: "BibId",
                table: "Ksiazki",
                newName: "AutorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ksiazki",
                newName: "KsiazkaId");

            migrationBuilder.RenameIndex(
                name: "IX_Ksiazki_BibId",
                table: "Ksiazki",
                newName: "IX_Ksiazki_AutorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Biblioteki",
                newName: "BibId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Autorzy",
                newName: "AutorId");

            migrationBuilder.CreateTable(
                name: "Bib_Ksiazki",
                columns: table => new
                {
                    KsiazkaId = table.Column<int>(type: "int", nullable: false),
                    BibId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bib_Ksiazki", x => new { x.KsiazkaId, x.BibId });
                    table.ForeignKey(
                        name: "FK_Bib_Ksiazki_Biblioteki_BibId",
                        column: x => x.BibId,
                        principalTable: "Biblioteki",
                        principalColumn: "BibId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bib_Ksiazki_Ksiazki_KsiazkaId",
                        column: x => x.KsiazkaId,
                        principalTable: "Ksiazki",
                        principalColumn: "KsiazkaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bib_Ksiazki_BibId",
                table: "Bib_Ksiazki",
                column: "BibId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazki_Autorzy_AutorId",
                table: "Ksiazki",
                column: "AutorId",
                principalTable: "Autorzy",
                principalColumn: "AutorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
