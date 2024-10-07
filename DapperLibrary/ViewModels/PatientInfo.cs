using Surgeon__Day_Hospital_.Models;

namespace Surgeon__Day_Hospital_.DapperLibrary.ViewModels
{
    public class PatientInfo
    {
        public Patient_Records? Patient_Records { get; set; }
        public IEnumerable<Vital_Records> Vital_Records { get; set; }
    }
}
