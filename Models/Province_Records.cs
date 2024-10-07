using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.Models
{
    public class Province_Records
    {
        [Key]
        public int ProvinceID { get; set; }

        [Required]
        public string ProvinceName { get; set; }
    }
}
