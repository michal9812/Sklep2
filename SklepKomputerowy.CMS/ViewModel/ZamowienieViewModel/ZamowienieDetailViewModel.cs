using SklepKomputerowy.Data.Data;
using SklepKomputerowy.Data.Data.Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SklepKomputerowy.CMS.ViewModel.ZamowienieViewModel
{
    public class ZamowienieDetailViewModel
    {
        private readonly SklepKomputerowyContext _context;

        public ZamowienieDetailViewModel(SklepKomputerowyContext context)
        {
            _context = context;
        }
        public Zamowienie Zamowienie { get; set; }
        public PozycjaZamowienia PozycjaZamowienia { get; set; }
    }
}
