// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Surgeon__Day_Hospital_.Models;

namespace Surgeon__Day_Hospital_.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	public class LoginModel : PageModel
	{
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager; // Inject UserManager
		private readonly ILogger<LoginModel> _logger;

		public LoginModel(SignInManager<User> signInManager, UserManager<User> userManager, ILogger<LoginModel> logger)
		{
			_signInManager = signInManager;
			_userManager = userManager; // Initialize UserManager
			_logger = logger;
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		public string ReturnUrl { get; set; }

		[TempData]
		public string ErrorMessage { get; set; }

		public class InputModel
		{
			[Required]
			[EmailAddress]
			public string Email { get; set; }

			[Required]
			[DataType(DataType.Password)]
			public string Password { get; set; }

			[Display(Name = "Remember me?")]
			public bool RememberMe { get; set; }
		}

		public async Task OnGetAsync(string returnUrl = null)
		{
			if (!string.IsNullOrEmpty(ErrorMessage))
			{
				ModelState.AddModelError(string.Empty, ErrorMessage);
			}

			returnUrl ??= Url.Content("~/");

			// Clear the existing external cookie to ensure a clean login process
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			ReturnUrl = returnUrl;
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			returnUrl ??= Url.Content("~/");

			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					// Find the user by email
					var user = await _userManager.FindByEmailAsync(Input.Email);
					HttpContext.Session.SetString("user_id", user.Id);
					HttpContext.Session.SetString("user_name", user.Name);
					HttpContext.Session.SetString("user_fullName", "\n" + user.Name + " " + user.Surname);
                    HttpContext.Session.SetString("user_surname", user.Surname);
					// Get the roles of the logged-in user
					var roles = await _userManager.GetRolesAsync(user);

					// Redirect based on role
					if (roles.Contains("Admin"))
					{
						return RedirectToAction("AdminLandingPage", "Admin");
					}
					else if (roles.Contains("Nurse"))
					{
						return RedirectToAction("Index", "Nurse");
					}
					else if (roles.Contains("Surgeon"))
					{
						return RedirectToAction("SurgeonLandingPage", "Home");
					}
					else if (roles.Contains("Pharmacist"))
					{
						return RedirectToAction("PharmacistLandingPage", "Pharmacist");
					}


					// Default redirect if no specific role is matched
					return LocalRedirect(returnUrl);
				}
				if (result.RequiresTwoFactor)
				{
					return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
				}
				if (result.IsLockedOut)
				{
					_logger.LogWarning("User account locked out.");
					return RedirectToPage("./Lockout");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
					return Page();
				}
			}

			// If we got this far, something failed, redisplay form
			return Page();
		}
	}
}

  

