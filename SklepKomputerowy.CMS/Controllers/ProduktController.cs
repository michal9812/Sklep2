using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SklepKomputerowy.Data.Data;
using SklepKomputerowy.Data.Data.Sklep;
using SklepKomputerowy.CMS.EditModel;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;
namespace SklepKomputerowy.CMS.Controllers
{
    public class ProduktController : Controller
    {
        private readonly SklepKomputerowyContext _context;
        private readonly IWebHostEnvironment _env;
        public List<SelectListItem> ListaKategorii { get; set; }
        public ProduktController(SklepKomputerowyContext context)
        {
            _context = context;
        }
        // GET: Produkt
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produkt.ToListAsync());
        }
        // GET: Produkt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produkt = await _context.Produkt
                .FirstOrDefaultAsync(m => m.idProduktu == id);
            if (produkt == null)
            {
                return NotFound();
            }
            return View(produkt);
        }
        // GET: Produkt/Create
        public IActionResult Create()
        {
            ViewData["ListaKategorii"] = new SelectList(_context.Kategoria, "IdKategorii", "Nazwa");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProduktu,Kod,Nazwa,Cena,FotoURL,Opis,Promocja,idKategorii,ZdjecieURL")] ProduktZdjeciaEditModel crateProduktZdjeciaEditModel, IFormFileCollection files, IFormFile file)
        {
            ViewData["ListaKategorii"] = new SelectList(_context.Kategoria, "IdKategorii", "Nazwa");
            Produkt produkt = new Produkt(crateProduktZdjeciaEditModel.idProduktu, crateProduktZdjeciaEditModel.Kod, crateProduktZdjeciaEditModel.Nazwa, crateProduktZdjeciaEditModel.Cena, crateProduktZdjeciaEditModel.FotoURL, crateProduktZdjeciaEditModel.Opis, crateProduktZdjeciaEditModel.Promocja, crateProduktZdjeciaEditModel.idKategorii);
            if (ModelState.IsValid)
            {
                //produkt.FotoURL = uploadThumbnail(formFiles.GetFile(produkt.FotoURL),produkt);
                produkt.FotoURL = uploudImages(file, produkt);
                _context.Add(produkt);
                await _context.SaveChangesAsync();
                if (crateProduktZdjeciaEditModel.ZdjecieURL != null)
                {
                    foreach (var item in files)
                    {
                        _context.Zdjecia.Add(new Zdjecia(crateProduktZdjeciaEditModel.idZdjecia, uploudImages(item,produkt, "slaider"), produkt.idProduktu));
                        await _context.SaveChangesAsync();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(crateProduktZdjeciaEditModel);
        }
        // GET: Produkt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produkt = await _context.Produkt.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }
            ViewData["ListaKategorii"] = new SelectList(_context.Kategoria, "IdKategorii", "Nazwa");
            return View(produkt);
        }
        // POST: Produkt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProduktu,Kod,Nazwa,Cena,FotoURL,Opis,Promocja,idKategorii")] Produkt produkt)
        {
            if (id != produkt.idProduktu)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktExists(produkt.idProduktu))
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
            return View(produkt);
        }
        // GET: Produkt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produkt = await _context.Produkt
                .FirstOrDefaultAsync(m => m.idProduktu == id);
            if (produkt == null)
            {
                return NotFound();
            }
            return View(produkt);
        }
        // POST: Produkt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produkt = await _context.Produkt.FindAsync(id);
            _context.Produkt.Remove(produkt);
             _context.SaveChanges();
            _context.Zdjecia.RemoveRange(_context.Zdjecia.Where(z => z.idProduktu == produkt.idProduktu));
            _context.SaveChanges();
            if (Directory.Exists(($"../DataFiles/Produkty/{produkt.Kod}/")))
            {
                Directory.Delete($"../DataFiles/Produkty/{produkt.Kod}/", true);
            }
            return RedirectToAction(nameof(Index));
        }
        private bool ProduktExists(int id)
        {
            return _context.Produkt.Any(e => e.idProduktu == id);
        }
        public string uploudImages(IFormFile file, Produkt produkt)
        {
            string path = ($"Produkty/{produkt.Kod}/images/");
            string pathCreteFile = ($"../DataFiles/Produkty/{produkt.Kod}/images/");
            if (!Directory.Exists(pathCreteFile))
            {
                Directory.CreateDirectory(pathCreteFile);
            }
            pathCreteFile = Path.Combine(pathCreteFile, file.FileName);
            FileStream fileStream = saveFile(file, pathCreteFile);
            return Path.Combine(path, file.FileName);
        }
        private static FileStream saveFile(IFormFile file, string path)
        {
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            file.CopyTo(fileStream);
            return fileStream;
        }
        private string uploudImages(IFormFile file, Produkt produkt, string namefolder)
        {
            string path = ($"Produkty/{produkt.Kod}/images/{namefolder}");
            string pathCreteFile = ($"../DataFiles/Produkty/{produkt.Kod}/images/{namefolder}/");
            if (!Directory.Exists(pathCreteFile))
            {
                Directory.CreateDirectory(pathCreteFile);
            }
            pathCreteFile = Path.Combine(pathCreteFile, file.FileName);
            FileStream fileStream = saveFile(file, pathCreteFile);
            return Path.Combine(path, file.FileName);
        }
    }
    //SELECT K.NAZWA FROM Kategoria AS K INNER JOIN Produkt AS P ON K.IdKategorii=P.idKategorii
}
