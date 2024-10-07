using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Contra_Indications
    {
        [Key]
        public int ContraID { get; set; }

        [Required]
        [ForeignKey(nameof(ActiveIngredient))]
        public int ActiveID { get; set; }
        public Active_Ingredients? ActiveIngredient { get; set; }

        [Required]
        [ForeignKey(nameof(Condition))]
        public int ConditionID { get; set; }
        public Chronic_Conditions? Condition { get; set; }
    }
}
