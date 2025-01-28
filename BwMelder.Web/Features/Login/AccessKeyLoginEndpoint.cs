using BwMelder.Web.Authentication;
using BwMelder.Web.EndpointDiscovery;
using Microsoft.AspNetCore.Authorization;

namespace BwMelder.Web.Features.Login;

class AccessKeyLoginEndpoint : IDiscoverableEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/go/{secret}", LoginWithSecret);
    }

    /// <summary>
    /// Logs in the user with the given secret.
    /// </summary>
    static async Task<IResult> LoginWithSecret(string secret, AuthenticationHandler authHandler, HttpContext context,
        IAuthorizationService authorization)
    {
        if (await authHandler.LoginAsync(secret))
        {
            if ((await authorization.AuthorizeAsync(context.User, "ClubIsOnboarded")).Succeeded)
            {
                return Results.Redirect("/");
            }
            return Results.Redirect("/onboarding/welcome");
        }
        return Results.NotFound();
    }
}
