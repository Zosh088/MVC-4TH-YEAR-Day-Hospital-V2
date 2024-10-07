using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Patient_Records
    {
        [Key]
        public string Patient_ID_no { get; set; }

        [Required]
        public string Patient_Name { get; set; }

        [Required]
        public string Patient_Surname { get; set; }

        [Required]
        public string Patient_Phone { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        //[Required]
        [ForeignKey(nameof(SuburbRecords))]
        public int? SuburbID { get; set; }
        public virtual Suburb_Records? SuburbRecords { get; set; }

        [Required]
        public string Patient_Gender { get; set; }

        //[Required]
        public DateOnly? Patient_DOB { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public string? Status { get; set; }
    }
}
