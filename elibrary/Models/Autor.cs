using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace elibrary.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Zdjęcie profilowe")]
        [Required(ErrorMessage = "Zdjecie profilowe jest wymagane")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Imię i nazwisko")]
        [Required(ErrorMessage = "Pełne imię jest wymagane")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Imię i nazwisko powinno zawierać od 3 do 255 znaków")]
        public string FullName { get; set; }
        [Display(Name = "Biografia")]
        [Required(ErrorMessage = "Biografia jest wymagana")]
        
        public string Bio { get; set; }

        //relacje
        [ValidateNever]
        public List<Autor_Ksiazka> Autor_Ksiazki { get; set; }
    }
}

