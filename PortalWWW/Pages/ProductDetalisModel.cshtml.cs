using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SklepKomputerowy.Data.Data;
using SklepKomputerowy.Data.Data.Sklep;

namespace PortalWWW.Pages
{
    public class ProductDetalisModel : PageModel
    {
        private readonly SklepKomputerowyContext _contex;

        public ProductDetalisModel(SklepKomputerowyContext contex)
        {
            _contex = contex;
        }

        public Produkt Produkt { get; set; }
        public List<Zdjecia> ZdjeciaList { get; set; }
        public async Task OnGetAsync( int id)
        {
            ZdjeciaList = await _contex.Zdjecia.Where(z => z.idProduktu == id).ToListAsync();

            Produkt = await _contex.Produkt.FirstOrDefaultAsync(p => p.idProduktu == id);

         
        }
    }
}
