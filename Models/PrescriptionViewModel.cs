namespace Surgeon__Day_Hospital_.Models
{
    public class PrescriptionViewModel
    {

        public string Instructions { get; set; }
        public string Description { get; set; }
        public string Strength { get; set; }
        public string Quantity { get; set; }
        public string Repeat { get; set; } // This can be hardcoded as "None"
    }
}
