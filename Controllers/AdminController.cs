using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Surgeon__Day_Hospital_.Data;

namespace Surgeon__Day_Hospital_.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminLandingPage()
        {
            return View();
        }

    }
}
