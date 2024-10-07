using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.Models
{
    public class Admin_Records
    {
        [Key]
        public int Admin_ID { get; set; }

        [Required(ErrorMessage = "Admin Personnel no. is required")]
        public string Personnel_no { get; set; }

        [Required]
        public string Id { get; set; }
    }
}
