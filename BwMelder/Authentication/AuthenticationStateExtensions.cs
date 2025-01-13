using BwMelder.Shared.Dto;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BwMelder.Authentication;

public static class AuthenticationStateExtensions
{
    /// <summary>
    /// Reads information on the current user from the <see cref="CascadingAuthenticationState"/>.
    /// </summary>
    /// <param name="task"></param>
    /// <returns>User information or null if no authenticated user.</returns>
    public static async Task<UserContext?> GetUserContextAsync(this Task<AuthenticationState>? task)
    {
        if (task is not null)
        {
            var authenticationState = await task;
            var user = authenticationState.User;

            if (user?.Identity is not null && user.Identity.IsAuthenticated)
            {
                return new UserContext
                {
                    Role = user.FindFirstValue(ClaimTypes.Role) ?? string.Empty,
                    ClubId = Guid.TryParse(user.FindFirstValue("ClubId"), out var guid) ? guid : null,
                    ClubName = user.FindFirstValue("ClubName")
                };
            }
        }
        return null;
    }
}
