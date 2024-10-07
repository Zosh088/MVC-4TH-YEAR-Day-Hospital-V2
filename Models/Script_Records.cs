using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Script_Records
    {
        [Key]
        public int ScriptID { get; set; }

        public string Status { get; set; } = "Prescribed";
        public string? RejectReason { get; set; }

        [Required]
        [ForeignKey(nameof(Users))]
        public string SurgeonID { get; set; }
        public virtual User? Users { get; set; } //surgeon

        [ForeignKey(nameof(Pharmacist))]
        public string? PharmacistID { get; set; }
        public virtual User? Pharmacist { get; set; } 

        [ForeignKey(nameof(Nurse))]

        public string? NurseID { get; set; }
        public virtual User? Nurse { get; set; }
        [Required]
        public DateOnly DateIssued { get; set; }

        [Required]
        public TimeSpan TimeIssued { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public string Patient_ID_no { get; set; }
        public virtual Patient_Records? Patient { get; set; }

        [Required]
        public bool Urgent { get; set; } //urgent scripts
    }
}
