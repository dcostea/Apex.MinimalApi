namespace Apex.MinimalApi.Helpers;

public static class Endpoints
{
    public static void Map(WebApplication app)
    {
        app.Services.GetServices<IEndpoint>().ToList().ForEach(e => e.Map(app));
    }

    public static void Scan(IServiceCollection services)
    {
        var endpointTypes = new[] { typeof(Program).Assembly }
            .SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(IEndpoint))));

        foreach (var type in endpointTypes)
        {
            services.Add(new ServiceDescriptor(typeof(IEndpoint), type, ServiceLifetime.Transient));
        }
    }
}
