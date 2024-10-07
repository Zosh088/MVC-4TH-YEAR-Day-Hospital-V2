using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Address_Book
    {
        [Key]
        public int AddressID { get; set; }

        [Required]
        public string StreetName { get; set; }

        public int? CityID { get; set; }

        public int? ProvinceID { get; set; }

        [Required]
        [ForeignKey(nameof(Suburb))]
        public int SuburbID { get; set; }
        public virtual Suburb_Records? Suburb { get; set; }
    }
}
