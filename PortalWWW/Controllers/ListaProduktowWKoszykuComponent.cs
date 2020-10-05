using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalWWW.Models.BusinessLogic;
using PortalWWW.ViewModels;
using SklepKomputerowy.Data.Data;
using SklepKomputerowy.Data.Data.Sklep;

namespace PortalWWW.Controllers
{
    public class ListaProduktowWKoszykuComponent : ViewComponent
    {
        private readonly SklepKomputerowyContext _context;

        public ListaProduktowWKoszykuComponent(SklepKomputerowyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            //var produktList = from produkt in _context.Produkt
            //                     join PozycjaZamowienia in _context.PozycjaZamowienia on produkt.idProduktu equals PozycjaZamowienia.idProduktu where PozycjaZamowienia.IdZamowienia==id
            //                     select produkt;

            KoszykBusinessLogic koszyk = new KoszykBusinessLogic(this._context, this.HttpContext);
            var viewModel = new KoszykViewModel
            {
                ElementyKoszyka = await koszyk.GetElementyKoszyka(),
                Razem = await koszyk.GetRazem()
            };
            return View("ListaProduktowWKoszykuComponent", viewModel);

        }
    }
}
