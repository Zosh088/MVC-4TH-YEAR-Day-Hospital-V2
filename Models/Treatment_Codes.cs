using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.Models
{
    public class Treatment_Codes
    {
        [Key]
        public int TreatmentCodeID { get; set; }

        [Required]
        public string ICD10Code { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
