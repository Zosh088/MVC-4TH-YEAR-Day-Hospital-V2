using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class City_Records
    {
        [Key]
        public int CityID { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        [ForeignKey(nameof(Province))]
        public int ProvinceID { get; set; }
        public virtual Province_Records? Province { get; set; }
    }
}
