using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surgeon__Day_Hospital_.Models
{
    public class MedOrder_ActiveIngredients
    {
        [Key]
        public int MedOrderActiveID { get; set; }

        [ForeignKey(nameof(MedOrder))]
        public int OrderID { get; set; }
        public virtual MedOrder_Record MedOrder { get; set; }
    }
}
