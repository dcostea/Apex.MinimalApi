namespace Apex.MinimalApi.Manager;

public static class EndpointsManager
{
    /// <summary>
    /// By conventions IEndpoint interface must be implemented by user defined endpoints in order to be mapped
    /// </summary>
    /// <param name="app"></param>
    public static void MapApexEndpoints(this WebApplication app)
    {
        app.Services.GetServices<IEndpoint>().ToList().ForEach(e => e.Map(app));
    }

    /// <summary>
    /// By conventions IEndpoint interface must be implemented by user defined endpoints in order to be found
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ScanApexEndpoints(this IServiceCollection services)
    {
        var endpointTypes = new[] { typeof(Program).Assembly }
            .SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(IEndpoint))));

        foreach (var type in endpointTypes)
        {
            services.Add(new ServiceDescriptor(typeof(IEndpoint), type, ServiceLifetime.Transient));
        }

        return services;
    }

    /// <summary>
    /// By conventions IEndpointDependency interface must be implemented by user defined dependencies in order to be found
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static IServiceCollection ScanApexDependencies(this IServiceCollection services)
    {
        var endpointDependencyTypes = new[] { typeof(Program).Assembly }
            .SelectMany(a => a.DefinedTypes
            .Where(x => x.IsClass && x.GetInterfaces().Contains(typeof(IEndpointDependency))));

        foreach (var type in endpointDependencyTypes)
        {
            var interfaceType = type.GetInterface($"I{type.Name}");
            if (interfaceType is null)
            {
                throw new InvalidOperationException($"No conventional interface (like I{type.Name}) found for type {type.Name}.");
            }

            services.Add(new ServiceDescriptor(interfaceType, type, ServiceLifetime.Scoped));
        }

        return services;
    }
}
