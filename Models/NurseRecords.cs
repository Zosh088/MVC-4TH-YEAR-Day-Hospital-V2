using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.Models
{
    public class NurseRecords
    {
        [Key]
        public string PatientRecordID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Surgeon {  get; set; }

        [Required]
        public string Activity {  get; set; }

        [Required]
        public string PatientID { get; set; }
    }
}
