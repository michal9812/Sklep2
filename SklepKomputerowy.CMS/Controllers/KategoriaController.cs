using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SklepKomputerowy.Data.Data;
using SklepKomputerowy.Data.Data.Sklep;
namespace SklepKomputerowy.CMS.Controllers
{
    public class KategoriaController : Controller
    {
        private readonly SklepKomputerowyContext _context;
        public KategoriaController(SklepKomputerowyContext context)
        {
            _context = context;
        }
        // GET: Kategoria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kategoria.ToListAsync());
        }
        // GET: Kategoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kategoria = await _context.Kategoria
                .FirstOrDefaultAsync(m => m.IdKategorii == id);
            if (kategoria == null)
            {
                return NotFound();
            }
            return View(kategoria);
        }
        // GET: Kategoria/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Kategoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKategorii,Nazwa,Opis")] Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategoria);
        }
        // GET: Kategoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kategoria = await _context.Kategoria.FindAsync(id);
            if (kategoria == null)
            {
                return NotFound();
            }
            return View(kategoria);
        }
        // POST: Kategoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKategorii,Nazwa,Opis")] Kategoria kategoria)
        {
            if (id != kategoria.IdKategorii)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriaExists(kategoria.IdKategorii))
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
            return View(kategoria);
        }
        // GET: Kategoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kategoria = await _context.Kategoria
                .FirstOrDefaultAsync(m => m.IdKategorii == id);
            if (kategoria == null)
            {
                return NotFound();
            }
            return View(kategoria);
        }
        // POST: Kategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategoria = await _context.Kategoria.FindAsync(id);
            _context.Kategoria.Remove(kategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool KategoriaExists(int id)
        {
            return _context.Kategoria.Any(e => e.IdKategorii == id);
        }
    }
}
