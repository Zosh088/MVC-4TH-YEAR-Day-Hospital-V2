using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.Models
{
    public class Ward_Records
    {
        [Key]
        public int WardID { get; set; }

        [Required]
        public string WardName { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
}
