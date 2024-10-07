using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Medication_Interactions
    {
        [Key]
        public int InteractionID { get; set; }

        [Required]
        [ForeignKey(nameof(ActiveIngre01))]
        public int ActiveID1 { get; set; }
        public virtual Active_Ingredients? ActiveIngre01 { get; set; }

        [Required]
        [ForeignKey(nameof(ActiveIngre02))]
        public int ActiveID2 { get; set; }
        public virtual Active_Ingredients? ActiveIngre02 { get; set; }

        [Required]
        public string? Description { get; set; }

    }
}
