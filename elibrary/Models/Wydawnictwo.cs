using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace elibrary.Models
{
    public class Wydawnictwo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Zdjęcie wydawnictwa")]
        [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        public string WydPictureURL { get; set; }
        [Display(Name = "Nazwa wydawnictwa")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string NameWyd { get; set; }
        [Display(Name = "Notka o wydawnictwie")]
        [Required(ErrorMessage = "Notka jest wymagana")]
        public string DescWyd { get; set; }

        //Relacje
        [ValidateNever]
        public List<Ksiazka> Ksiazki { get; set; }    
    }
}
