using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace SklepKomputerowy.Data.Data.Sklep
{
    public class ElemntKoszyka
    {
        public ElemntKoszyka()
        {
        }

        public ElemntKoszyka(int idElementuKoszyka, string idSesjiKoszyka, int idProduktu)
        {
            IdElementuKoszyka = idElementuKoszyka;
            IdSesjiKoszyka = idSesjiKoszyka;
            IdProduktu = idProduktu;
            DataUtworzenia = DateTime.Now;
            Ilosc = 1;
        }
        [Key]
        public int IdElementuKoszyka { get; set; }
        public string IdSesjiKoszyka { get; set; }
        public int IdProduktu { get; set; }
        public  virtual Produkt Produkt { get; set; }
        public int Ilosc { get; set; }
        public System.DateTime DataUtworzenia { get; set; }
    }
}
