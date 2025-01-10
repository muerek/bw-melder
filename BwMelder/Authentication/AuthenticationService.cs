using BwMelder.Data;
using BwMelder.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BwMelder.Authentication;

/// <summary>
/// Handles authentication tasks for the application.
/// </summary>
class AuthenticationService(IHttpContextAccessor httpContextAccessor, BwMelderDbContext db,
    IConfiguration config)
{
    private HttpContext Context =>
        httpContextAccessor.HttpContext
        ?? throw new InvalidOperationException("Operation requires an active HttpContext");

    /// <summary>
    /// Logs out the current user, ending their session.
    /// </summary>
    public async Task LogoutAsync() => await Context.SignOutAsync();

    /// <summary>
    /// Tries to login a user identified by the given access key.
    /// </summary>
    /// <param name="key">Access key provided by the user.</param>
    /// <returns>True if login completed successfully, false if it failed.</returns>
    public async Task<bool> LoginAsync(string key)
    {
        var accessKey = await db.AccessKeys
            .AsNoTracking()
            .SingleOrDefaultAsync(k => k.Key == key);

        if (accessKey != null)
        {
            var claims = new List<Claim>()
            {
                new("ClubId", accessKey.ClubId.ToString()),
                new(ClaimTypes.Role, "ClubCoach")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await LoginAsync(identity);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Tries to login a user identified by the given credentials.
    /// </summary>
    /// <param name="credentials">Credentials provided by the user.</param>
    /// <returns>True if login completed successfully, false if it failed.</returns>
    public async Task<bool> LoginAsync(User credentials)
    {
        if (ValidateCredentials(credentials))
        {
            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, "Administrator"),
                new(ClaimTypes.Role, "Administrator")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await LoginAsync(identity);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Logs in the current user with the given identity.
    /// </summary>
    private async Task LoginAsync(ClaimsIdentity identity) =>
        await Context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

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
