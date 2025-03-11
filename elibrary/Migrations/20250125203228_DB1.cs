using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace elibrary.Migrations
{
    /// <inheritdoc />
    public partial class DB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autorzy",
                columns: table => new
                {
                    AutorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorzy", x => x.AutorId);
                });

            migrationBuilder.CreateTable(
                name: "Biblioteki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoBib = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameBib = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescBib = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wydawnictwa",
                columns: table => new
                {
                    WydawnictwoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WydPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameWyd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescWyd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydawnictwa", x => x.WydawnictwoId);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazki",
                columns: table => new
                {
                    KsiazkaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescKs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublikacjaTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ksiazkaCategory = table.Column<int>(type: "int", nullable: false),
                    WydId = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazki", x => x.KsiazkaId);
                    table.ForeignKey(
                        name: "FK_Ksiazki_Autorzy_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autorzy",
                        principalColumn: "AutorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ksiazki_Wydawnictwa_WydId",
                        column: x => x.WydId,
                        principalTable: "Wydawnictwa",
                        principalColumn: "WydawnictwoId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        principalColumn: "Id",
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

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_AutorId",
                table: "Ksiazki",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_WydId",
                table: "Ksiazki",
                column: "WydId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bib_Ksiazki");

            migrationBuilder.DropTable(
                name: "Biblioteki");

            migrationBuilder.DropTable(
                name: "Ksiazki");

            migrationBuilder.DropTable(
                name: "Autorzy");

            migrationBuilder.DropTable(
                name: "Wydawnictwa");
        }
    }
}
