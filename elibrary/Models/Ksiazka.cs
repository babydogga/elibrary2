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
        public string NameKs { get; set; }
        public string DescKs { get; set; }
        public string ImageURL { get; set; }
        public DateTime PublikacjaTime { get; set; }
        public KsiazkaCategory ksiazkaCategory { get; set; }

        //relacje
       
        public List<Autor_Ksiazka> Autor_Ksiazki { get; set; } 
        //wydawnictwo
        public int WydId { get; set; }
        [ForeignKey("WydId")]
        [ValidateNever]
        public Wydawnictwo Wydawnictwa { get; set; }    
        //autor

        public int BibId { get; set; }
        [ForeignKey("BibId")]
        [ValidateNever]
        public Biblioteka Biblioteki  { get; set; }    


       
    }
}
