using BwMelder.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BwMelder.Extensions;

static class ServicesExtensions
{
    /// <summary>
    /// Registers the application's services.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBwMelderServices(this IServiceCollection services)
    {

        return services;
    }

    /// <summary>
    /// Registers and configures services required for authentication.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBwMelderAuthentication(this IServiceCollection services)
    {
        // Add cookie-based authentication.
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                // Session timeout after two hours of inactivity.
                options.ExpireTimeSpan = TimeSpan.FromHours(2);
                options.SlidingExpiration = true;
            });

        // Add services handling login and logout process.
        services.AddScoped<UserAuthenticationService>();
        services.AddScoped<KeyAuthenticationService>();

        // Provide authentication state to components, required for AuthorizeView.
        services.AddCascadingAuthenticationState();
        // Provide access to HTTP context, required for setting cookies on login.
        services.AddHttpContextAccessor();

        return services;
    }
}
