using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class Order_Record
    {
        public int OrderID { get; set; }

        [ForeignKey(nameof(Pharmacist))]
        public int PharmacistID { get; set; }
        public virtual User? Pharmacist { get; set; }

        public DateOnly DateOfOrder { get; set; }
    }
}
