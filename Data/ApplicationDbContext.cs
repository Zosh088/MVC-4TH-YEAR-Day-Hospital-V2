using Surgeon__Day_Hospital_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Surgeon__Day_Hospital_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Add DbSet properties for your tables here ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------->
        public DbSet<Active_Ingredients> Active_Ingredients { get; set; }
        public DbSet<PurchaseManager> PurchaseManagers  { get; set; }
        public DbSet<Patient_Current_Medication> Patient_Current_Medications  { get; set; }
        public DbSet<Admin_Records> Admin_Records { get; set; }
        public DbSet<Admission_Records> Admission_Records { get; set; }
        public DbSet<Booking_Codes> Booking_Codes { get; set; }
        public DbSet<Chronic_Conditions> Chronic_Conditions { get; set; }
        public DbSet<Chronic_Medication> Chronic_Medications { get; set; }
        public DbSet<Chronic_Medication___Active_Ingredients> Chronic_Medication__Active_Ingredients { get; set; } //Chronic_Medication___Active_Ingredients>
        public DbSet<City_Records> City_Records { get; set; }
        public DbSet<Contra_Indications> Contra_Indications { get; set; }
        public DbSet<Day_Hospital_Records> Hospital_Records { get; set; } //Hospital_Records>
        public DbSet<Discharge_Records> Discharge_Records { get; set; }
        public DbSet<Dosage_Forms> Dosage_Forms { get; set; }
        public DbSet<Medication_Interactions> Medication_Interactions { get; set; }
        public DbSet<Nurse_Records> Nurse_Records { get; set; } //Nurse_Records>
        public DbSet<Patient_Records> Patient_Records { get; set; } //Patient_Records>
        public DbSet<Patient_Vital_Records> Patient_Vitals { get; set; }
        public DbSet<Personnel_Records> Personnel_Records { get; set; } //Personnel_Records>
        public DbSet<Pharmacist_Records> Pharmacist_Records { get; set; }
        public DbSet<Pharmacy_Medication> Pharmacy_Medication { get; set; }
        public DbSet<Pharmacy_Medication___Active_Ingredients> Pharmacy_Medication__Active_Ingredients { get; set; } //Pharmacy_Medication___Active_Ingredients>
        public DbSet<Province_Records> Province_Records { get; set; }
        public DbSet<Script_Lines> Script_Lines { get; set; }
        public DbSet<Script_Records> Script_Records { get; set; } //Script_Records>
        public DbSet<Suburb_Records> Suburb_Records { get; set; }
        public DbSet<Theatre_Bookings> Theatre_Bookings { get; set; }
        public DbSet<Theatre_Records> Theatre_Records { get; set; } //Theatre_Records>
        public DbSet<Treatment_Codes> Treatment_Codes { get; set; }
        public DbSet<Vital_Records> Vital_Records { get; set; }
        public DbSet<Vital_Types> Vital_Types { get; set; }
        public DbSet<Ward_Records> Ward_Records { get; set; } //Ward_Records>
        public DbSet<Address_Book> Address_Book { get; set; } //Address_Book>
        public DbSet<Bed_Records> Bed_Records { get; set; } //Bed_Records>
        public DbSet<Beds> Beds { get; set; } //Beds>
        public DbSet<Allergy_Records> Allergy_Records { get; set; } //Allergy_Records>
        public DbSet<Chronic_Patients> Chronic_Patients { get; set; } //Chronic_Patients>
        public DbSet<NurseRecords> nurseRecords { get; set; }
        public DbSet<User> Userss  { get; set; }
        public DbSet<MedOrder_Record> MedOrder_Records { get; set; } //MedOrder_Records>
    }
}
