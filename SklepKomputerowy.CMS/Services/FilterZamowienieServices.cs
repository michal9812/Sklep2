using Microsoft.CodeAnalysis.CSharp.Syntax;
using SklepKomputerowy.Data.Data;
using SklepKomputerowy.Data.Data.Sklep;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SklepKomputerowy.CMS.Services
{
    public class FilterZamowienieServices
    {
        private readonly SklepKomputerowyContext _context;
        public FilterZamowienieServices(SklepKomputerowyContext context)
        {
            _context = context;
        }
        public IEnumerable<Zamowienie> Wszystko()
        {
            return _context.Zamowienie;
        }
        public IEnumerable<Zamowienie> FiltrujPoDacie(string dataPoczotek, string dataKoniec)
        {
            if (!string.IsNullOrEmpty(dataPoczotek) && !string.IsNullOrEmpty(dataKoniec))
            {
                DateTime dataPoczatekDateTime = Convert.ToDateTime(dataPoczotek);
                DateTime dataKoniecDateTime = Convert.ToDateTime(dataKoniec);
                return from z in _context.Zamowienie
                       where ((z.DataZamowienia >= dataPoczatekDateTime) && (z.DataZamowienia <= dataKoniecDateTime))
                       select z;
            }
            else if (!string.IsNullOrEmpty(dataPoczotek))
            {
                DateTime dataPoczatekDateTime = Convert.ToDateTime(dataPoczotek);
                return _context.Zamowienie.Where(z => z.DataZamowienia >= dataPoczatekDateTime);

            }
            else
            {
                DateTime dataKoniecDateTime = Convert.ToDateTime(dataKoniec);
                return _context.Zamowienie.Where(z => z.DataZamowienia <= dataKoniecDateTime);

            }

        }
        public IEnumerable<Zamowienie> FiltrujDaneOsobowe(string daneosobowe)
        {

            return from z in _context.Zamowienie
                   where (z.Imie.Contains(daneosobowe) || z.Nazwisko.Contains(daneosobowe))
                   select z;

        }
        public IEnumerable<Zamowienie> FiltrujPoAdresie(string adres)
        {

            return from z in _context.Zamowienie
                   where z.Miasto.Contains(adres) || z.Ulica.Contains(adres) || z.NumerDomu.Contains(adres)
                   select z;

        }
        public IEnumerable<Zamowienie> FiltrujPoAdresieDaneOsobowe(string adres, string daneosobowe)
        {

            return from z in _context.Zamowienie
                   where ((z.Miasto.Contains(adres) || z.Ulica.Contains(adres) || z.NumerDomu.Contains(adres)) &&(z.Imie.Contains(daneosobowe) || z.Nazwisko.Contains(daneosobowe)))
                   select z;

        }
    }
}
