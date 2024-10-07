using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Booking_Codes
    {
        [Key]
        public int Booking_Code_ID { get; set; }

        [Required]
        [ForeignKey(nameof(Treatment_))]
        public int TreatmentCodeID { get; set; }
        public virtual Treatment_Codes? Treatment_ { get; set; }

        [Required]
        [ForeignKey(nameof(Theatre_Bookings))]
        public int TheatreBookingID { get; set; }
        public virtual Theatre_Bookings? Theatre_Bookings { get; set; }
    }
}
