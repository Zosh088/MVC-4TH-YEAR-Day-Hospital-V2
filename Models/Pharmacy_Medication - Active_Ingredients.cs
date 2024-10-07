using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Pharmacy_Medication___Active_Ingredients
    {
        [Key]
        public int Pharmacy_ActiveID { get; set; }

        [Required]
        [ForeignKey(nameof(Pharmacy))]
        public int PharmacyID { get; set; }
        public virtual Pharmacy_Medication? Pharmacy { get; set; }

        [Required]
        [ForeignKey(nameof(ActiveIngredients))]
        public int ActiveID { get; set; }
        public virtual Active_Ingredients? ActiveIngredients { get; set; }

        [Required]
        public string Strength { get; set; }
    }
}
