using SklepKomputerowy.Data.Data.Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalWWW.ViewModels
{
    public class KoszykViewModel
    {
        public List<ElemntKoszyka>  ElementyKoszyka { get; set; }
        public decimal Razem { get; set; }

    }
}
