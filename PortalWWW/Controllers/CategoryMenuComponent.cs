using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SklepKomputerowy.Data.Data;

namespace PortalWWW.Controllers
{
    public class CategoryMenuComponent : ViewComponent
    {
        private readonly  SklepKomputerowyContext _context;

        public CategoryMenuComponent(SklepKomputerowyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("CategoryMenuComponent", await _context.Kategoria.ToListAsync());
        }
    }
}
