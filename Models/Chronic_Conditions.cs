using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Chronic_Conditions
    {
        [Key]
        public int ConditionID { get; set; }

        [Required]
        public string ICD10Code { get; set; }

        [Required]
        public string Diagnosis { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public string? Patient_ID_no { get; set; } // please use the chronic patient model.. this model is to add conditions to the system not to link a patient to a condition
        public virtual Patient_Records? Patient { get; set; } // when done delete this whole block
    }
}
