using Microsoft.EntityFrameworkCore.Migrations;

namespace SklepKomputerowy.Data.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZamowienieTymczasowe_Kraj_KrajIDKraju",
                table: "ZamowienieTymczasowe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZamowienieTymczasowe",
                table: "ZamowienieTymczasowe");

            migrationBuilder.RenameTable(
                name: "ZamowienieTymczasowe",
                newName: "ZamowienieTemp");

            migrationBuilder.RenameIndex(
                name: "IX_ZamowienieTymczasowe_KrajIDKraju",
                table: "ZamowienieTemp",
                newName: "IX_ZamowienieTemp_KrajIDKraju");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZamowienieTemp",
                table: "ZamowienieTemp",
                column: "IdZamowienieTemp");

            migrationBuilder.CreateTable(
                name: "PozycjaZamowieniaTemp",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ilosc = table.Column<int>(nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    idProduktu = table.Column<int>(nullable: false),
                    ProduktidProduktu = table.Column<int>(nullable: true),
                    IdZamowienieTemp = table.Column<int>(nullable: false),
                    ZamowienieTempIdZamowienieTemp = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjaZamowieniaTemp", x => x.id);
                    table.ForeignKey(
                        name: "FK_PozycjaZamowieniaTemp_Produkt_ProduktidProduktu",
                        column: x => x.ProduktidProduktu,
                        principalTable: "Produkt",
                        principalColumn: "idProduktu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PozycjaZamowieniaTemp_ZamowienieTemp_ZamowienieTempIdZamowienieTemp",
                        column: x => x.ZamowienieTempIdZamowienieTemp,
                        principalTable: "ZamowienieTemp",
                        principalColumn: "IdZamowienieTemp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PozycjaZamowieniaTemp_ProduktidProduktu",
                table: "PozycjaZamowieniaTemp",
                column: "ProduktidProduktu");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjaZamowieniaTemp_ZamowienieTempIdZamowienieTemp",
                table: "PozycjaZamowieniaTemp",
                column: "ZamowienieTempIdZamowienieTemp");

            migrationBuilder.AddForeignKey(
                name: "FK_ZamowienieTemp_Kraj_KrajIDKraju",
                table: "ZamowienieTemp",
                column: "KrajIDKraju",
                principalTable: "Kraj",
                principalColumn: "IDKraju",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZamowienieTemp_Kraj_KrajIDKraju",
                table: "ZamowienieTemp");

            migrationBuilder.DropTable(
                name: "PozycjaZamowieniaTemp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZamowienieTemp",
                table: "ZamowienieTemp");

            migrationBuilder.RenameTable(
                name: "ZamowienieTemp",
                newName: "ZamowienieTymczasowe");

            migrationBuilder.RenameIndex(
                name: "IX_ZamowienieTemp_KrajIDKraju",
                table: "ZamowienieTymczasowe",
                newName: "IX_ZamowienieTymczasowe_KrajIDKraju");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZamowienieTymczasowe",
                table: "ZamowienieTymczasowe",
                column: "IdZamowienieTemp");

            migrationBuilder.AddForeignKey(
                name: "FK_ZamowienieTymczasowe_Kraj_KrajIDKraju",
                table: "ZamowienieTymczasowe",
                column: "KrajIDKraju",
                principalTable: "Kraj",
                principalColumn: "IDKraju",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
