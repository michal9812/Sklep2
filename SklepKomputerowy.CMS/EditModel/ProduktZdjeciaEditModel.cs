using Microsoft.EntityFrameworkCore;
using SklepKomputerowy.Data.Data;
using SklepKomputerowy.Data.Data.Sklep;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace SklepKomputerowy.CMS.EditModel
{
    public class ProduktZdjeciaEditModel
    {
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
        public int idKategorii { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idZdjecia { get; set; }
        public string ZdjecieURL { get; set; }
   
        public int idProduktuFK { get; private set; }
    }
}