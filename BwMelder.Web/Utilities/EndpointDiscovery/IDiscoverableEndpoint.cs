namespace BwMelder.Web.Utilities.EndpointDiscovery;

/// <summary>
/// Describes a minimal API endpoint that provides a method for registering itself.
/// </summary>
internal interface IDiscoverableEndpoint
{
    /// <summary>
    /// Registers the minimal API endpoints.
    /// </summary>
    /// <param name="app"></param>
    void MapEndpoint(IEndpointRouteBuilder app);
}
