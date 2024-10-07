using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.Models
{
    public class Supplier_Record
    {
        [Key]
        public int SupplierID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
