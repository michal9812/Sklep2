using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SklepKomputerowy.Data.Data.Sklep
{
    public class PozycjaZamowienia
    {
        public PozycjaZamowienia()
        {
        }

        public PozycjaZamowienia(int ilosc, decimal cena, int idProduktu, Produkt produkt, int idZamowienia, Zamowienie zamowienie)
        {
            Ilosc = ilosc;
            Cena = cena;
            this.idProduktu = idProduktu;
            Produkt = produkt;
            IdZamowienia = idZamowienia;
            Zamowienie = zamowienie;
        }

        [Key]
        public int IdPozycjiZamowienia { get; set; }
        public int Ilosc { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }
        public int idProduktu { get; set; }
        public virtual Produkt Produkt { get; set; }
        public int IdZamowienia { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }

        public static implicit operator PozycjaZamowienia(List<PozycjaZamowieniaTemp> v)
        {
            throw new NotImplementedException();
        }
    }
}