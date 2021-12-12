namespace Apex.MinimalApi.Endpoints;

public class HelloEndpoint : IEndpoint
{
    public void Map(WebApplication app)
    {
        var specialWord = app.Configuration["SpecialWord"] ?? "none";

        app.MapGet($"/hello/world", () => $"Hello {specialWord}!").WithTags("Hello");
    }
}
