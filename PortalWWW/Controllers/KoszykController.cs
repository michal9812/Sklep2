using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using PortalWWW.Models.BusinessLogic;
using PortalWWW.ViewModels;
using SklepKomputerowy.Data.Data;
using SklepKomputerowy.Data.Data.Sklep;

namespace Firma.PortalWWW.Controllers
{
    public class KoszykController : Controller
    {
        private readonly SklepKomputerowyContext _context;
        public KoszykController(SklepKomputerowyContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            KoszykBusinessLogic koszyk = new KoszykBusinessLogic(this._context, this.HttpContext);
            var viewModel = new KoszykViewModel
            {
                ElementyKoszyka = await koszyk.GetElementyKoszyka(),
                Razem = await koszyk.GetRazem()
            };
            return View(viewModel);
        }
        public async Task<ActionResult> DodajDoKoszyka(int id)
        {

            // Add it to the shopping cart
            KoszykBusinessLogic koszyk = new KoszykBusinessLogic(this._context, this.HttpContext);
            Produkt produkt = await _context.Produkt.FindAsync(id);


            koszyk.DodajDoKoszyka(produkt);
            return RedirectToAction(nameof(Index));


            // Go back to the main store page for more shopping
        }

        public async Task DodajDokoszykaPojedynczo(int id)
        {
            KoszykBusinessLogic koszyk = new KoszykBusinessLogic(this._context, this.HttpContext);
            Produkt produkt = await _context.Produkt.FindAsync(id);
            koszyk.DodajDoKoszyka(produkt);
        }

        public async Task<IActionResult> UsunJeden(int id)
        {
            KoszykBusinessLogic koszyk = new KoszykBusinessLogic(this._context, this.HttpContext);
            Produkt produkt = await _context.Produkt.FindAsync(id);
            koszyk.usuniecieZKoszyka(produkt);
            return RedirectToAction("Index", "Koszyk");
            // Remove the item from the cart

            // Get the name of the album to display confirmation

            // Remove from cart

            // Display the confirmation message


        }

        [HttpPost]
        public async Task<IActionResult> UpdateCartCountAsync(int id, int liczbaProduktow)
        {
            // Remove the item from the cart
            KoszykBusinessLogic koszyk = new KoszykBusinessLogic(this._context, this.HttpContext);



            // Update the cart count 
            int itemCount = koszyk.UpdateCartCount(id, liczbaProduktow);
            string totalvalue = String.Format("{0:C}", await koszyk.GetRazem());


             var results = new UsuwanieZKoszykaViewModel
             {
                 Razem = totalvalue,
             };
            return Json (results);

        }
    }
   
}
