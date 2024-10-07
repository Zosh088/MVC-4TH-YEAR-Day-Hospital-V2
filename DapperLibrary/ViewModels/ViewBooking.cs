namespace Surgeon__Day_Hospital_.DapperLibrary.ViewModels
{
    public class ViewBooking
    {
        // Theatre_Bookings
        public int TheatreBookingID { get; set; }
        public DateOnly Date { get; set; }
        public string Session {  get; set; }

        // Surgeon_Records
        public int SurgeonID { get; set; }
        public int PersonnelID { get; set; }

        //Theatre_Records
        public int TheatreID { get; set; }
        public string TheatreName {  get; set; }

        // Patient_Records
        public int PatientID { get; set; }
        public string PatientName {  get; set; }
    }
}
