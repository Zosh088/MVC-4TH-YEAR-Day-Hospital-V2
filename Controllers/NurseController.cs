using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Surgeon__Day_Hospital_.Data;
using Surgeon__Day_Hospital_.Models;
using Surgeon__Day_Hospital_.DapperLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Surgeon__Day_Hospital_.Controllers
{
    //[Authorize(Roles ="Nurse")]
    public class NurseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor http;

        public NurseController(ApplicationDbContext context, IHttpContextAccessor http) 
        {
            _context = context;
            this.http = http;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCity(int id)
        {
            return Json(_context.City_Records.Where(x=>x.ProvinceID == id).AsEnumerable());
        }
        [HttpGet]
        public JsonResult GetSuburb(int id)
        {
            return Json(_context.Suburb_Records.Where(x=>x.CityID == id).AsEnumerable());
        }

        [HttpGet]
        public async Task<JsonResult> AddPatMeds(string pat, int id)
        {
            var x = new Chronic_Patients()
            {
                Patient_ID_no = pat,
                ConditionID = id
            };
            await _context.Chronic_Patients.AddAsync(x);
            await _context.SaveChangesAsync();
            return Json(true);
        }
        [HttpGet]
        public async Task<JsonResult> DelPatMeds(string pat, int id)
        {
            var x = new Chronic_Patients()
            {
                Patient_ID_no = pat,
                ConditionID = id
            };
            var o = await _context.Chronic_Patients.Where(x => x.ConditionID == id && x.Patient_ID_no == pat).FirstOrDefaultAsync();
            if (o != null)
            {
                _context.Chronic_Patients.Remove(o);
                await _context.SaveChangesAsync();
            }
            
            return Json(true);
        }
        [HttpGet]
        public async Task<JsonResult> AddPatAll(string pat, int id)
        {
            var x = new Allergy_Records()
            {
                Patient_ID_no = pat,
                ActiveID = id
            };
            await _context.Allergy_Records.AddAsync(x);
            await _context.SaveChangesAsync();
            return Json(true);
        }
        [HttpGet]
        public async Task<JsonResult> DelPatAll(string pat, int id)
        {
            
            var o = await _context.Allergy_Records.Where(x => x.ActiveID == id && x.Patient_ID_no == pat).FirstOrDefaultAsync();
            if (o != null)
            {
                _context.Allergy_Records.Remove(o);
                await _context.SaveChangesAsync();
            }
            
            return Json(true);
        }
        [HttpGet]
        public async Task<JsonResult> AddPatCon(string pat, int id)
        {
            var x = new Chronic_Conditions()
            {
                Patient_ID_no = pat,
                ConditionID = id
            };
            await _context.Chronic_Conditions.AddAsync(x);
            await _context.SaveChangesAsync();
            return Json(true);
        }
        [HttpGet]
        public async Task<JsonResult> DelPatCon(string pat, int id)
        {
            
            var o = await _context.Chronic_Conditions.Where(x => x.ConditionID == id && x.Patient_ID_no == pat).FirstOrDefaultAsync();
            if (o != null)
            {
                _context.Chronic_Conditions.Remove(o);
                await _context.SaveChangesAsync();
            }
            
            return Json(true);
        }
       
        [HttpGet]
        public async Task<JsonResult> AddVital(string pat, int id, double value, double? value2)
        {

            Vital_Records vital = new()
            {
                Value = value,
                Value2 = value2,
                Patient_ID_no = pat,
                Vital = id,
            };
            await _context.Vital_Records.AddAsync(vital);
            await _context.SaveChangesAsync();
            return Json(true);
        }


        public IActionResult BookedPatients()
        {           
            var record = _context.Theatre_Bookings.Include(c=>c.User).Include(c=>c.Theatre).Where(x=>x.Status == "Booked").AsEnumerable();
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
                        id=r.TheatreBookingID,
                    }).AsEnumerable();
            return View(x);
        }

        public async Task<IActionResult> AdmitPatient(int? id)
        {
            if (id == null)
            {
                return RedirectToActionPermanent(nameof(BookedPatients));
            }
            var d = await _context.Theatre_Bookings.Include(c => c.User).Where(x=>x.TheatreBookingID == id).FirstOrDefaultAsync();
            AdmitPatVM a = new()
            {
                Surgeon = await _context.Userss.Where(x => x.Id == d.SurgeonID).FirstOrDefaultAsync(),
                Patient_Records = await _context.Patient_Records.Where(x => x.Patient_ID_no == d.Patient_ID_no).FirstOrDefaultAsync(),
                Vital_Types = _context.Vital_Types,
                BookId = d.TheatreBookingID
            };
            var bed = _context.Beds.Include(c => c.WardRecords).Select(x=> new
            {
                Name = $"{x.BedNumber} ({x.WardRecords.WardName})",
                Id = x.BedID
            }).AsEnumerable();
            ViewBag.Beds = new SelectList(bed, "Id", "Name");
            ViewBag.Provinces = new SelectList(_context.Province_Records, "ProvinceID", "ProvinceName");
            ViewBag.Meds = new SelectList(_context.Chronic_Medications, "Chronic_ID", "Name");
            ViewBag.Contra = new SelectList(_context.Contra_Indications, "ContraID", "Name");
            ViewBag.Allergy = new SelectList(_context.Active_Ingredients, "ActiveID", "Decription");

            return View(a);
        }
        [HttpPost]
        public async Task<IActionResult> AdmitPatient(AdmitPatVM vM)
        {
            if (vM == null)
            {
                TempData["error"] = "Something went wrong with the model being passed. Try again later";
                return RedirectToActionPermanent(nameof(BookedPatients));
            }

            try
            {
                Admission_Records a = new()
                {
                    Patient_ID_no = vM.Patient_Records.Patient_ID_no,
                    AdmissionDate = DateOnly.FromDateTime((DateTime)vM.AdmitDate),
                    BedID = vM.Beds.BedID,
                    Nurse_ID = HttpContext.Session.GetString("user_id"),
                    AdmissionTime = TimeOnly.FromDateTime((DateTime)vM.AdmitDate),
                    BookingID = vM.BookId,

                };
                _context.Patient_Records.Update(vM.Patient_Records);
                await _context.SaveChangesAsync();

                await _context.Admission_Records.AddAsync(a);
                await _context.SaveChangesAsync();
                var z = _context.Theatre_Bookings.Where(x=>x.TheatreBookingID == vM.BookId).FirstOrDefault();
                z.Status = "Admitted";
                _context.Theatre_Bookings.Update(z);
                await _context.SaveChangesAsync();
                return RedirectToActionPermanent(nameof(MyPatients));
            }
            catch 
            {

                TempData["error"] = "Something went wrong while saving the data. Try again later";
                return RedirectToActionPermanent(nameof(BookedPatients));
            }
            return View();
        }
        public async Task<IActionResult> PatientInfo(string Pat)
        {

            var xx = _context.Patient_Records.Where(x => x.Patient_ID_no == Pat).FirstOrDefault();
            if (xx != null)
            {
                PatientInfo a = new()
                {
                    Vital_Records = _context.Vital_Records.Include(c=>c.VitalT).Include(c=>c.Patient_Records).Where(x=>x.Patient_ID_no == Pat).OrderByDescending(x=>x.VitalDate).AsEnumerable(),
                    Patient_Records = await _context.Patient_Records.Include(c=>c.SuburbRecords).Where(x => x.Patient_ID_no == xx.Patient_ID_no).FirstOrDefaultAsync(),
                };
                return View(a);

            }
            TempData["error"] = "Patient Not found";
            return RedirectToActionPermanent(nameof(MyPatients));
        }

        public IActionResult MyPatients()
        {
            var x = _context.Admission_Records.Include(c => c.Patient).Include(c => c.Bookings).Include(c => c.Beds).Include(c=>c.Beds.WardRecords).Include(c => c.Bookings.User).Where(x => x.Bookings.Status == "Admitted").AsEnumerable();
            return View(x);
        }

        public async Task<IActionResult> RecaptureVitals(string Pat) 
        {
            var xx = _context.Patient_Records.Where(x=>x.Patient_ID_no  == Pat).FirstOrDefault();
            if (xx != null)
            {
                AdmitPatVM a = new()
                {
                    
                    Patient_Records = await _context.Patient_Records.Where(x => x.Patient_ID_no == xx.Patient_ID_no).FirstOrDefaultAsync(),
                    Vital_Types = _context.Vital_Types,
                };
                return View(a);

            }
            TempData["error"] = "Patient Not found";
            return RedirectToActionPermanent(nameof(MyPatients));
        }

        public IActionResult VitalsUpdateNotification()
        {
            return View();
        }

        public IActionResult ManageMedication()
        {
            return View();
        }

        public IActionResult ViewPatient()
        {
            return View();
        }

        public IActionResult Discharge(string Pat, int id)
        {
            Discharge_Records records = new()
            {
                Patient_ID_no = Pat,
                NurseID = HttpContext.Session.GetString("user_id"),
                Book = id,
            };
            return View(records);
        }
        [HttpPost]
        public async Task<IActionResult> Discharge(Discharge_Records d)
        {
            if (ModelState.IsValid)
            {
                var b = await _context.Theatre_Bookings.Where(x => x.TheatreBookingID == d.Book).FirstOrDefaultAsync();
                if (b != null)
                {
                    b.Status = "Discharged";
                    _context.Theatre_Bookings.Update(b);
                    await _context.SaveChangesAsync();
                    await _context.Discharge_Records.AddAsync(d);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Patient has been discharged";
                    return RedirectToActionPermanent(nameof(MyPatients));
                }
                
                
            }
            TempData["Error"] = "Error when discharging patient";
            return RedirectToActionPermanent(nameof(MyPatients));
        }












    }
}
