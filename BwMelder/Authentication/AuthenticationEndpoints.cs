using BwMelder.Shared.Dto;
using BwMelder.Shared.Services;
using Microsoft.AspNetCore.Authorization;

namespace BwMelder.Authentication;

static class AuthenticationEndpoints
{
    /// <summary>
    /// Registers authentication-related endpoints implemented as minimal APIs.
    /// </summary>
    public static WebApplication MapBwMelderAuthenticationEndpoints(this WebApplication app)
    {
        app.MapGet("/admin/logout", Logout);
        app.MapGet("/go/{secret}", LoginWithSecret);

        // TODO: Remove these endpoints, only for testing.
        app.MapGet("/clubs/new/{name}", CreateClub);

        return app;
    }

    /// <summary>
    /// Logs out the current user, ending their session.
    /// </summary>
    static async Task<IResult> Logout(AuthenticationHandler authHandler)
    {
        await authHandler.LogoutAsync();
        return Results.Redirect("/");
    }

    /// <summary>
    /// Logs in the user with the given secret.
    /// </summary>
    static async Task<IResult> LoginWithSecret(string secret, AuthenticationHandler authHandler, HttpContext context,
        IAuthorizationService authorization)
    {
        if (await authHandler.LoginAsync(secret))
        {
            if ((await authorization.AuthorizeAsync(context.User, "OnboardedClubCoach")).Succeeded)
            {
                return Results.Redirect("/");
            }
            return Results.Redirect("/onboarding/welcome");
        }
        return Results.NotFound();
    }

    static async Task<IResult> CreateClub(string name, IClubService clubService)
    {
        var request = new CreateClubRequest() { Name = name };
        await clubService.CreateClubAsync(request);
        return Results.Ok();
    }

}
