using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Script_Lines
    {
        [Key]
        public int ScriptLineID { get; set; }

        [Required]
        [ForeignKey(nameof(Pharmacy))]
        public int PharmacyID { get; set; }
        public virtual Pharmacy_Medication? Pharmacy { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        [ForeignKey(nameof(ScriptRecords))]
        public int ScriptID { get; set; }
        public virtual Script_Records? ScriptRecords { get; set; }
    }
}
