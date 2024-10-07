using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.Models
{
    public class Nurse_Records
    {
        [Key]
        public int NurseID { get; set; }
        [Required]
        public int PersonnelID { get; set; }
        [Required]
        public string Id { get; set; }
    }
}
