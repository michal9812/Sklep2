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
    public class ZdjeciaController : Controller
    {
        private readonly SklepKomputerowyContext _context;
        public ZdjeciaController(SklepKomputerowyContext context)
        {
            _context = context;
        }
        // GET: Zdjecia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zdjecia.ToListAsync());
        }
        // GET: Zdjecia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var zdjecia = await _context.Zdjecia
                .FirstOrDefaultAsync(m => m.idZdjecia == id);
            if (zdjecia == null)
            {
                return NotFound();
            }
            return View(zdjecia);
        }
        // GET: Zdjecia/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Zdjecia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idZdjecia,ZdjecieURL,idProduktu")] Zdjecia zdjecia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zdjecia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zdjecia);
        }
        // GET: Zdjecia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var zdjecia = await _context.Zdjecia.FindAsync(id);
            if (zdjecia == null)
            {
                return NotFound();
            }
            return View(zdjecia);
        }
        // POST: Zdjecia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idZdjecia,ZdjecieURL,idProduktu")] Zdjecia zdjecia)
        {
            if (id != zdjecia.idZdjecia)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zdjecia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZdjeciaExists(zdjecia.idZdjecia))
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
            return View(zdjecia);
        }
        // GET: Zdjecia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var zdjecia = await _context.Zdjecia
                .FirstOrDefaultAsync(m => m.idZdjecia == id);
            if (zdjecia == null)
            {
                return NotFound();
            }
            return View(zdjecia);
        }
        // POST: Zdjecia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zdjecia = await _context.Zdjecia.FindAsync(id);
            _context.Zdjecia.Remove(zdjecia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ZdjeciaExists(int id)
        {
            return _context.Zdjecia.Any(e => e.idZdjecia == id);
        }
    }
}
//path = Path.Combine(path, file.FileName);
//if (System.IO.File.Exists(path))
//{
//    return produkt.FotoURL;
//}
//else
//    using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
//    {
//        file.CopyTo(fileStream);
//    }
//path.Concat(file.FileName);
//return path;