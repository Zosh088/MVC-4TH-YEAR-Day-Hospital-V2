using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.Models
{
    public class Theatre_Records
    {
        [Key]
        public int TheatreID { get; set; }

        [Required]
        public string TheatreName { get; set; }
    }
}
