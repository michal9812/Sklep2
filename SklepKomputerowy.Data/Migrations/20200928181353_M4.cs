using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SklepKomputerowy.Data.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoria",
                columns: table => new
                {
                    IdKategorii = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 30, nullable: false),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoria", x => x.IdKategorii);
                });

            migrationBuilder.CreateTable(
                name: "Kraj",
                columns: table => new
                {
                    IDKraju = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaPL = table.Column<string>(nullable: true),
                    NazwaEN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kraj", x => x.IDKraju);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    idProduktu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(nullable: false),
                    Nazwa = table.Column<string>(nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    FotoURL = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Promocja = table.Column<bool>(nullable: false),
                    idKategorii = table.Column<int>(nullable: false),
                    KategoriaIdKategorii = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.idProduktu);
                    table.ForeignKey(
                        name: "FK_Produkt_Kategoria_KategoriaIdKategorii",
                        column: x => x.KategoriaIdKategorii,
                        principalTable: "Kategoria",
                        principalColumn: "IdKategorii",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataZamowienia = table.Column<DateTime>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Imie = table.Column<string>(maxLength: 160, nullable: false),
                    Nazwisko = table.Column<string>(maxLength: 160, nullable: false),
                    Ulica = table.Column<string>(maxLength: 70, nullable: false),
                    Miasto = table.Column<string>(maxLength: 70, nullable: false),
                    NumerDomu = table.Column<string>(maxLength: 3, nullable: false),
                    KodPocztowy = table.Column<string>(nullable: false),
                    NumerTelefonu = table.Column<string>(maxLength: 24, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Razem = table.Column<decimal>(type: "money", nullable: false),
                    IDKraju = table.Column<int>(nullable: false),
                    KrajIDKraju = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Kraj_KrajIDKraju",
                        column: x => x.KrajIDKraju,
                        principalTable: "Kraj",
                        principalColumn: "IDKraju",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZamowienieTymczasowe",
                columns: table => new
                {
                    IdZamowienieTemp = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataZamowienia = table.Column<DateTime>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Imie = table.Column<string>(maxLength: 160, nullable: false),
                    Nazwisko = table.Column<string>(maxLength: 160, nullable: false),
                    Ulica = table.Column<string>(maxLength: 70, nullable: false),
                    Miasto = table.Column<string>(maxLength: 70, nullable: false),
                    NumerDomu = table.Column<string>(maxLength: 3, nullable: false),
                    KodPocztowy = table.Column<string>(nullable: false),
                    NumerTelefonu = table.Column<string>(maxLength: 24, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Razem = table.Column<decimal>(type: "money", nullable: false),
                    IDKraju = table.Column<int>(nullable: false),
                    KrajIDKraju = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamowienieTymczasowe", x => x.IdZamowienieTemp);
                    table.ForeignKey(
                        name: "FK_ZamowienieTymczasowe_Kraj_KrajIDKraju",
                        column: x => x.KrajIDKraju,
                        principalTable: "Kraj",
                        principalColumn: "IDKraju",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElemntKoszyka",
                columns: table => new
                {
                    IdElementuKoszyka = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSesjiKoszyka = table.Column<string>(nullable: true),
                    IdProduktu = table.Column<int>(nullable: false),
                    ProduktidProduktu = table.Column<int>(nullable: true),
                    Ilosc = table.Column<int>(nullable: false),
                    DataUtworzenia = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElemntKoszyka", x => x.IdElementuKoszyka);
                    table.ForeignKey(
                        name: "FK_ElemntKoszyka_Produkt_ProduktidProduktu",
                        column: x => x.ProduktidProduktu,
                        principalTable: "Produkt",
                        principalColumn: "idProduktu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zdjecia",
                columns: table => new
                {
                    idZdjecia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZdjecieURL = table.Column<string>(nullable: true),
                    ProduktidProduktu = table.Column<int>(nullable: true),
                    idProduktu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zdjecia", x => x.idZdjecia);
                    table.ForeignKey(
                        name: "FK_Zdjecia_Produkt_ProduktidProduktu",
                        column: x => x.ProduktidProduktu,
                        principalTable: "Produkt",
                        principalColumn: "idProduktu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PozycjaZamowienia",
                columns: table => new
                {
                    IdPozycjiZamowienia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ilosc = table.Column<int>(nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    idProduktu = table.Column<int>(nullable: false),
                    ProduktidProduktu = table.Column<int>(nullable: true),
                    IdZamowienia = table.Column<int>(nullable: false),
                    ZamowienieIdZamowienia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjaZamowienia", x => x.IdPozycjiZamowienia);
                    table.ForeignKey(
                        name: "FK_PozycjaZamowienia_Produkt_ProduktidProduktu",
                        column: x => x.ProduktidProduktu,
                        principalTable: "Produkt",
                        principalColumn: "idProduktu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PozycjaZamowienia_Zamowienie_ZamowienieIdZamowienia",
                        column: x => x.ZamowienieIdZamowienia,
                        principalTable: "Zamowienie",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElemntKoszyka_ProduktidProduktu",
                table: "ElemntKoszyka",
                column: "ProduktidProduktu");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjaZamowienia_ProduktidProduktu",
                table: "PozycjaZamowienia",
                column: "ProduktidProduktu");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjaZamowienia_ZamowienieIdZamowienia",
                table: "PozycjaZamowienia",
                column: "ZamowienieIdZamowienia");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_KategoriaIdKategorii",
                table: "Produkt",
                column: "KategoriaIdKategorii");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_Kod",
                table: "Produkt",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_KrajIDKraju",
                table: "Zamowienie",
                column: "KrajIDKraju");

            migrationBuilder.CreateIndex(
                name: "IX_ZamowienieTymczasowe_KrajIDKraju",
                table: "ZamowienieTymczasowe",
                column: "KrajIDKraju");

            migrationBuilder.CreateIndex(
                name: "IX_Zdjecia_ProduktidProduktu",
                table: "Zdjecia",
                column: "ProduktidProduktu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElemntKoszyka");

            migrationBuilder.DropTable(
                name: "PozycjaZamowienia");

            migrationBuilder.DropTable(
                name: "ZamowienieTymczasowe");

            migrationBuilder.DropTable(
                name: "Zdjecia");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Kraj");

            migrationBuilder.DropTable(
                name: "Kategoria");
        }
    }
}
