using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Surgeon__Day_Hospital_.Data;
using Surgeon__Day_Hospital_.Models;


namespace Surgeon__Day_Hospital_.Controllers
{
	[Authorize(Roles = "Pharmacist")]
	public class PharmacistController : Controller
	{
		private readonly ApplicationDbContext _context;

        public PharmacistController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult GenericPage()
		{
			return View();
		}
		public IActionResult PharmacistLandingPage()
		{
			return View();
		}
        public IActionResult Prescriptions()
        {
        
            var x = _context.Script_Records.Include(c=>c.Patient).Include(c=>c.Users).Where(c=>c.Status == "Prescribed").AsEnumerable();
            return View(x);
        }

        //[Route("ScriptPage/{id?}")]

        //[Route("[controller]/[action]")]

        public async Task<IActionResult> ScriptPage(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            // Find the ScriptID associated with the patient
            var scriptRecord = await _context.Script_Records
                .Where(sr => sr.ScriptID == id)
                .FirstOrDefaultAsync();

            if (scriptRecord == null)
            {
                return NotFound();
            }
            var pat = await _context.Patient_Records
                .Where(sr => sr.Patient_ID_no == scriptRecord.Patient_ID_no)
                .FirstOrDefaultAsync();

            if (pat == null)
            {
                return NotFound();
            }

         
            var pres = new ScriptViewModel()
            {
                Patient = pat,
                Meds = _context.Script_Lines.Include(c=>c.Pharmacy).Include(c=>c.Pharmacy.DosageType).Where(x => x.ScriptID == scriptRecord.ScriptID).AsEnumerable(),
                ScriptID = id,
                Status = scriptRecord.Status
            };

            return View(pres);
        }

        //if (TempData["Message"] != null)
        //{
        //    ViewBag.Message = TempData["Message"];
        //}

        //return View();



        public async Task<IActionResult> ApproveScript(int scriptID)
        {
            if (scriptID <= 0)
            {
                return BadRequest();
            }

            // Retrieve the script record by ScriptID
            var scriptRecord = await _context.Script_Records
                .FirstOrDefaultAsync(sr => sr.ScriptID == scriptID);

            if (scriptRecord == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user_id")))
            {
                TempData["ErrorMessage"] = "Please Log out and login.";
                return RedirectToAction(nameof(Prescriptions));
            }
            // Update the script status to 'Dispensed'
            scriptRecord.Status = "Dispensed";
            scriptRecord.PharmacistID = HttpContext.Session.GetString("user_id");
            // Save the changes to the database
            _context.Script_Records.Update(scriptRecord);
            await _context.SaveChangesAsync();

            // Set a success message using TempData
            TempData["SuccessMessage"] = "The script has been successfully approved and dispensed.";

            // Redirect to a page (e.g., back to the script details or prescriptions page)
            return RedirectToAction(nameof(Prescriptions));
        }

        [HttpPost]
        public IActionResult Reject()
        {
            TempData["Message"] = "The prescription has been rejected.";
            return RedirectToAction("Prescriptions");
        }


        public async Task<IActionResult> Medical_Information(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var pat = await _context.Patient_Records
                .Where(sr => sr.Patient_ID_no == id)
                .FirstOrDefaultAsync();

            if (pat == null)
            {
                return NotFound();
            }
            var pres = new ScriptViewModel()
            {
                Patient = pat,
                Allergy = _context.Allergy_Records.Include(c=>c.ActiveIngredients).Where(c=>c.Patient_ID_no ==id).AsEnumerable(),
                Chronics = _context.Chronic_Patients.Include(c=>c.Condition).Where(c => c.Patient_ID_no == id).AsEnumerable(),
                CurrentMeds = _context.Patient_Current_Medications.Include(c=>c.Medication).Where(c => c.Patient_ID_No == id).OrderByDescending(x=>x.Date).AsEnumerable(),
                Vitals = _context.Vital_Records.Include(c => c.VitalT).OrderByDescending(x => x.VitalDate).AsEnumerable().DistinctBy(c => c.VitalID)
            };
            //var z = _context.Vital_Records.Include(c => c.VitalT).OrderByDescending(x => x.VitalDate).DistinctBy(c => c.VitalID).AsEnumerable();
            return View(pres);
        }


        public IActionResult DispensaryDashboard()
        {
            return View(_context.Script_Records.Include(c => c.Patient).Include(c => c.Users).Where(c => c.Status == "Dispensed" && c.PharmacistID == HttpContext.Session.GetString("user_id")).AsEnumerable()); 
        }
        public IActionResult RejectedPrescriptions()
        {
            return View(_context.Script_Records.Include(c => c.Patient).Include(c => c.Users).Where(c => c.Status == "Rejected" && c.PharmacistID == HttpContext.Session.GetString("user_id")).AsEnumerable()); 
        }
        public async Task<IActionResult> RejectPrescription(int scriptID)
        {
            if (scriptID <= 0)
            {
                return BadRequest();
            }

            // Retrieve the script record by ScriptID
            var scriptRecord = await _context.Script_Records.Include(c=>c.Patient)
                .FirstOrDefaultAsync(sr => sr.ScriptID == scriptID);

            if (scriptRecord == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user_id")))
            {
                TempData["ErrorMessage"] = "Please Log out and login.";
                return RedirectToAction(nameof(Prescriptions));
            }
            var pat = await _context.Patient_Records
                .Where(sr => sr.Patient_ID_no == scriptRecord.Patient_ID_no)
                .FirstOrDefaultAsync();

            if (pat == null)
            {
                return NotFound();
            }


            var pres = new ScriptViewModel()
            {
                Patient = pat,
                Meds = _context.Script_Lines.Include(c => c.Pharmacy).Include(c => c.Pharmacy.DosageType).Where(x => x.ScriptID == scriptRecord.ScriptID).AsEnumerable(),
                ScriptID = scriptRecord.ScriptID,
                Status = scriptRecord.Status
            };
            return View(scriptRecord); 
        }
        [HttpPost]
        public async Task<IActionResult> RejectScript(int scriptID, string reason)
        {
            if (scriptID <= 0)
            {
                return BadRequest();
            }

            // Retrieve the script record by ScriptID
            var scriptRecord = await _context.Script_Records
                .FirstOrDefaultAsync(sr => sr.ScriptID == scriptID);

            if (scriptRecord == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user_id")))
            {
                TempData["ErrorMessage"] = "Please Log out and login.";
                return RedirectToAction(nameof(Prescriptions));
            }
            scriptRecord.Status = "Rejected";
            scriptRecord.RejectReason = reason;
            _context.Script_Records.Update(scriptRecord);
            await _context.SaveChangesAsync();

            // Set a success message using TempData
            TempData["SuccessMessage"] = "The script has been successfully rejected.";
            return RedirectToAction(nameof(Prescriptions)); 
        }

        public IActionResult StockControlDashboard()
        {

            return View(); 
        
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(MedOrder_Record med)
        {
            if (ModelState.IsValid)
            {
                await _context.MedOrder_Records.AddAsync(med);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "The order has been successfully placed.";
                return RedirectToAction(nameof(StockItems));
            }
            return View(); //  not done
        
        }

        public IActionResult StockItems()
        {

            return View(_context.Pharmacy_Medication.Include(c=>c.DosageType).AsEnumerable()); 
        
        }
         
        public IActionResult DispensaryScript()
        {

            return View();

        }
        public IActionResult Order_Medication()
        {

            return View();

        }

    }


}
