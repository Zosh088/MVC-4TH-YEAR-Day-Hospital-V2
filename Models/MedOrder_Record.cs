using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class MedOrder_Record
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey(nameof(Pharmacy))]
        public int PharmacyID { get; set; }
        public virtual Pharmacy_Medication Pharmacy { get; set; }

        [Required]
        public string PackageType { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey(nameof(Pharmacist))]
        public string PharmacistID { get; set; }
        public virtual User? Pharmacist { get; set; }

        [Required]
        public DateOnly DateOrdered { get; set; }

        [Required]
        [ForeignKey(nameof(PurchaseManagers))]
        public int MangerID { get; set; }
        public virtual PurchaseManager? PurchaseManagers { get; set; }


    }
    public class PurchaseManager
    {
        [Key]
        public int SupplierID { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
