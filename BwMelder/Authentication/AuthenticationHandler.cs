using BwMelder.Shared.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BwMelder.Authentication;

/// <summary>
/// Handles authentication tasks for the application.
/// </summary>
public class AuthenticationHandler(IHttpContextAccessor httpContextAccessor, IUserAuthenticationService userAuthenticationService,
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
        var authResponse = await userAuthenticationService.AuthenticateAsync(credentials);

        if (authResponse.IsSuccess)
        {
            var claims = new List<Claim>
            {
                // TODO: Should probably do null checks here, but too cumbersome.
                new(ClaimTypes.Name, "Administrator"),
                new(ClaimTypes.Role, authResponse.Role!)
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
    private async Task LoginAsync(ClaimsIdentity identity)
    {
        // Make sure any existing session is terminated.
        await LogoutAsync();
        await Context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
    }
}
