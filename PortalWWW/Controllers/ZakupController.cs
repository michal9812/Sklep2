using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalWWW.Models.BusinessLogic;
using SklepKomputerowy.Data.Data;
using SklepKomputerowy.Data.Data.Sklep;
namespace PortalWWW.Controllers
{
    public class ZakupController : Controller
    {
        private readonly SklepKomputerowyContext _context;
        public ZakupController(SklepKomputerowyContext context)
        {
            _context = context;
        }
        public IActionResult Dane()
        {
            ViewData["ListaPanstw"] = new SelectList(_context.Kraj, "IDKraju", "NazwaPL");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dane([Bind("IdZamowienieTemp,Login,Imie,Nazwisko,Ulica,Miasto,NumerDomu,KodPocztowy,IDKraju,NumerTelefonu,Email,Razem")] ZamowienieTemp ZamowienieTemp)
        {
            ViewData["ListaPanstw"] = new SelectList(_context.Kraj, "IDKraju", "NazwaPL");
            if (ModelState.IsValid)
            {
                ZamowienieTemp.DataZamowienia = DateTime.Now;
                KoszykBusinessLogic koszyk = new KoszykBusinessLogic(this._context, this.HttpContext);
                var elementyKoszyka = await koszyk.GetElementyKoszyka();
                ZamowienieTemp.Razem = await koszyk.GetRazem();
                await _context.AddAsync(ZamowienieTemp);
                await _context.SaveChangesAsync();
                foreach (var element in elementyKoszyka)
                {
                    var PozycjaZamowieniaTemp = new PozycjaZamowieniaTemp
                    {
                        idProduktu = element.IdProduktu,
                        IdZamowienieTemp = ZamowienieTemp.IdZamowienieTemp,
                        Produkt = element.Produkt,
                        Cena = element.Produkt.Cena,
                        Ilosc = element.Ilosc,
                    };
                    await _context.PozycjaZamowieniaTemp.AddAsync(PozycjaZamowieniaTemp);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Podsumowanie", new { id = ZamowienieTemp.IdZamowienieTemp });
            }
            return View();
        }
        public async Task<ActionResult> Podsumowanie(int id)
        {
            var ZamowienieTemp = await _context.ZamowienieTemp.FirstOrDefaultAsync(z => z.IdZamowienieTemp == id);
            ViewBag.Panstwo = _context.Kraj.FirstOrDefault(k => k.IDKraju == ZamowienieTemp.IDKraju).NazwaPL.ToString();
            if (ZamowienieTemp == null)
            {
                return View("Error");
            }
            return View(ZamowienieTemp);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Kup(int id)
        {
            var zt = await _context.ZamowienieTemp.FirstOrDefaultAsync(z => z.IdZamowienieTemp == id);
            Zamowienie zamowienie = new Zamowienie(zt.Login, zt.Imie, zt.Nazwisko, zt.Ulica, zt.Miasto, zt.NumerDomu, zt.KodPocztowy, zt.NumerTelefonu, zt.Email, zt.Razem, zt.IDKraju, zt.Kraj);
            zamowienie.DataZamowienia = DateTime.Now;
            await _context.AddAsync(zamowienie);
            await _context.SaveChangesAsync();
            List<PozycjaZamowieniaTemp> pozycjaZamowieniaTemp = await _context.PozycjaZamowieniaTemp.Include(pzt => pzt.Produkt).Where(pzt => pzt.IdZamowienieTemp == zt.IdZamowienieTemp).ToListAsync();
            foreach (var element in pozycjaZamowieniaTemp)
            {
                var PozycjaZamowienia = new PozycjaZamowienia
                {
                    idProduktu = element.idProduktu,
                    IdZamowienia = zamowienie.IdZamowienia,
                    Produkt = element.Produkt,
                    Cena = element.Produkt.Cena,
                    Ilosc = element.Ilosc,
                };
                await _context.PozycjaZamowienia.AddAsync(PozycjaZamowienia);
            }
            await _context.SaveChangesAsync();
            return View(zamowienie);
        }
    }
}
