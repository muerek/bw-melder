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
        
        return app;
    }

    /// <summary>
    /// Logout the current user, ending their session.
    /// </summary>
    static async Task<IResult> Logout(UserAuthenticationService service)
    {
        await service.LogoutUserAsync();
        return Results.Redirect("/");
    }

}
