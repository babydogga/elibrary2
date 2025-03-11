using System.ComponentModel.DataAnnotations;

namespace elibrary.Models
{
    public class Wydawnictwo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string WydPictureURL { get; set; }
        [Display(Name = "Full Name")]
        public string NameWyd { get; set; }
        [Display(Name = "Biography")]
        public string DescWyd { get; set; }

        //Relacje
        public List<Ksiazka> Ksiazki { get; set; }    
    }
}
