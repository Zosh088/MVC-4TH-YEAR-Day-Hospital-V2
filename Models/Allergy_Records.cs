using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Allergy_Records
    {
        [Key]
        public int AllergyID { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public string Patient_ID_no { get; set; }
        public virtual Patient_Records? Patient { get; set; }

        [Required]
        [ForeignKey(nameof(ActiveIngredients))]
        public int ActiveID { get; set; }
        public virtual Active_Ingredients? ActiveIngredients { get; set; }
    }
}
