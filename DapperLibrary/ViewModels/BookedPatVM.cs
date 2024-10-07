namespace Surgeon__Day_Hospital_.DapperLibrary.ViewModels
{
    public class BookedPatVM
    {
        public string PatName { get; set; }
        public string SurgName { get; set; }
        public string Theater { get; set; }
        public string Session { get; set; }
        public string IdNo { get; set; }
        public int id{ get; set; }
        public DateOnly BookDate { get; set; }
    }
}
