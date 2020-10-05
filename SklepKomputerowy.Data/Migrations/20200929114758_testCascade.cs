using Microsoft.EntityFrameworkCore.Migrations;

namespace SklepKomputerowy.Data.Migrations
{
    public partial class testCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PozycjaZamowienia_Zamowienie_ZamowienieIdZamowienia",
                table: "PozycjaZamowienia");

            migrationBuilder.DropIndex(
                name: "IX_PozycjaZamowienia_ZamowienieIdZamowienia",
                table: "PozycjaZamowienia");

            migrationBuilder.DropColumn(
                name: "ZamowienieIdZamowienia",
                table: "PozycjaZamowienia");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjaZamowienia_IdZamowienia",
                table: "PozycjaZamowienia",
                column: "IdZamowienia");

            migrationBuilder.AddForeignKey(
                name: "FK_PozycjaZamowienia_Zamowienie_IdZamowienia",
                table: "PozycjaZamowienia",
                column: "IdZamowienia",
                principalTable: "Zamowienie",
                principalColumn: "IdZamowienia",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PozycjaZamowienia_Zamowienie_IdZamowienia",
                table: "PozycjaZamowienia");

            migrationBuilder.DropIndex(
                name: "IX_PozycjaZamowienia_IdZamowienia",
                table: "PozycjaZamowienia");

            migrationBuilder.AddColumn<int>(
                name: "ZamowienieIdZamowienia",
                table: "PozycjaZamowienia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PozycjaZamowienia_ZamowienieIdZamowienia",
                table: "PozycjaZamowienia",
                column: "ZamowienieIdZamowienia");

            migrationBuilder.AddForeignKey(
                name: "FK_PozycjaZamowienia_Zamowienie_ZamowienieIdZamowienia",
                table: "PozycjaZamowienia",
                column: "ZamowienieIdZamowienia",
                principalTable: "Zamowienie",
                principalColumn: "IdZamowienia",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
