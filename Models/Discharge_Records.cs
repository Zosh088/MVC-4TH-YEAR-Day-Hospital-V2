using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Discharge_Records
    {
        [Key]
        public int DischargeID { get; set; }

        [Required]
        public DateTime DischargeDate { get; set; }

        
        [ForeignKey(nameof(Patient_Records))]
        public string Patient_ID_no { get; set; }
        public virtual Patient_Records? Patient_Records { get; set; }

        [ForeignKey(nameof(Nurse))]
        public string NurseID { get; set; }
        public virtual User? Nurse { get; set; }

        [NotMapped]
        [Required]
        public int Book {  get; set; }
        [StringLength(255)]
        public string Notes { get; set; }
    }
}
