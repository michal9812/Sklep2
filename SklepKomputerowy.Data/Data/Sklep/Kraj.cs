using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace SklepKomputerowy.Data.Data.Sklep
{
    public class Kraj
    {
        [Key]
        public int IDKraju { get; set; }
        public string NazwaPL { get; set; }
        public string NazwaEN { get; set; }
        public virtual ICollection<ZamowienieTemp> ZamowienieTymczasowe { get; set; }

    }
}
