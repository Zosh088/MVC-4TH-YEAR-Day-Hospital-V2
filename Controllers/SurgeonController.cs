using Microsoft.AspNetCore.Mvc;
using Surgeon__Day_Hospital_.Data;
using Surgeon__Day_Hospital_.Models;
using Dapper;
using Surgeon__Day_Hospital_.DapperLibrary.Repositories.AddressRepo;
using Microsoft.EntityFrameworkCore;
using Surgeon__Day_Hospital_.DapperLibrary.ViewModels;
using Surgeon__Day_Hospital_.Helpers;
using System.Threading.Tasks.Dataflow;
using Microsoft.CodeAnalysis.Scripting;

namespace Surgeon__Day_Hospital_.Controllers
{
    public class SurgeonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private AddressRepo _addressRepo;

        public SurgeonController(AddressRepo addressRepo, ApplicationDbContext context)
        {
            _addressRepo = addressRepo;
            _context = context;
        }

        //public SurgeonController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //------------------------------------------------------------------------------- Address Table for Admin Functionality ------------------------------------------------------------------------
        public IActionResult Address_Book()
        {
            ViewBag.ViewAddress = _addressRepo.GetAddress("GetAddress",null,System.Data.CommandType.StoredProcedure);
            return View();
        }
        [HttpGet]
        public IActionResult AddAddress()
        {
            ViewBag.Suburb_Records = _addressRepo.GetAddress("GetSuburb", null, System.Data.CommandType.StoredProcedure);
            ViewBag.City_Records = _addressRepo.GetAddress("GetCity", null, System.Data.CommandType.StoredProcedure);
            ViewBag.Province_Records = _addressRepo.GetAddress("GetProvince", null, System.Data.CommandType.StoredProcedure);
            return View();
        }
        [HttpPost]
        public IActionResult AddAddress(Address_Book address)
        {
            if (ModelState.IsValid)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@streetName", address.StreetName);
                parameters.Add("@suburbID", address.SuburbID);
                parameters.Add("@cityID", address.CityID);
                parameters.Add("@provinceID", address.ProvinceID);
                _addressRepo.IUDAddress("InsertAddress", parameters, System.Data.CommandType.StoredProcedure);
                return RedirectToAction("Address_Book");
            }
            return View(address);
        }
        [HttpGet]
        public IActionResult UpdateAddress(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            var address = _addressRepo.GetAddressById("GetAddressById", parameters, System.Data.CommandType.StoredProcedure);
            return View(address);
        }
        [HttpPost]
        public IActionResult UpdateAddress(Address_Book address) 
        {
            if (ModelState.IsValid)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", address.AddressID);
                parameters.Add("@streetName", address.StreetName);
                parameters.Add("@suburbID", address.SuburbID);
                parameters.Add("@cityID", address.CityID);
                parameters.Add("@provinceID", address.ProvinceID);
                _addressRepo.IUDAddress("UpdateAddress", parameters, System.Data.CommandType.StoredProcedure);
                return RedirectToAction("Address_Book");
            }
            return View(address);
        }
        [HttpGet]
        public IActionResult DeleteAddress(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            _addressRepo.IUDAddress("DeleteAddress", parameters, System.Data.CommandType.StoredProcedure);
            return RedirectToAction("Address_Book");
        }
        //-------------------------------------------------------------------------------------------------  End of Address Table for Admin Functionality ---------------------------------------------------------------------------------------------
        // Password123!
        //----------------------------------------------------------------------------------------- Patient CRUD Operations ---------------------------------------------------------------------------------------------------------------------------
        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(Patient_Records patient)
        {
            if (ModelState.IsValid) {
                _context.Patient_Records.Add(patient);
                _context.SaveChanges();
                return RedirectToAction("AddBooking", new { Patient = patient.Patient_ID_no });
            }
            ViewBag.PatientID = patient.Patient_ID_no;
            return View(patient);
        }

        //public IActionResult UpdatePatient(string Patient)
        //{
        //    var patient = _context.Patient_Records.Where(x => x.Patient_ID_no == Patient).FirstOrDefault();
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Patient);
        //}
        //[HttpPost]
        //public IActionResult UpdatePatient(Patient_Records patient)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Patient_Records.Update(patient);
        //        _context.SaveChanges();
        //        return RedirectToAction("PatientRecords");
        //    }
        //    return View(patient);
        //}
        //--------------------------------------------------------------------------------------------------------------- END ---------------------------------------------------------------------------------------------------------------------

        //------------------------------------------------------------------------------------------------ Adding a Booking straight from the AddPatient Page --------------------------------------------------------------------------------------
        public IActionResult ViewBookings()
        {
            //TempData["SuccessMessage"] = "Treatment Codes added successfully!";
            var record = _context.Theatre_Bookings.Include(c => c.User).Include(c => c.Theatre).Where(x => x.Status == "Booked").AsEnumerable();
            var pat = _context.Patient_Records;
            var x = (from r in record
                     join p in pat on r.Patient_ID_no equals p.Patient_ID_no
                     select new BookedPatVM
                     {
                         Session = r.Session,
                         IdNo = r.Patient_ID_no,
                         PatName = $"{p.Patient_Name} {p.Patient_Surname}",
                         Theater = r.Theatre.TheatreName,
                         SurgName = r.User.Name,
                         id = r.TheatreBookingID,
                         BookDate = r.Date
                     }).AsEnumerable();
            return View(x);
        }

        // This is where we add a booking. ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public IActionResult AddBooking(string? Patient)
        {
            Theatre_Bookings booking = new Theatre_Bookings();
            Patient_Records patient = new Patient_Records();

            if (!string.IsNullOrEmpty(Patient))
            {
                ViewBag.Patient = _context.Patient_Records.Where(x => x.Patient_ID_no == Patient).FirstOrDefault();
                TempData["SuccessMessage"] = "Patient added successfully!";
            }
            ViewBag.Theatre = _context.Theatre_Records.ToList();
            var allPatients = _context.Patient_Records.ToList();
            // this is were we filter out who has a booking and who does not.
            var filteredPats = allPatients.Where(p => p.Patient_ID_no != booking.Patient_ID_no).ToList();
            // Set the ViewBag.AllPatients to the filtered list of patient records.
            ViewBag.AllPatients = filteredPats;
            return View();
        }
        [HttpPost]
        public IActionResult AddBooking(Theatre_Bookings booking, string? Patient)
        {
            if (!string.IsNullOrEmpty(Patient))
            {
                ViewBag.Patient = _context.Patient_Records.Where(x => x.Patient_ID_no == Patient).FirstOrDefault();
            }

            if (ModelState.IsValid)
            {
                _context.Theatre_Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("AddTreatCodes", new { Booking = booking.TheatreBookingID });
            }
            return View(booking);
        }

        // This is where we plan to add Treatment Codes to the Booking. ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // In-memory temp list (use session or a more permanent store in production)
        private static List<Booking_Codes> tempTreatmentCodes = new List<Booking_Codes>();

        // GET: /Surgeon/AddTreatCodes
        public IActionResult AddTreatCodes(int? booking)
        {
            // Ensure a list of bookings is available for selection
            ViewBag.Bookings = _context.Theatre_Bookings.ToList();
            ViewBag.TCodes = _context.Treatment_Codes.ToList();

            if (booking != null && booking != 0)
            {
                TempData["SuccessMessage"] = "Booking added successfully!";
                // Fetch the selected booking
                ViewBag.Booking = _context.Theatre_Bookings.FirstOrDefault(x => x.TheatreBookingID == booking);

                // Fetch the treatment codes already tied to the booking
                var existingTreatmentCodes = _context.Booking_Codes
                    .Where(x => x.TheatreBookingID == booking)
                    .Include(x => x.Treatment_) // Include related Treatment_ entity
                    .ToList();
                ViewBag.ExistingTreatmentCodes = existingTreatmentCodes;

                // Display any treatment codes in the temporary list (if any)
                var tempTreatmentCodes = HttpContext.Session.GetObjectFromJson<List<Booking_Codes>>("TempTreatmentCodes") ?? new List<Booking_Codes>();
                ViewBag.TempTreatmentCodes = tempTreatmentCodes;
            }

            return View();
        }
        [HttpPost]
        public IActionResult AddTreatCodes(int booking, int BCodes_TreatmentCodeID)
        {
            // Retrieve the temporary list from session
            var tempTreatmentCodes = HttpContext.Session.GetObjectFromJson<List<Booking_Codes>>("TempTreatmentCodes") ?? new List<Booking_Codes>();

            // Check if the treatment code exists
            var treatmentCode = _context.Treatment_Codes.FirstOrDefault(x => x.TreatmentCodeID == BCodes_TreatmentCodeID);

            if (treatmentCode != null)
            {
                // Check if the code already exists in the temp list for the current booking
                if (!tempTreatmentCodes.Any(x => x.TreatmentCodeID == BCodes_TreatmentCodeID && x.TheatreBookingID == booking))
                {
                    // Add new treatment code
                    var bookingCode = new Booking_Codes
                    {
                        TheatreBookingID = booking,
                        TreatmentCodeID = BCodes_TreatmentCodeID,
                        Treatment_ = treatmentCode
                    };

                    tempTreatmentCodes.Add(bookingCode);
                    // Save back to session
                    HttpContext.Session.SetObjectAsJson("TempTreatmentCodes", tempTreatmentCodes);
                }
            }

            // Redirect back to the GET method
            return RedirectToAction(nameof(AddTreatCodes), new { booking });
        }


        // POST: /Surgeon/RemoveTreatmentCode
        [HttpPost]
        public IActionResult RemoveTreatmentCode(int id, int booking)
        {
            // Fetch the temporary treatment codes from the session
            var tempTreatmentCodes = HttpContext.Session.GetObjectFromJson<List<Booking_Codes>>("TempTreatmentCodes") ?? new List<Booking_Codes>();

            // Attempt to remove the treatment code from the temp list
            var treatmentToRemove = tempTreatmentCodes.FirstOrDefault(x => x.TreatmentCodeID == id);
            if (treatmentToRemove != null)
            {
                tempTreatmentCodes.Remove(treatmentToRemove);
                // Update session
                HttpContext.Session.SetObjectAsJson("TempTreatmentCodes", tempTreatmentCodes);
            }

            // Now, remove from the existing records in the database
            var existingCodeToRemove = _context.Booking_Codes.FirstOrDefault(x => x.TreatmentCodeID == id && x.TheatreBookingID == booking);
            if (existingCodeToRemove != null)
            {
                _context.Booking_Codes.Remove(existingCodeToRemove);
                _context.SaveChanges(); // Commit the changes to the database
            }

            // Redirect back to the AddTreatCodes view
            return RedirectToAction(nameof(AddTreatCodes), new { booking });
        }



        // POST: /Surgeon/SaveTreatCodes
        [HttpPost]
        public IActionResult SaveTreatCodes(int? booking)
        {
            if (ModelState.IsValid && booking != null)
            {
                // Retrieve the temporary treatment codes from the session
                var tempTreatmentCodes = HttpContext.Session.GetObjectFromJson<List<Booking_Codes>>("TempTreatmentCodes") ?? new List<Booking_Codes>();

                // Ensure there are treatment codes to save
                if (tempTreatmentCodes.Count > 0)
                {
                    foreach (var record in tempTreatmentCodes)
                    {
                        // Ensure the correct booking ID is assigned to each record
                        record.TheatreBookingID = (int)booking;

                        // Attach the related Treatment_Codes entity (to prevent duplicate entries)
                        record.Treatment_ = _context.Treatment_Codes.FirstOrDefault(x => x.TreatmentCodeID == record.TreatmentCodeID);

                        // Add the record to the database context
                        _context.Booking_Codes.Add(record);
                    }

                    // Commit the changes to the database
                    _context.SaveChanges();

                    // Clear the temporary treatment codes from the session after saving
                    HttpContext.Session.SetObjectAsJson("TempTreatmentCodes", new List<Booking_Codes>());
                }
            }

            return RedirectToAction("ViewBookings"); // Redirect to the booking list or desired action after saving
        }


        //public IActionResult AddTreatCodes(int? booking)
        //{
        //    if (booking != null || booking != 0)
        //    {
        //        ViewBag.Booking = _context.Theatre_Bookings.Where(x => x.TheatreBookingID == booking).FirstOrDefault();
        //    }
        //    ViewBag.Bookings = _context.Theatre_Bookings.ToList();
        //    ViewBag.Patients = _context.Patient_Records.ToList();
        //    ViewBag.TCodes = _context.Treatment_Codes.ToList();
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddTreatCodes(Booking_Codes BCodes, int? booking)
        //{
        //    if (booking != null || booking != 0)
        //    {
        //        ViewBag.Booking = _context.Theatre_Bookings.Where(x => x.TheatreBookingID == booking).FirstOrDefault();
        //    }
        //    ViewBag.Bookings = _context.Theatre_Bookings.ToList();
        //    ViewBag.Patients = _context.Patient_Records.ToList();
        //    ViewBag.TCodes = _context.Treatment_Codes.ToList();
        //    if (ModelState.IsValid)
        //    {
        //        _context.Booking_Codes.Add(BCodes);
        //        _context.SaveChanges();
        //        return RedirectToAction("ViewBookings");
        //    }
        //    return View(BCodes);
        //}

        // this is for updating a booking. -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public IActionResult UpdateBooking(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            ViewBag.Theatre = _context.Theatre_Records.ToList();
            ViewBag.AllPatients = _context.Patient_Records.ToList();
            var obj = _context.Theatre_Bookings.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBooking(Theatre_Bookings booking)
        {
            if (ModelState.IsValid)
            {
                _context.Theatre_Bookings.Update(booking);
                _context.SaveChanges();

                // Redirect to AddTreatCodes and pass the TheatreBookingID as a parameter
                return RedirectToAction("AddTreatCodes", new { booking = booking.TheatreBookingID });
            }

            return View(booking);
        }


        // This is for deleting a booking.
        public IActionResult DeleteBooking(int Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _context.Theatre_Bookings.Where(x => x.TheatreBookingID == Id).FirstOrDefault();
            if (obj == null)
            {
                return NotFound();
            }
            _context.Theatre_Bookings.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("ViewBookings");
        }

        // View all the Admitted Patients.
        public IActionResult AdmittedPatients()
        {
            //var record = _context.Admission_Records.Include(c => c.Nurse).AsEnumerable();
            //var pat = _context.Patient_Records;
            //var bed = _context.Beds;
            //var ward = _context.Ward_Records;
            //var nurse = _context.Users;
            //var x = (from r in record
            //         join p in pat on r.Patient_ID_no equals p.Patient_ID_no
            //         join b in bed on r.BedID equals b.BedID
            //         join n in nurse on r.Nurse_ID equals n.Id
            //         join w in ward on b.WardID equals w.WardID
            //         select new AdmittedPatVM
            //         {
            //             Ward = w.WardName,
            //             NurName = $"{r.Nurse.Name} {r.Nurse.Surname}",
            //             PatName = $"{p.Patient_Name} {p.Patient_Surname}",
            //             Bed = r.BedID,
            //             AdmTime = r.AdmissionTime,
            //             Id = r.Admission_ID,
            //         }).AsEnumerable();
            //return View(x);

            //TempData["SuccessMessage"] = "Medications added successfully!";

            var record = _context.Theatre_Bookings.Include(c => c.User).Include(c => c.Theatre).Where(x => x.Status == "Admitted").AsEnumerable();
            var pat = _context.Patient_Records;
            var adm = _context.Admission_Records;
            var bed = _context.Beds;
            var ward = _context.Ward_Records;
            var nurse = _context.Users;
            var x = (from r in record
                     join p in pat on r.Patient_ID_no equals p.Patient_ID_no
                     join a in adm on r.Patient_ID_no equals a.Patient_ID_no
                     join b in bed on a.BedID equals b.BedID
                     join n in nurse on a.Nurse_ID equals n.Id
                     join w in ward on b.WardID equals w.WardID
                     select new AdmittedPatVM
                     {
                         Ward = w.WardName,
                         NurName = $"{a.Nurse.Name} {a.Nurse.Surname}",
                         PatName = $"{p.Patient_Name} {p.Patient_Surname}",
                         Bed = a.BedID,
                         AdmTime = a.AdmissionTime,
                         Id = r.TheatreBookingID,
                     }).AsEnumerable();
            return View(x);
        }

        //-------------------------------------------------------------------------------------------------- END ----------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------- Adding a Prescription ----------------------------------------------------------------------------------------------------------------------

        public IActionResult AddMedicine(int scriptId)
        {
            // Fetch the prescription to ensure it exists
            var prescription = _context.Script_Records.FirstOrDefault(x => x.ScriptID == scriptId);

            if (prescription == null)
            {
                return NotFound();
            }

            // Fetch all medications to populate the dropdown
            var medications = _context.Pharmacy_Medication.ToList();
            ViewBag.Medications = medications;

            // You can pre-populate or initialize the Script_Lines if needed
            ViewBag.ScriptID = scriptId;

            return View(new List<Script_Lines> { new Script_Lines { ScriptID = scriptId } });
        }


        [HttpPost]
        public IActionResult AddMedicine(List<Script_Lines> scriptLines, int scriptId)
        {
            if (ModelState.IsValid)
            {
                foreach (var line in scriptLines)
                {
                    // Ensure ScriptID is set for each line
                    line.ScriptID = scriptId;

                    // Add script line to the context
                    _context.Script_Lines.Add(line);
                }

                _context.SaveChanges();

                TempData["SuccessMessage"] = "Medications added successfully!";
                return RedirectToAction("ViewPrescriptions", new
                {
                    patientId = _context.Script_Records
                    .Where(x => x.ScriptID == scriptId)
                    .Select(x => x.Patient_ID_no).FirstOrDefault()
                });
            }

            // If validation fails, reload the page and show the error message
            TempData["ErrorMessage"] = "Error adding medications. Please try again.";

            // Reload medications for the dropdown
            ViewBag.Medications = _context.Pharmacy_Medication.ToList();
            ViewBag.ScriptID = scriptId;

            return View(scriptLines);
        }






        // This  method should help a brother be able to create a view he can see. ------------------------------------------------------------------------------------------------------------------------------------------
        public IActionResult AddPrescription(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var booking = _context.Theatre_Bookings.FirstOrDefault(b => b.TheatreBookingID == Id);

            if (booking == null)
            {
                return NotFound();
            }

            // Check if the patient already has a prescription
            var existingPrescription = _context.Script_Records
                .Where(s => s.Patient_ID_no == booking.Patient_ID_no)
                .OrderByDescending(s => s.DateIssued)
                .ToList();

            // If no existing prescriptions, create a new Script_Record automatically
            if (!existingPrescription.Any())
            {
                var newPrescription = new Script_Records
                {
                    SurgeonID = booking.SurgeonID,
                    DateIssued = DateOnly.FromDateTime(DateTime.Now),
                    TimeIssued = DateTime.Now.TimeOfDay,
                    Patient_ID_no = booking.Patient_ID_no,
                    Status = "Prescribed",
                    Urgent = false // or set based on user input if needed
                };

                _context.Script_Records.Add(newPrescription);
                _context.SaveChanges();

                // Redirect to add medications for this newly created prescription
                return RedirectToAction("AddMedicine", new { scriptId = newPrescription.ScriptID });
            }

            // If prescriptions exist, display the list ordered by date
            ViewBag.ExistingPrescriptions = existingPrescription;
            return View("ViewAllScriptRecords", existingPrescription); // assuming you have a view to show existing prescriptions
        }



        [HttpPost]
        public IActionResult AddPrescription(Script_Records prescription)
        {
            ModelState.Remove("PharmacistID");

            // Check if patient already has a prescription
            var existingPrescription = _context.Script_Records
                .Where(s => s.Patient_ID_no == prescription.Patient_ID_no && s.Status == "Prescribed")
                .FirstOrDefault();

            if (existingPrescription != null)
            {
                // Redirect to the medicine addition if prescription already exists
                TempData["InfoMessage"] = "Existing prescription found. Redirecting to add medications.";
                return RedirectToAction("AddMedicine", new { scriptId = existingPrescription.ScriptID });
            }

            // If the model is valid and no existing prescription is found
            if (ModelState.IsValid)
            {
                // Set the status and create a new prescription record
                prescription.Status = "Prescribed";
                prescription.DateIssued = DateOnly.FromDateTime(DateTime.Now);
                prescription.TimeIssued = DateTime.Now.TimeOfDay;

                _context.Script_Records.Add(prescription);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Prescription created successfully!";
                return RedirectToAction("AddMedicine", new { scriptId = prescription.ScriptID });
            }

            // Reload the patients list if something goes wrong
            TempData["ErrorMessage"] = "Error creating prescription. Please try again.";
            ViewBag.AllPatients = _context.Admission_Records
                .Where(a => a.Patient_ID_no == prescription.Patient_ID_no)
                .Select(a => a.Patient)
                .ToList();

            return View(prescription);
        }



        // Now lets Display all Scripts to the Surgeons. ----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public IActionResult ViewAllScriptRecords(int patientId)
        {
            // Fetch prescriptions for the patient, including related Patient entity, ordered by date issued (most recent first)
            var prescriptions = _context.Script_Records
                .Include(s => s.Patient)  // Ensure related Patient entity is loaded
                .Where(s => s.Patient_ID_no == patientId.ToString())
                .OrderByDescending(s => s.DateIssued)
                .ToList();

            if (prescriptions == null || !prescriptions.Any())
            {
                TempData["ErrorMessage"] = "No prescriptions found for this patient.";
                return RedirectToAction("AddPrescription", new { Id = patientId });
            }

            // Pass the prescription records to the view
            ViewBag.PatientID = patientId;
            return View(prescriptions);
        }


        public IActionResult ViewScriptLines(int scriptId)
        {
            // Fetch all Script_Lines for the given ScriptID
            var scriptLines = _context.Script_Lines
                .Include(sl => sl.Pharmacy) // Include Pharmacy to show Pharmacy details
                .Where(sl => sl.ScriptID == scriptId)
                .ToList();

            if (!scriptLines.Any())
            {
                return NotFound("No medications found for this prescription.");
            }

            // Pass the list of Script_Lines to the view
            return View(scriptLines);
        }
    }
}
