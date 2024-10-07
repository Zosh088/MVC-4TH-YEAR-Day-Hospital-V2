using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Beds
    {
        [Key]
        public int BedID { get; set; }

        [Required]
        [ForeignKey(nameof(WardRecords))]
        public int WardID { get; set; }
        public virtual Ward_Records? WardRecords { get; set; }  
        
        [Required]
        public int BedNumber { get; set; }
    }
}
