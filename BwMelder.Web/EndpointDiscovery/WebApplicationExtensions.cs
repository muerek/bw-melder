using System.Reflection;

namespace BwMelder.Web.EndpointDiscovery;

static class WebApplicationExtensions
{
    /// <summary>
    /// Discovers and registers endpoints.
    /// Searches for types implementing <see cref="IDiscoverableEndpoint"/> in the given <see cref="Assembly"/>,
    /// then calls their <see cref="IDiscoverableEndpoint.MapEndpoint(IEndpointRouteBuilder)"/> method.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="assembly"></param>
    /// <returns></returns>
    internal static IEndpointRouteBuilder MapDiscoverableEndpoints(this IEndpointRouteBuilder builder, Assembly assembly)
    {
        // Find all types implementing the endpoint interface that are not abstract or an interface.
        var endpointTypes = assembly.DefinedTypes
            .Where(type => !type.IsAbstract && !type.IsInterface && type.IsAssignableTo(typeof(IDiscoverableEndpoint)))
            .ToArray();

        // Create an instance of each type to map its endpoints.
        foreach (var endpointType in endpointTypes)
        {
            var instance = Activator.CreateInstance(endpointType);
            if (instance is IDiscoverableEndpoint endpoint) { endpoint.MapEndpoint(builder); }
        }
        
        return builder;
    }
}
