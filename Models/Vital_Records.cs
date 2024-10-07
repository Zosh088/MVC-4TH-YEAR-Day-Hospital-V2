using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Vital_Records
    {
        [Key]
        public int VitalID { get; set; }

        public double Value { get; set; }

        public double? Value2 { get; set; }

        [Required]
        [ForeignKey(nameof(Patient_Records))]
        public string Patient_ID_no { get; set; }
        public virtual Patient_Records Patient_Records { get; set; }

        [Required]
        [ForeignKey(nameof(VitalT))]
        public int Vital { get; set; }
        public virtual Vital_Types VitalT { get; set; }

        public DateOnly VitalDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public TimeOnly VitalTime { get; set; } = TimeOnly.FromDateTime(DateTime.Now);
    }
}
