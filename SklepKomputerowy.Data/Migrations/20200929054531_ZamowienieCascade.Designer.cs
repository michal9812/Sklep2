﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SklepKomputerowy.Data.Data;

namespace SklepKomputerowy.Data.Migrations
{
    [DbContext(typeof(SklepKomputerowyContext))]
    [Migration("20200929054531_ZamowienieCascade")]
    partial class ZamowienieCascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.ElemntKoszyka", b =>
                {
                    b.Property<int>("IdElementuKoszyka")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataUtworzenia")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProduktu")
                        .HasColumnType("int");

                    b.Property<string>("IdSesjiKoszyka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<int?>("ProduktidProduktu")
                        .HasColumnType("int");

                    b.HasKey("IdElementuKoszyka");

                    b.HasIndex("ProduktidProduktu");

                    b.ToTable("ElemntKoszyka");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.Kategoria", b =>
                {
                    b.Property<int>("IdKategorii")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdKategorii");

                    b.ToTable("Kategoria");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.Kraj", b =>
                {
                    b.Property<int>("IDKraju")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazwaEN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazwaPL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDKraju");

                    b.ToTable("Kraj");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.PozycjaZamowienia", b =>
                {
                    b.Property<int>("IdPozycjiZamowienia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cena")
                        .HasColumnType("money");

                    b.Property<int>("IdZamowienia")
                        .HasColumnType("int");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<int?>("ProduktidProduktu")
                        .HasColumnType("int");

                    b.Property<int>("ZamowienieIdZamowienia")
                        .HasColumnType("int");

                    b.Property<int>("idProduktu")
                        .HasColumnType("int");

                    b.HasKey("IdPozycjiZamowienia");

                    b.HasIndex("ProduktidProduktu");

                    b.HasIndex("ZamowienieIdZamowienia");

                    b.ToTable("PozycjaZamowienia");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.PozycjaZamowieniaTemp", b =>
                {
                    b.Property<int>("IdPozycjaZamowieniaTemp")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cena")
                        .HasColumnType("money");

                    b.Property<int>("IdZamowienieTemp")
                        .HasColumnType("int");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<int?>("ProduktidProduktu")
                        .HasColumnType("int");

                    b.Property<int?>("ZamowienieTempIdZamowienieTemp")
                        .HasColumnType("int");

                    b.Property<int>("idProduktu")
                        .HasColumnType("int");

                    b.HasKey("IdPozycjaZamowieniaTemp");

                    b.HasIndex("ProduktidProduktu");

                    b.HasIndex("ZamowienieTempIdZamowienieTemp");

                    b.ToTable("PozycjaZamowieniaTemp");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.Produkt", b =>
                {
                    b.Property<int>("idProduktu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cena")
                        .HasColumnType("money");

                    b.Property<string>("FotoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KategoriaIdKategorii")
                        .HasColumnType("int");

                    b.Property<string>("Kod")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Promocja")
                        .HasColumnType("bit");

                    b.Property<int>("idKategorii")
                        .HasColumnType("int");

                    b.HasKey("idProduktu");

                    b.HasIndex("KategoriaIdKategorii");

                    b.HasIndex("Kod")
                        .IsUnique();

                    b.ToTable("Produkt");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.Zamowienie", b =>
                {
                    b.Property<int>("IdZamowienia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataZamowienia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IDKraju")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(160)")
                        .HasMaxLength(160);

                    b.Property<string>("KodPocztowy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KrajIDKraju")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(160)")
                        .HasMaxLength(160);

                    b.Property<string>("NumerDomu")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("NumerTelefonu")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<decimal>("Razem")
                        .HasColumnType("money");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.HasKey("IdZamowienia");

                    b.HasIndex("KrajIDKraju");

                    b.ToTable("Zamowienie");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.ZamowienieTemp", b =>
                {
                    b.Property<int>("IdZamowienieTemp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataZamowienia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IDKraju")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(160)")
                        .HasMaxLength(160);

                    b.Property<string>("KodPocztowy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KrajIDKraju")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(160)")
                        .HasMaxLength(160);

                    b.Property<string>("NumerDomu")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("NumerTelefonu")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<decimal>("Razem")
                        .HasColumnType("money");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.HasKey("IdZamowienieTemp");

                    b.HasIndex("KrajIDKraju");

                    b.ToTable("ZamowienieTemp");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.Zdjecia", b =>
                {
                    b.Property<int>("idZdjecia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProduktidProduktu")
                        .HasColumnType("int");

                    b.Property<string>("ZdjecieURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idProduktu")
                        .HasColumnType("int");

                    b.HasKey("idZdjecia");

                    b.HasIndex("ProduktidProduktu");

                    b.ToTable("Zdjecia");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.ElemntKoszyka", b =>
                {
                    b.HasOne("SklepKomputerowy.Data.Data.Sklep.Produkt", "Produkt")
                        .WithMany()
                        .HasForeignKey("ProduktidProduktu");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.PozycjaZamowienia", b =>
                {
                    b.HasOne("SklepKomputerowy.Data.Data.Sklep.Produkt", "Produkt")
                        .WithMany()
                        .HasForeignKey("ProduktidProduktu");

                    b.HasOne("SklepKomputerowy.Data.Data.Sklep.Zamowienie", "Zamowienie")
                        .WithMany("PozycjaZamowienia")
                        .HasForeignKey("ZamowienieIdZamowienia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.PozycjaZamowieniaTemp", b =>
                {
                    b.HasOne("SklepKomputerowy.Data.Data.Sklep.Produkt", "Produkt")
                        .WithMany()
                        .HasForeignKey("ProduktidProduktu");

                    b.HasOne("SklepKomputerowy.Data.Data.Sklep.ZamowienieTemp", "ZamowienieTemp")
                        .WithMany("PozycjaZamowieniaTemp")
                        .HasForeignKey("ZamowienieTempIdZamowienieTemp");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.Produkt", b =>
                {
                    b.HasOne("SklepKomputerowy.Data.Data.Sklep.Kategoria", "Kategoria")
                        .WithMany("Produkt")
                        .HasForeignKey("KategoriaIdKategorii");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.Zamowienie", b =>
                {
                    b.HasOne("SklepKomputerowy.Data.Data.Sklep.Kraj", "Kraj")
                        .WithMany()
                        .HasForeignKey("KrajIDKraju");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.ZamowienieTemp", b =>
                {
                    b.HasOne("SklepKomputerowy.Data.Data.Sklep.Kraj", "Kraj")
                        .WithMany("ZamowienieTymczasowe")
                        .HasForeignKey("KrajIDKraju");
                });

            modelBuilder.Entity("SklepKomputerowy.Data.Data.Sklep.Zdjecia", b =>
                {
                    b.HasOne("SklepKomputerowy.Data.Data.Sklep.Produkt", "Produkt")
                        .WithMany("Zdjecia")
                        .HasForeignKey("ProduktidProduktu");
                });
#pragma warning restore 612, 618
        }
    }
}
