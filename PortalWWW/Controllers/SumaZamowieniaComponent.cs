using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalWWW.Models.BusinessLogic;
using SklepKomputerowy.Data.Data;
using SklepKomputerowy.Data.Data.Sklep;

namespace PortalWWW.Controllers
{
    public class SumaZamowieniaComponent : ViewComponent
    {
        private readonly SklepKomputerowyContext _context;
        public SumaZamowieniaComponent(SklepKomputerowyContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var zt = await _context.ZamowienieTemp.FirstOrDefaultAsync(z => z.IdZamowienieTemp == id);

            return View("SumaZamowieniaComponent", zt.Razem);
        }
    }
}
