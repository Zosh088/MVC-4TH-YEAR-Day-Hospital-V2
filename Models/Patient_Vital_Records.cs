using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Patient_Vital_Records
    {
        [Key]
        public int pVitalID { get; set; }

        [Required]
        [ForeignKey(nameof(Vitals))]
        public int VitalID { get; set; }
        public virtual Vital_Records? Vitals { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public string Patient_ID_no { get; set; }
        public virtual Patient_Records? Patient { get; set; }
    }
}
