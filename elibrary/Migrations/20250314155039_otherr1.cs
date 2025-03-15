using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace elibrary.Migrations
{
    /// <inheritdoc />
    public partial class otherr1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazki_Autorzy_AutId",
                table: "Ksiazki");

            migrationBuilder.DropIndex(
                name: "IX_Ksiazki_AutId",
                table: "Ksiazki");

            migrationBuilder.DropColumn(
                name: "AutId",
                table: "Ksiazki");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autor_Ksiazki");

            migrationBuilder.AddColumn<int>(
                name: "AutId",
                table: "Ksiazki",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_AutId",
                table: "Ksiazki",
                column: "AutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazki_Autorzy_AutId",
                table: "Ksiazki",
                column: "AutId",
                principalTable: "Autorzy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
