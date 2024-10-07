using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Bed_Records
    {
        [Key]
        public int BedRecordID { get; set; }

        [Required]
        [ForeignKey(nameof(Bed))]
        public int Bed_ID { get; set; }
        public virtual Beds Bed { get; set; }

        [Required]
        public DateOnly Day_of_Use { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public string Patient_ID_no { get; set; }
        public virtual Patient_Records Patient { get; set; }
    }
}
