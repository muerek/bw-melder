namespace BwMelder.Web.Utilities.EndpointDiscovery;

internal interface IDiscoverableEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
