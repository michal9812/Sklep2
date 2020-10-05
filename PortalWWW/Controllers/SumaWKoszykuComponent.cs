using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalWWW.Models.BusinessLogic;
using SklepKomputerowy.Data.Data;
namespace PortalWWW.Controllers
{
    public class SumaWKoszykuComponent : ViewComponent
    {
        private readonly SklepKomputerowyContext _context;
        public SumaWKoszykuComponent(SklepKomputerowyContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            KoszykBusinessLogic koszyk = new KoszykBusinessLogic(this._context, this.HttpContext);
            return View("SumaWKoszykuComponent", await koszyk.GetRazem());
        }
    }
}
