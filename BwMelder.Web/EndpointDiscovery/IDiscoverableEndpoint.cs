namespace BwMelder.Web.EndpointDiscovery;

internal interface IDiscoverableEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
