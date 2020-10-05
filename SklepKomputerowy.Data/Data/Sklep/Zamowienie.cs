using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace SklepKomputerowy.Data.Data.Sklep
{
    public class Zamowienie
    {
        public Zamowienie()
        {
        }

        public Zamowienie(string login, string imie, string nazwisko, string ulica, string miasto, string numerDomu, string kodPocztowy, string numerTelefonu, string email, decimal razem, int? iDKraju, Kraj kraj)
        {
            Login = login;
            Imie = imie;
            Nazwisko = nazwisko;
            Ulica = ulica;
            Miasto = miasto;
            NumerDomu = numerDomu;
            KodPocztowy = kodPocztowy;
            NumerTelefonu = numerTelefonu;
            Email = email;
            Razem = razem;
            IDKraju = iDKraju;
            Kraj = kraj;
        }

        [Key]
        public int IdZamowienia { get; set; }
        public System.DateTime DataZamowienia { get; set; }
        public string Login { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane")]
        [Display(Name = "Imię")]
        [StringLength(160)]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        [StringLength(160)]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Ulica jest wymagana")]
        [StringLength(70)]
        public string Ulica { get; set; }
        [Required(ErrorMessage = "Miasto jest wymagane")]
        [StringLength(70)]
        public string Miasto { get; set; }
        [Required(ErrorMessage = "Wojewodztwo jest wymagane")]
        [StringLength(3)]
        [Display(Name = "Numer domu")]
        public string NumerDomu { get; set; }
        [Required(ErrorMessage = "Kod Pocztowy jest wymagany")]
        [Display(Name = "Kod Pocztowy")]
        [RegularExpression(@"[0-9]{2}\-[0-9]{3}", ErrorMessage = "Kod Pocztowy jest niepoprawny")]
        public string KodPocztowy { get; set; }
        [Required(ErrorMessage = "Numer jest wymagany  telefonu")]
        [StringLength(24)]
        [Display(Name = "Numer telefonu")]
        public string NumerTelefonu { get; set; }
        [Required(ErrorMessage = "Email jest wymagany")]
        [Display(Name = "Adres email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email nie jest prawidłowy.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Column(TypeName = "money")]
        public decimal Razem { get; set; }
        [Required(ErrorMessage = "Państwo jest wymagane")]
        [Display(Name = "Wybierz Kraj")]
        public int? IDKraju { get; set; }
        public virtual Kraj Kraj { get; set; }
        public virtual ICollection<PozycjaZamowienia> PozycjaZamowienia { get; set; }
    }
}
