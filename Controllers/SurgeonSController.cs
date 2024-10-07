using Microsoft.AspNetCore.Mvc;
using Surgeon__Day_Hospital_.DapperLibrary.Repositories.PatientRepo;
using Surgeon__Day_Hospital_.DapperLibrary.Repositories.ThreatreBookingRepo;
using Surgeon__Day_Hospital_.Data;

namespace Surgeon__Day_Hospital_.Controllers
{
    public class SurgeonSController : Controller
    {
        private readonly ApplicationDbContext context;
        private PatientRepo patientRepo;
        public SurgeonSController(ApplicationDbContext context, PatientRepo patientRepo)
        {
            this.context = context;
            this.patientRepo = patientRepo;
        }
        public IActionResult Index()
        {
            ViewBag.ViewPatient = patientRepo.GetPatients("GetPatientAdmission", null, System.Data.CommandType.StoredProcedure);
            return View();
        }
    }
}
