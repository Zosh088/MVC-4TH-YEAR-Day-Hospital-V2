using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Chronic_Medication // please delete it.. its useless
    {
        [Key]
        public int Chronic_ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Schedule { get; set; }

        [Required]
        [ForeignKey(nameof(DosageType))]
        public int DosageID { get; set; }
        public Dosage_Forms? DosageType { get; set; }
    }
    public class Patient_Current_Medication
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public string Patient_ID_No { get; set; }
        public Patient_Records? Patient { get; set; }

        [Required]
        [ForeignKey(nameof(Medication))]
        public int MedicationID { get; set; }
        public Pharmacy_Medication? Medication { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
    
}
