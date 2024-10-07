using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.Models
{
    public class Dosage_Forms
    {
        [Key]
        public int DosageID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
