namespace Surgeon__Day_Hospital_.DapperLibrary.ViewModels
{
    public class ViewPatient
    {
        // Patient_Records
        public string Patient_ID_no { get; set; }
        public string Patient_Name { get; set; }
        public string Patient_Surname { get; set; }
        public string Status { get; set; }

        // Admission_Records
        public int AdmissionID { get; set; }

        // Nurse_Records
        public int NurseID { get; set; }

        // Personnel_Records
        public int PersonnelID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        // Ward_Records
        public int WardID { get; set; }
        public string WardName { get; set; }

        // Beds
        public int BedID { get; set; }
        public int BedNumber { get; set; }

    }
}
