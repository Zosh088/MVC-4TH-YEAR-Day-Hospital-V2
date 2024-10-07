using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Admission_Records
    {
        [Key]
        public int Admission_ID { get; set; }
        [Required]
        [ForeignKey(nameof(Patient))]
        public string Patient_ID_no { get; set; }
        public virtual Patient_Records? Patient { get; set; }
        [Required]
        public DateOnly AdmissionDate { get; set; }
        [Required]
        public TimeOnly AdmissionTime { get; set; }
        [Required]
        [ForeignKey(nameof(Beds))]
        public int BedID { get; set; }
        public virtual Beds? Beds { get; set; }

        //[Required]
        [ForeignKey(nameof(Bookings))]
        public int BookingID { get; set; }
        public virtual Theatre_Bookings? Bookings { get; set; }

        [Required]
        [ForeignKey(nameof(Nurse))]
        public string Nurse_ID { get; set; }
        public virtual User? Nurse { get; set; }

    }
}
