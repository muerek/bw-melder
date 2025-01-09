using Microsoft.AspNetCore.Authentication;

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
    /// Logout the current user.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    internal async Task LogoutUserAsync() => await Context.SignOutAsync();
}
