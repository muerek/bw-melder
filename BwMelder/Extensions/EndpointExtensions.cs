using BwMelder.Dto;
using BwMelder.Services;

namespace BwMelder.Extensions;

static class EndpointExtensions
{
    /// <summary>
    /// Registers endpoints implemented as minimal APIs.
    /// </summary>
    public static WebApplication MapBwMelderEndpoints(this WebApplication app)
    {
        app.MapGet("/admin/logout", Logout);
        app.MapGet("/go/{secret}", LoginWithSecret);

        // TODO: Remove these endpoints, only for testing.
        app.MapGet("/clubs/new/{name}", CreateClub);
        
        return app;
    }

    /// <summary>
    /// Logout the current user, ending their session.
    /// </summary>
    static async Task<IResult> Logout(AuthenticationService authService)
    {
        await authService.LogoutAsync();
        return Results.Redirect("/");
    }

    static async Task<IResult> LoginWithSecret(string secret, AuthenticationService authService)
    {
        if (await authService.LoginAsync(secret))
        {
            return Results.Redirect("/");
        }
        return Results.NotFound();
    }

    static async Task<IResult> CreateClub(string name, ClubService clubService)
    {
        var request = new CreateClubRequest() { Name = name };
        await clubService.CreateClubAsync(request);
        return Results.Ok();
    }

}
