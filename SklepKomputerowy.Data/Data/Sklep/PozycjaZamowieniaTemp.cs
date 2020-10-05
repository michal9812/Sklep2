using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SklepKomputerowy.Data.Data.Sklep
{
    public class PozycjaZamowieniaTemp
    {
        [Key]
        [Column("id")]
        public int IdPozycjaZamowieniaTemp { get; set; }
        public int Ilosc { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }
        public int idProduktu { get; set; }
        public virtual Produkt Produkt { get; set; }
        public int IdZamowienieTemp { get; set; }
        public virtual ZamowienieTemp ZamowienieTemp { get; set; }

    }
}