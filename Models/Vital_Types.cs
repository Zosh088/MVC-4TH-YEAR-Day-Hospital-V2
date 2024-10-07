using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.Models
{
    public class Vital_Types
    {
        [Key]
        public int VitalTypeID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double LowLimit { get; set; }

        [Required]
        public double HighLimit { get; set; }

        public string? Name2 { get; set; }
        
        public string? LowLimit2 { get; set; }
        
        public string? HighLimit2 { get; set; }

    }
}
