using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Day_Hospital_Records
    {
        [Key]
        public int HospitalID { get; set; }

        [Required]
        public string HospitalName { get; set; }

        [Required]
        [ForeignKey(nameof(Address))]
        public int AddressID { get; set; }
        public virtual Address_Book? Address { get; set; }

        [Required]
        public string ContactNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PracticeManager { get; set; }

        [Required]
        public string PracticeManagerEmail { get; set; }
    }
}
