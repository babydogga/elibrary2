using elibrary.Data.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace elibrary.Models
{
    public class Ksiazka
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tytuł książki")]
        [Required(ErrorMessage = "Pełna nazwa jest wymagana")]
        public string NameKs { get; set; }
        [Display(Name = "Opis książki")]
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string DescKs { get; set; }
        [Display(Name = "Okładka książki")]
        [Required(ErrorMessage = "Okładka jest wymagana")]
        public string ImageURL { get; set; }
        [Display(Name = "Publikacja książki")]
        [Required(ErrorMessage = "Publikacja jest wymagana")]
        public DateTime PublikacjaTime { get; set; }
        [Display(Name = "Kategoria książki")]
        [Required(ErrorMessage = "Kategoria jest wymagana")]
        public KsiazkaCategory ksiazkaCategory { get; set; }

        //relacje
        public List<Autor_Ksiazka> Autor_Ksiazki { get; set; }
        //wydawnictwo

        [ValidateNever]
        [Display(Name = "Wydawnictwo książki")]
        [Required(ErrorMessage = "Wydawnictwo jest wymagane")]
        public int WydId { get; set; }
        [ForeignKey("WydId")]
        
        public Wydawnictwo Wydawnictwa { get; set; }
        //autor

        [ValidateNever]
        [Display(Name = "Biblioteka książki")]
        [Required(ErrorMessage = "Biblioteka jest wymagana")]
        public int BibId { get; set; }
        [ForeignKey("BibId")]
        public Biblioteka Biblioteki  { get; set; }    


       
    }
}
