using BwMelder.Web.Authentication;
using BwMelder.Web.Utilities.EndpointDiscovery;
using Microsoft.AspNetCore.Authorization;

namespace BwMelder.Web.Features.Login;

internal class AccessKeyLoginEndpoint : IDiscoverableEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/go/{secret}", LoginWithSecret);
        app.MapGet("/go/continue", RouteClubCoach);
    }

    /// <summary>
    /// Logs in the user with the given secret.
    /// </summary>
    private static async Task<IResult> LoginWithSecret(string secret, AuthenticationHandler authHandler)
    {
        if (await authHandler.LoginAsync(secret))
        {
            // The signed-in user context is only available in subsequent HTTP requests.
            // Redirect will trigger a new request so the next steps can be determined.
            return Results.Redirect("/go/continue");
        }
        return Results.NotFound();
    }

    /// <summary>
    /// Redirects a club coach to their next step.
    /// </summary>
    [Authorize(Roles = "ClubCoach")]
    private static async Task<IResult> RouteClubCoach(IAuthorizationService authorization, HttpContext context)
    {
        // Determine if onboarding must be completed.
        var authorizationResult = await authorization.AuthorizeAsync(context.User, "ClubIsOnboarded");
        return Results.Redirect(authorizationResult.Succeeded ? "/registration" : "/onboarding/welcome");
    }
}
