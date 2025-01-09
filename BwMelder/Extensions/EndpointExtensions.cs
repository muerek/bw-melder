using BwMelder.Authentication;

namespace BwMelder.Extensions;

static class EndpointExtensions
{
    /// <summary>
    /// Registers endpoints implemented as minimal APIs.
    /// </summary>
    public static WebApplication MapBwMelderEndpoints(this WebApplication app)
    {
        app.MapGet("/admin/logout", Logout);
        app.MapGet("/go/{key}", LoginWithKey);
        
        return app;
    }

    /// <summary>
    /// Logout the current user, ending their session.
    /// </summary>
    static async Task<IResult> Logout(UserAuthenticationService authService)
    {
        await authService.LogoutAsync();
        return Results.Redirect("/");
    }

    static async Task<IResult> LoginWithKey(string key, KeyAuthenticationService authService)
    {
        if (await authService.LoginWithKeyAsync(key))
        {
            return Results.Redirect("/");
        }
        return Results.NotFound();
    }

}
