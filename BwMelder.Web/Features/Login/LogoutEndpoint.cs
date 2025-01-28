using BwMelder.Web.Authentication;
using BwMelder.Web.EndpointDiscovery;

namespace BwMelder.Web.Features.Login;

class LogoutEndpoint : IDiscoverableEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/admin/logout", Logout);
    }

    /// <summary>
    /// Logs out the current user, ending their session.
    /// </summary>
    static async Task<IResult> Logout(AuthenticationHandler authHandler)
    {
        await authHandler.LogoutAsync();
        return Results.Redirect("/");
    }
}
