using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace BwMelder.Authentication;

/// <summary>
/// Handles user authentication.
/// </summary>
public class UserAuthenticationService
{
    private readonly IConfiguration config;
    private readonly IHttpContextAccessor httpContextAccessor;

    public UserAuthenticationService(IConfiguration config, IHttpContextAccessor httpContextAccessor)
    {
        this.config = config;
        this.httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Login the user for the given credentials.
    /// </summary>
    /// <param name="credentials">Credentials provided by the user.</param>
    /// <returns>True if login completed successfully, false if it failed.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<bool> LoginUserAsync(UserCredentials credentials)
    {
        if (ValidateCredentials(credentials))
        {
            var identity = GetUserIdentity();
            
            var context = httpContextAccessor.HttpContext;
            if (context == null) { throw new InvalidOperationException("This operation requires an active HttpContext"); }

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Logout the current user.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task LogoutUserAsync()
    {
        var context = httpContextAccessor.HttpContext;
        if (context == null) { throw new InvalidOperationException("This operation requires an active HttpContext"); }
        // Clear existing session.
        await context.SignOutAsync();
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
    private bool ValidateCredentials(UserCredentials credentials)
    {
        // Credentials are currently stored in the configuration in plaintext.
        var validCredentials = config.GetSection("AppAdmin").Get<UserCredentials>();
        if (validCredentials == null)
        {
            throw new ApplicationException("No admin user configured.");
        }
        return validCredentials.Username == credentials.Username && validCredentials.Password == credentials.Password;
    }
}
