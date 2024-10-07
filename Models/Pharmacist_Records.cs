using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.Models
{
    public class Pharmacist_Records
    {
        [Key]
        public int PharmacistID { get; set; }
        [Required]
        public int PersonnelID { get; set; }
        [Required]
        public string Id { get; set; }
    }
}
