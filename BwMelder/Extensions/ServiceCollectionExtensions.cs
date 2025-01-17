using BwMelder.Authentication;
using BwMelder.Core;
using BwMelder.Shared.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BwMelder.Extensions;

static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the application's services.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBwMelderServices(this IServiceCollection services)
    {
        services.AddScoped<IAccessKeyService, AccessKeyService>();
        services.AddScoped<ICrewService, CrewService>();
        services.AddScoped<IClubCoachService, ClubCoachService>();
        services.AddScoped<IClubService, ClubService>();

        return services;
    }

    /// <summary>
    /// Registers and configures services required for authentication.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBwMelderAuthentication(this IServiceCollection services)
    {
        // Configure cookie-based authentication.
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                // Session timeout after two hours of inactivity.
                options.ExpireTimeSpan = TimeSpan.FromHours(2);
                options.SlidingExpiration = true;
            });

        // Add handler for login and logout process.
        services.AddScoped<AuthenticationHandler>();

        // Provide authentication state to components, required for AuthorizeView.
        services.AddCascadingAuthenticationState();
        // Provide access to HTTP context, required for setting cookies on login.
        services.AddHttpContextAccessor();

        return services;
    }

    /// <summary>
    /// Configures authorization.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBwMelderAuthorization(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy("ClubIsNotOnboarded", policy =>
                policy.RequireRole("ClubCoach").RequireClaim("OnboardingRequired", "true"))
            .AddPolicy("ClubIsOnboarded", policy =>
                policy.RequireRole("ClubCoach").RequireClaim("OnboardingRequired", "false"));
        
        return services;
    }
}
