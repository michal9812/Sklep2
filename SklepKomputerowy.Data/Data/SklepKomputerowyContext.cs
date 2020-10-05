using Microsoft.EntityFrameworkCore;
using SklepKomputerowy.Data.Data.Sklep;
using System;
using System.Collections.Generic;
using System.Text;
namespace SklepKomputerowy.Data.Data
{
    public class SklepKomputerowyContext : DbContext
    {
        public SklepKomputerowyContext()
        {
        }
        public SklepKomputerowyContext(DbContextOptions<SklepKomputerowyContext> options) : base(options)
        {
        }
        public DbSet<Kategoria> Kategoria { get; set; }
        public DbSet<Produkt> Produkt { get; set; }
        public DbSet<Zdjecia> Zdjecia { get; set; }
        public DbSet<ElemntKoszyka> ElemntKoszyka { get; set; }
        public DbSet<Zamowienie> Zamowienie { get; set; }
        public DbSet<PozycjaZamowienia> PozycjaZamowienia { get; set; }
        public DbSet<ZamowienieTemp> ZamowienieTemp { get; set; }
        public DbSet<PozycjaZamowieniaTemp> PozycjaZamowieniaTemp { get; set; }
        public DbSet<Kraj> Kraj { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produkt>()
                .HasIndex(z => z.Kod)
                .IsUnique();
            modelBuilder.Entity<Zdjecia>()
             .Property(z => z.ZdjecieURL)
             .IsRequired(false);

            modelBuilder.Entity<PozycjaZamowienia>().HasOne(p => p.Zamowienie).WithMany(b => b.PozycjaZamowienia)
            .HasForeignKey(p => p.IdZamowienia)
            .OnDelete(DeleteBehavior.Cascade);
        }

    //    protected override void OnConfiguring(DbContextOptionsBuilder options)
    //=> options.UseSqlite("Server=(localdb)\\mssqllocaldb;Database=SklepKomputerowyContextTest;MultipleActiveResultSets=true");
    }
}
