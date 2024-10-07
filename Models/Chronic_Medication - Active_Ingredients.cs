using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Chronic_Medication___Active_Ingredients
    {
        [Key]
        public int Chronic_ActiveID { get; set; }

        [Required]
        [ForeignKey(nameof(ChronicMed))]
        public int ChronicID { get; set; }
        public Chronic_Medication ChronicMed { get; set; }

        [Required]
        [ForeignKey(nameof(ActiveIngredients))]
        public int ActiveID { get; set; }
        public virtual Active_Ingredients ActiveIngredients { get; set; }

        [Required]
        public string Strength { get; set; }
    }
}
