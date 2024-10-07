using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Surgeon__Day_Hospital_.Models;

public class AccountController : Controller
{
	private readonly SignInManager<IdentityUser> _signInManager;
	private readonly UserManager<IdentityUser> _userManager;

	public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
	{
		_signInManager = signInManager;
		_userManager = userManager;
	}

	[HttpPost]
	public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
	{
		if (ModelState.IsValid)
		{
			var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
			if (result.Succeeded)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				var roles = await _userManager.GetRolesAsync(user);

				// Redirect based on role
				if (roles.Contains("Admin"))
				{
					return RedirectToAction("Index", "Admin");
				}
				else if (roles.Contains("Nurse"))
				{
					return RedirectToAction("Index", "Nurse");
				}
				else if (roles.Contains("Surgeon"))
				{
					return RedirectToAction("Index", "Surgeon");
				}
				else if (roles.Contains("Pharmacist"))
				{
					return RedirectToAction("GenericPage", "Pharmacist");
				}

				// Default redirect if no specific role is matched
				return RedirectToAction("Index", "Home");
			}

			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
		}

		// If we got this far, something failed, redisplay form
		return View(model);
	}
}
