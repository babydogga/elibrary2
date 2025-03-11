using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace elibrary.Models
{
    public class Biblioteka
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string LogoBib { get; set; }
        [Display(Name = "Full Name")]
        public string NameBib { get; set; }
        [Display(Name = "Biography")]
        public string DescBib { get; set; }

        //relacje
        [ValidateNever]
        public List<Ksiazka> Ksiazki { get; set; }
    }
}
