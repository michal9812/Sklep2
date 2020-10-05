using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SklepKomputerowy.Data.Data.Sklep
{
   public class Produkt
    {
        public Produkt()
        {
        }

        public Produkt(int idProduktu, string kod, string nazwa, decimal cena, string fotoURL, string opis, bool promocja, int idKategorii)
        {
            this.idProduktu = idProduktu;
            Kod = kod;
            Nazwa = nazwa;
            Cena = cena;
            FotoURL = fotoURL;
            Opis = opis;
            Promocja = promocja;
            this.idKategorii = idKategorii;
        }

        [Key]
      
        public int idProduktu { get; set; }
        [Required(ErrorMessage = "Kod Produktu jest wymagany")]
        public string Kod { get; set; }

        [Required(ErrorMessage = "Nazwa Produktu jest wymagana")]
        public string Nazwa { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Required(ErrorMessage = "Cena Produktu jest wymagana")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }

        [Required(ErrorMessage = "Zdjęcie  jest wymagane")]
        [Display(Name = "Wybierz zdjęcie")]
        public string FotoURL { get; set; }
        [Display(Name = "Opis Produktu")]
        public string Opis { get; set; }
        [Display(Name = "Czy ten produkt objęty jest Promocją")]
        public bool Promocja { get; set; }
        [Required(ErrorMessage = "Kategoria jest wymagana")]
        [Display(Name = "Wybierz Kategorię")]
        public int idKategorii { get; set; }
        public virtual  Kategoria Kategoria { get; set; }
        public virtual ICollection<Zdjecia> Zdjecia { get; set; }

    }
}
