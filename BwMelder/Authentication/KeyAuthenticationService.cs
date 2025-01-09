using BwMelder.Data;
using BwMelder.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BwMelder.Authentication;

/// <summary>
/// Handles authentication for users using access keys.
/// </summary>
/// <param name="httpContextAccessor"></param>
class KeyAuthenticationService(IHttpContextAccessor httpContextAccessor, BwMelderDbContext db)
    : AuthenticationService(httpContextAccessor)
{
    public async Task<bool> LoginWithKeyAsync(string key)
    {
        var accessKey = await db.AccessKeys
            .AsNoTracking()
            .SingleOrDefaultAsync(k => k.Key == key);

        if (accessKey != null)
        {
            await LoginAsync(GetClaimsIdentity(accessKey));
            return true;
        }

        return false;
    }

    private ClaimsIdentity GetClaimsIdentity(AccessKey accessKey)
    {
        var claims = new List<Claim>()
        {
            new Claim("ClubId", accessKey.ClubId.ToString()),
            new Claim(ClaimTypes.Role, "ClubCoach")
        };
        return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
