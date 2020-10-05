using Microsoft.EntityFrameworkCore.Migrations;

namespace SklepKomputerowy.Data.Migrations
{
    public partial class ZamowienieCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PozycjaZamowienia_Zamowienie_ZamowienieIdZamowienia",
                table: "PozycjaZamowienia");

            migrationBuilder.AlterColumn<int>(
                name: "ZamowienieIdZamowienia",
                table: "PozycjaZamowienia",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PozycjaZamowienia_Zamowienie_ZamowienieIdZamowienia",
                table: "PozycjaZamowienia",
                column: "ZamowienieIdZamowienia",
                principalTable: "Zamowienie",
                principalColumn: "IdZamowienia",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PozycjaZamowienia_Zamowienie_ZamowienieIdZamowienia",
                table: "PozycjaZamowienia");

            migrationBuilder.AlterColumn<int>(
                name: "ZamowienieIdZamowienia",
                table: "PozycjaZamowienia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
