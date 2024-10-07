using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Chronic_Patients
    {
        [Key]
        public int ChronicPatientID { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public string Patient_ID_no { get; set; }
        public virtual Patient_Records? Patient { get; set; }

        [Required]
        [ForeignKey(nameof(Condition))]
        public int ConditionID { get; set; }
        public virtual Chronic_Conditions? Condition { get; set; }
        
    }
}
