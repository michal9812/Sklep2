
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SklepKomputerowy.Data.Data.Sklep
{
  public class Kategoria
    {
        [Key]
      
        public int IdKategorii { get; set; }
        [Required(ErrorMessage = "Podaj nazwę kategorii")]
        [MaxLength(30, ErrorMessage = "Nazwa kategori powinna mieć max 30 znaków")]
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public virtual ICollection<Produkt> Produkt { get; set; }
        

    }
}
