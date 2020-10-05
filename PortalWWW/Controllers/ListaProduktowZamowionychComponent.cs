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
    public class ListaProduktowZamowionychComponent : ViewComponent
    {
        private readonly SklepKomputerowyContext _context;
        public ListaProduktowZamowionychComponent(SklepKomputerowyContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            return View("ListaProduktowZamowionychComponent", await _context.PozycjaZamowieniaTemp.Include(e => e.Produkt).Include(e => e.ZamowienieTemp).Where(pz => pz.IdZamowienieTemp == id).ToListAsync());
        }
    }
}
