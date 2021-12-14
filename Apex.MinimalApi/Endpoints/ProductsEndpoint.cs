namespace Apex.MinimalApi.Endpoints;

public class ProductsEndpoint : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapGet("/products", Get).WithTags("Products");
        app.MapGet("/products/{id}", GetById).WithTags("Products");
    }

    private async Task<IResult> Get(IProductsRepository productsRepository)
    {
        try
        {
            var products = await productsRepository.GetProductsAsync();
            if (products == null) return Results.NotFound();

            return Results.Ok(products);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }

    private async Task<IResult> GetById(IProductsRepository productsRepository, int id)
    {
        try
        {
            var product = await productsRepository.GetProductByIdAsync(id);
            if (product == null) return Results.NotFound();
            
            return Results.Ok(product);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }
}