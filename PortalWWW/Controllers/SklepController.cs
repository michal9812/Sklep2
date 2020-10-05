using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SklepKomputerowy.Data.Data;

namespace PortalWWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly SklepKomputerowyContext _context;

        public SklepController(SklepKomputerowyContext context)
        {
            _context = context;
        }


        // GET: SklepKomputerowy
        public async Task<ActionResult> IndexAsync( int ?id)
        {
            ViewBag.Kategoria = await _context.Kategoria.ToListAsync();
            if (id == null)
            {
                var pierwszy = await _context.Kategoria.FirstAsync();
                id = pierwszy.IdKategorii;
            }
            return View(await _context.Produkt.Where(t => t.idKategorii == id).ToListAsync());
         
        }

        // GET: SklepKomputerowy/Details/5
        [HttpPost]
        public ActionResult Details(int idProduktu)
        {
            return View();
        }

        // GET: SklepKomputerowy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SklepKomputerowy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: SklepKomputerowy/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SklepKomputerowy/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: SklepKomputerowy/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SklepKomputerowy/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
