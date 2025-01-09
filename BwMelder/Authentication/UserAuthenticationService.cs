using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using BwMelder.Model;

namespace BwMelder.Authentication;

/// <summary>
/// Handles authentication for users logging in with username and password.
/// </summary>
class UserAuthenticationService(IConfiguration config, IHttpContextAccessor httpContextAccessor)
    : AuthenticationService(httpContextAccessor)
{
    /// <summary>
    /// Try to login a user with the given credentials.
    /// </summary>
    /// <param name="credentials">Credentials provided by the user.</param>
    /// <returns>True if login completed successfully, false if it failed.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<bool> LoginUserAsync(User credentials)
    {
        if (ValidateCredentials(credentials))
        {
            var identity = GetUserIdentity();
            await Context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Creates a <see cref="ClaimsIdentity"/> instance for the user.
    /// </summary>
    private static ClaimsIdentity GetUserIdentity()
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, "Administrator"),
            new Claim(ClaimTypes.Role, "Administrator")
        };
        return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    }

    /// <summary>
    /// Checks if the supplied credentials are valid for the application.
    /// </summary>
    private bool ValidateCredentials(User credentials)
    {
        // Credentials are currently stored in the configuration in plaintext.
        var validUser = config.GetSection("AppAdmin").Get<User>();
        if (validUser == null)
        {
            throw new ApplicationException("No admin user configured.");
        }
        return validUser.Username == credentials.Username && validUser.Password == credentials.Password;
    } 
}
