using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace elibrary.Models
{
    public class Biblioteka
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Zdjecie profilowe jest wymagane")]

        public string LogoBib { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Pełna nazwa jest wymagana")]
        public string NameBib { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string DescBib { get; set; }
 


        //relacje
        [ValidateNever]
        public List<Ksiazka> Ksiazki { get; set; }
    }
}
