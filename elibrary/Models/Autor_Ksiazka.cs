using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace elibrary.Models
{
    public class Autor_Ksiazka
    {
        public int KsiazkaId { get; set; }
        [ForeignKey("KsiazkaId")]
        [ValidateNever]
        public Ksiazka Ksiazki { get; set; }

        public int AutorId { get; set; }
        [ForeignKey("AutorId")]
        [ValidateNever]
        public Autor Autorzy { get; set; }
    }
}
