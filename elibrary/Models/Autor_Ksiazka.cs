using System.ComponentModel.DataAnnotations.Schema;

namespace elibrary.Models
{
    public class Autor_Ksiazka
    {
        public int KsiazkaId { get; set; }
        [ForeignKey("KsiazkaId")]

        public Ksiazka Ksiazki { get; set; }

        public int AutorId { get; set; }
        [ForeignKey("AutorId")]

        public Autor Autorzy { get; set; }
    }
}
