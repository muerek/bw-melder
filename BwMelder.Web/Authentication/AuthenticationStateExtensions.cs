using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BwMelder.Web.Authentication;

public static class AuthenticationStateExtensions
{
    /// <summary>
    /// Reads information on the current user from the <see cref="CascadingAuthenticationState"/>.
    /// </summary>
    /// <param name="task"></param>
    /// <returns>User information; null if no authenticated user.</returns>
    public static async Task<UserInfo?> GetUserInfoAsync(this Task<AuthenticationState>? task)
    {
        if (task is null) { return null; }

        var authenticationState = await task;
        var user = authenticationState.User;

        if (user.Identity is not null && user.Identity.IsAuthenticated)
        {
            return new UserInfo
            {
                Role = user.FindFirstValue(ClaimTypes.Role) ?? string.Empty,
                ClubId = Guid.TryParse(user.FindFirstValue("ClubId"), out var guid) ? guid : null,
                ClubName = user.FindFirstValue("ClubName") ?? string.Empty
            };
        }

        return null;
    }

    /// <summary>
    /// Reads information on the current user directly from the <see cref="AuthenticationStateProvider"/>.
    /// </summary>
    /// <param name="provider"></param>
    /// <returns>User information; null if no authenticated user.</returns>
    /// <remarks>
    /// This is not the recommended approach as there is no notifications for authentication state changes.
    /// But it could be an easier-to-use extension method if you do not care about that.
    /// </remarks>
    public static async Task<UserInfo?> GetUserInfoAsync(this AuthenticationStateProvider? provider)
    {
        if (provider is null) { return null; }

        var task = provider.GetAuthenticationStateAsync();
        return await task.GetUserInfoAsync();
    }
}