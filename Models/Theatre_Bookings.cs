using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Theatre_Bookings
    {
        [Key]
        public int TheatreBookingID { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public string SurgeonID { get; set; }
        public virtual User? User { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public string Session  { get; set; }
        [Required]
        [ForeignKey(nameof(Theatre))]
        public int TheatreID { get; set; }
        public virtual Theatre_Records? Theatre { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public string Patient_ID_no { get; set; }
        public virtual Patient_Records? Patient { get; set; }
        public string Status { get; set; } = "Booked";
    }
}
