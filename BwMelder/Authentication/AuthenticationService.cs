using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace BwMelder.Authentication;

/// <summary>
/// Abstract base class for authentication services in the application.
/// </summary>
/// <param name="httpContextAccessor"></param>
abstract class AuthenticationService(IHttpContextAccessor httpContextAccessor)
{
    protected HttpContext Context =>
        httpContextAccessor.HttpContext
        ?? throw new InvalidOperationException("Operation requires an active HttpContext");

    /// <summary>
    /// Logs out the current user, ending their session.
    /// </summary>
    internal async Task LogoutAsync() => await Context.SignOutAsync();

    /// <summary>
    /// Logs in the current user with the given identity.
    /// </summary>
    internal async Task LoginAsync(ClaimsIdentity identity) =>
        await Context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
}
