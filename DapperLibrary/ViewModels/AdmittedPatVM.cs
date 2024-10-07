using System.Xml.XPath;

namespace Surgeon__Day_Hospital_.DapperLibrary.ViewModels
{
    public class AdmittedPatVM
    {
        public string PatName { get; set; }
        public string NurName { get; set; }
        public string Ward { get; set; }
        public int Bed { get; set; }
        public TimeOnly AdmTime { get; set; }
        public int Id { get; set; } 

    }
}
