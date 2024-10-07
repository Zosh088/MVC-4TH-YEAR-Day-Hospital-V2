using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Pharmacy_Medication
    {
        [Key]
        public int PharmacyID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Schedule { get; set; }

        [Required]
        [ForeignKey(nameof(DosageType))]
        public int DosageID { get; set; }
        public Dosage_Forms? DosageType { get; set; }

        [Required]
        public int ReOrder { get; set; }

        [Required]
        public int? Stock { get; set; }
    }
}
