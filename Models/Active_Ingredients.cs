using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.Models
{
    public class Active_Ingredients
    {
        [Key]
        public int ActiveID { get; set; }

        [Required]
        public string Decription { get; set; }
    }
}
