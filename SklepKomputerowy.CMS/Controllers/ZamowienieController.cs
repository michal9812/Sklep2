using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using SklepKomputerowy.CMS.Services;
using SklepKomputerowy.Data.Data;
using SklepKomputerowy.Data.Data.Sklep;
namespace SklepKomputerowy.CMS.Controllers
{
    public class ZamowienieController : Controller
    {
        private readonly SklepKomputerowyContext _context;
        public readonly FilterZamowienieServices _filterZamowienieServices;

        public ZamowienieController(SklepKomputerowyContext context, FilterZamowienieServices filterZamowienieServices)
        {
            _context = context;
            _filterZamowienieServices = filterZamowienieServices;
        }
        // GET: Zamowienie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zamowienie.ToListAsync());
        }
        [HttpPost]
        public IActionResult Index(Zamowienie zamowienie)
        {
            return View(zamowienie);
        }
        [HttpGet]
        public IActionResult ZamowienieList(string adres, string imieNazwisko, string dataPoczotek, string dataKoniec)
        {
            if (string.IsNullOrEmpty(adres) && string.IsNullOrEmpty(imieNazwisko) && string.IsNullOrEmpty(dataPoczotek) && string.IsNullOrEmpty(dataKoniec))
            {
                return PartialView(_filterZamowienieServices.Wszystko());
            }
            else
            {
                if (string.IsNullOrEmpty(adres) && string.IsNullOrEmpty(imieNazwisko))
                {
                    return PartialView(_filterZamowienieServices.FiltrujPoDacie(dataPoczotek, dataKoniec));
                }
            }
            

        }
        // GET: Zamowienie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var zamowienie = await _context.Zamowienie
                .FirstOrDefaultAsync(m => m.IdZamowienia == id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            return View(zamowienie);
        }
        // GET: Zamowienie/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Zamowienie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZamowienia,DataZamowienia,Login,Imie,Nazwisko,Ulica,Miasto,NumerDomu,KodPocztowy,NumerTelefonu,Email,Razem,IDKraju")] Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zamowienie);
        }
        // GET: Zamowienie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var zamowienie = await _context.Zamowienie.FindAsync(id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            return View(zamowienie);
        }
        // POST: Zamowienie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZamowienia,DataZamowienia,Login,Imie,Nazwisko,Ulica,Miasto,NumerDomu,KodPocztowy,NumerTelefonu,Email,Razem,IDKraju")] Zamowienie zamowienie)
        {
            if (id != zamowienie.IdZamowienia)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowienieExists(zamowienie.IdZamowienia))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(zamowienie);
        }
        // GET: Zamowienie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var zamowienie = await _context.Zamowienie
                .FirstOrDefaultAsync(m => m.IdZamowienia == id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            return View(zamowienie);
        }
        // POST: Zamowienie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienie = await _context.Zamowienie.FindAsync(id);
            _context.Zamowienie.Remove(zamowienie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ZamowienieExists(int id)
        {
            return _context.Zamowienie.Any(e => e.IdZamowienia == id);
        }
    }
}
