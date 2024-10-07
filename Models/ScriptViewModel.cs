namespace Surgeon__Day_Hospital_.Models
{
    
    public class ScriptViewModel
    {
        public int ScriptID { get; set; }
        public DateOnly DateIssued { get; set; }
        public string Status { get; set; }
        public string PatientName { get; set; }
        public string SurgeonName { get; set; } 
        public string SurgeonSurname { get; set; }
        public string NurseAdminister { get; set; }
        public string NurseSurname { get; set; }

        public bool Urgent  { get; set; }

        public string PatientID { get; set; }
        public string PatientSurname { get; set; }
        public string PatientPhone { get; set; }
        public string PatientGender { get; set; }
        public DateOnly PatientDOB { get; set; }
        public string PatientEmail { get; set; }
        public Patient_Records Patient {  get; set; }
        public string PrescriptionDescription { get; set; }
        public string PrescriptionQuantity { get; set; }
        public string PrescriptionType { get; set; }

        public List<PrescriptionViewModel> Prescriptions { get; set; }

        public IEnumerable<Script_Lines> Meds { get; set; }
        public IEnumerable<Allergy_Records> Allergy  { get; set; }
        public IEnumerable<Patient_Current_Medication> CurrentMeds  { get; set; }
        public IEnumerable<Chronic_Patients> Chronics { get; set; }
        public IEnumerable<Vital_Records> Vitals { get; set; }
        

        // Medical History
      
        public List<string> ChronicConditions { get; set; }
        public List<string> CurrentMedications { get; set; }
        public List<string> Allergies { get; set; }
        public DateOnly LastRecordedDate { get; set; }

        // Vitals
        public string ICD10Code { get; set; }
        public string HeartRate { get; set; }
        public string BloodPressure { get; set; }
        public string BodyTemperature { get; set; }
        
        public TimeOnly RecordedTime { get; set; }

        public List<VitalDataViewModel> VitalsData { get; set; } // New property
    }

    public class VitalDataViewModel
    {
        public string ICD10Code { get; set; }
        public string HeartRate { get; set; }
        public string BloodPressure { get; set; }
        public string Temperature { get; set; }
        public TimeOnly TimeRecorded { get; set; }
    }

}
