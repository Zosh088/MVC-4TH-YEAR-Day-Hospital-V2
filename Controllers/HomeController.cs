using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Surgeon__Day_Hospital_.Models;
using System.Diagnostics;

namespace Surgeon__Day_Hospital_.Controllers
{
    // the "authorize" attribute is used to restrict access to the Nurse role only.
    // this is how we restrict access to the different roles we have for the system.
    //[Authorize(Roles = "Nurse")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        // the "authorize" attribute is used to restrict access to the Nurse role only.
        // this is how we restrict access to the different roles we have for the system.
        //[Authorize(Roles = "Nurse")]
        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult GenericPage()
        {
            return View();
        }
        public IActionResult Index1()
        {
            return View();
        }
                           
        public IActionResult PharmacistLandingPage()
		{
			return View();
		}
        public IActionResult NurseLandingPage()
		{
			return View();
		}
        public IActionResult SurgeonLandingPage()
		{
			return View();
		}
        public IActionResult AdminLandingPage()
		{
			return View();
		}
       

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
