using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Suburb_Records
    {
        [Key]
        public int SuburbID { get; set; }

        [Required]
        public string SuburbName { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        [ForeignKey(nameof(City))]
        public int CityID { get; set; }
        public virtual City_Records? City { get; set; }
    }
}
