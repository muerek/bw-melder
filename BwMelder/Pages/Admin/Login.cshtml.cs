using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BwMelder.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BwMelder.Pages.Admin
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IConfiguration config;

        [BindProperty]
        public LoginInput Input { get; set; } = new();

        public string? Message { get; private set; } = null;

        public class LoginInput
        {
            [Display(Name = "Benutzername")]
            [Required]
            public string Username { get; set; } = string.Empty;

            [Display(Name = "Passwort")]
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
        }

        public LoginModel(IConfiguration config)
        {
            this.config = config;
        }

        public async Task OnGetAsync(string? returnUrl)
        {
            // Clear existing cookies to log out any existing sessions.
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Add an explanation message if the user tried to access another page.
            if (returnUrl != null)
            {
                Message = "Zum Zugriff auf diese Seite müssen Sie sich anmelden.";
            }
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Read the admin account data from the configuration.
            // There is just a single admin account right now.
            var user = config.GetSection("AppAdmin").Get<User>();

            // Check username and password.
            // TODO: Handle passwords hashed and not in plaintext.
            if (user.Username == Input.Username && user.Password == Input.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "Administrator")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // Redirect to given return URL or homepage.
                return LocalRedirect(Url.IsLocalUrl(returnUrl) ? returnUrl : "/Index");
            }

            Message = "Falsche Zugangsdaten.";
            return Page();
        }
    }
}
