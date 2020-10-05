using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SklepKomputerowy.Data.Data;
using SklepKomputerowy.Data.Data.Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PortalWWW.Models.BusinessLogic
{
    public class KoszykBusinessLogic
    {
        private string IdSesjiKoszyka;
        private readonly SklepKomputerowyContext _context;
        public int LiczbaElementow { 
            get {
                int? count = (from elementyKoszyka in _context.ElemntKoszyka
                              where elementyKoszyka.IdSesjiKoszyka == this.IdSesjiKoszyka
                              select (int?)elementyKoszyka.Ilosc).Sum();
                // Return 0 if all entries are null
                return count ?? 0;
            }
        }
        public KoszykBusinessLogic(SklepKomputerowyContext context, HttpContext httpContext)
        {
            _context = context;
            this.IdSesjiKoszyka = GetIdSesjiKoszyka(httpContext);
        }
        private string GetIdSesjiKoszyka(HttpContext httpContext)
        {
            if (httpContext.Session.GetString("IdSesjiKoszyka") == null)
            {
                //Jeżeli context.User.Identity.Name nie jest puste i nie posiada białych zanków
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IdSesjiKoszyka", httpContext.User.Identity.Name);
                }
                else
                {
                    // W przeciwnym wypadku wygeneruj przy pomocy random Guid IdSesjiKoszyka
                    Guid tempIdSesjiKoszyka = Guid.NewGuid();
                    // Wyślij wygenerowane IdSesjiKoszyka jako cookie
                    httpContext.Session.SetString("IdSesjiKoszyka", tempIdSesjiKoszyka.ToString());
                }
            }
            return httpContext.Session.GetString("IdSesjiKoszyka").ToString();
        }
        public void  DodajDoKoszyka(Produkt produkt)
        {
            // Get the matching cart and album instances
            var elemntKoszyka = _context.ElemntKoszyka.SingleOrDefault(
                e => e.IdSesjiKoszyka == IdSesjiKoszyka
                && e.IdProduktu == produkt.idProduktu);
            if (elemntKoszyka == null)
            {
                // Create a new cart item if no cart item exists
                elemntKoszyka = new ElemntKoszyka()
                {
                    IdSesjiKoszyka = this.IdSesjiKoszyka,
                    IdProduktu = produkt.idProduktu,
                    Produkt = produkt,
                    Ilosc = 1,
                    DataUtworzenia = DateTime.Now
                };
                 _context.ElemntKoszyka.Add(elemntKoszyka);
            }
            else
            {
                elemntKoszyka.Ilosc++;
            }
            _context.SaveChanges();
        }
        public void usuniecieZKoszyka(Produkt produkt)
        {
            var elementKoszyka =
              (
                  from element in _context.ElemntKoszyka
                  where element.IdSesjiKoszyka == this.IdSesjiKoszyka && element.IdProduktu == produkt.idProduktu
                  select element
              ).FirstOrDefault();
            if (elementKoszyka != null && (elementKoszyka.Ilosc > 1))
            {
                elementKoszyka.Ilosc--;
            }
            _context.SaveChanges();
        }
        public void PustyKoszyk()
        {
            var elemntyKoszyka = _context.ElemntKoszyka.Where(
              e => e.IdSesjiKoszyka == IdSesjiKoszyka);
            foreach (var item in elemntyKoszyka)
            {
                _context.ElemntKoszyka.Remove(item);
            }
            _context.SaveChanges();
        }
     
        public async Task<List<ElemntKoszyka>> GetElementyKoszyka()
        {
            return await
               _context.ElemntKoszyka.Where(e => e.IdSesjiKoszyka == this.IdSesjiKoszyka).Include(e => e.Produkt).ToListAsync();

        }
        public async Task<decimal> GetRazem()
        {
            decimal? razem = await (from elementykoszyka in _context.ElemntKoszyka
                                    where elementykoszyka.IdSesjiKoszyka == this.IdSesjiKoszyka
                                    select (int?)elementykoszyka.Ilosc *
                                    elementykoszyka.Produkt.Cena).SumAsync();
            return razem ?? decimal.Zero;
        }
        public void MigrujKoszyk(string  nazwaUrzytkownika)
        {
            var koszyk = _context.ElemntKoszyka.Where(
                k=> k.IdSesjiKoszyka == this.IdSesjiKoszyka);
            foreach (ElemntKoszyka elemntKoszyka in koszyk)
            {
                elemntKoszyka.IdSesjiKoszyka = nazwaUrzytkownika;
            }
            _context.SaveChanges();
        }
        public int UpdateCartCount(int id, int liczbaProduktow)
        {
            // Get the cart 
            var elemntKoszyka = _context.ElemntKoszyka.FirstOrDefault(
                ek => ek.IdSesjiKoszyka == this.IdSesjiKoszyka
                && ek.IdElementuKoszyka == id);

            int licznik = 0;

            if (elemntKoszyka != null)
            {
                if (liczbaProduktow > 0)
                {
                    elemntKoszyka.Ilosc = liczbaProduktow;
                    licznik = elemntKoszyka.Ilosc;
                }
                else
                {
                    _context.ElemntKoszyka.Remove(elemntKoszyka);
                }
                // Save changes 
                _context.SaveChanges();
            }
            return licznik;
        }

    }

}
