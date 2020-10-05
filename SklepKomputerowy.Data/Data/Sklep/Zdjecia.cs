using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SklepKomputerowy.Data.Data.Sklep
{
    public class Zdjecia
    {
        public Zdjecia()
        {
        }

        public Zdjecia(int idZdjecia, string zdjecieURL, int idProduktu)
        {
            this.idZdjecia = idZdjecia;
            ZdjecieURL = zdjecieURL;
            this.idProduktu = idProduktu;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idZdjecia { get; set; }
      
        public string ZdjecieURL  { get; set; }
        
        public virtual Produkt Produkt { get; set; }
        [ForeignKey("idProduktu")]
        public int idProduktu { get; set; }
    }
}
