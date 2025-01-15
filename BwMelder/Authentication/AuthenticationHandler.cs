using BwMelder.Shared.Dto;
using BwMelder.Shared.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BwMelder.Authentication;

/// <summary>
/// Handles authentication tasks for the application.
/// </summary>
public class AuthenticationHandler(IHttpContextAccessor httpContextAccessor, IConfiguration config,
    IAccessKeyService accessKeyService)
{
    private HttpContext Context =>
        httpContextAccessor.HttpContext
        ?? throw new InvalidOperationException("Operation requires an active HttpContext");

    /// <summary>
    /// Logs out the current user, ending their session.
    /// </summary>
    public async Task LogoutAsync() => await Context.SignOutAsync();

    /// <summary>
    /// Tries to login a user identified by the given secret.
    /// </summary>
    /// <param name="secret">Secret provided by the user.</param>
    /// <returns>True if login completed successfully, false if it failed.</returns>
    public async Task<bool> LoginAsync(string secret)
    {
        var authResponse = await accessKeyService.AuthenticateAsync(secret);

        if (authResponse.IsSuccess)
        {
            var claims = new List<Claim>
            {
                // TODO: Should probably do null checks here, but too cumbersome.
                new("ClubId", authResponse.ClubId!.Value.ToString()),
                new("ClubName", authResponse.ClubName!),
                new("OnboardingRequired", authResponse.OnboardingRequired.ToString().ToLower(), ClaimValueTypes.Boolean),
                new(ClaimTypes.Role, authResponse.Role!)
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
    public async Task<bool> LoginAsync(UserLoginRequest credentials)
    {
        if (ValidateCredentials(credentials))
        {
            var claims = new List<Claim>
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
    private bool ValidateCredentials(UserLoginRequest credentials)
    {
        // Credentials are currently stored in the configuration in plaintext.
        // TODO: Do something else here.
        var validUser = config.GetValue<string>("AppAdmin:Username");
        var validPassword = config.GetValue<string>("AppAdmin:Password");
        if (validUser == null || validPassword == null)
        {
            throw new ApplicationException("No admin user configured.");
        }
        return validUser == credentials.Username && validPassword == credentials.Password;
    }
}
