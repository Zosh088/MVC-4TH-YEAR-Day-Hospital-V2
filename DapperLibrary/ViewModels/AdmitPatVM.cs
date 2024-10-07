using Surgeon__Day_Hospital_.Models;
using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.DapperLibrary.ViewModels
{
    public class AdmitPatVM
    {
        public Patient_Records? Patient_Records { get; set; }
        public Beds? Beds { get; set; }
        public User? Surgeon { get; set; }
        [Required]
        public DateTime? AdmitDate { get; set; }
        public int BookId { get; set; }
        public IEnumerable<int> Allergies { get; set; }
        
        public IEnumerable<int> Contra { get; set; } 
        public IEnumerable<int> Meds { get; set; }
        public IEnumerable<Vital_Types> Vital_Types  { get; set; }

    }
}
