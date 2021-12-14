namespace Apex.MinimalApi.Helpers;

public static class EndpointsManager
{
    public static void CustomMap(this WebApplication app)
    {
        app.Services.GetServices<IEndpoint>().ToList().ForEach(e => e.Map(app));
    }

    public static IServiceCollection ScanCustomEndpoints(this IServiceCollection services)
    {
        var endpointTypes = new[] { typeof(Program).Assembly }
            .SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(IEndpoint))));

        foreach (var type in endpointTypes)
        {
            services.Add(new ServiceDescriptor(typeof(IEndpoint), type, ServiceLifetime.Transient));
        }

        return services;
    }

    public static IServiceCollection AddCustomDependencies(this IServiceCollection services)
    {
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<IOrdersRepository, OrdersRepository>();

        return services;
    }
}
