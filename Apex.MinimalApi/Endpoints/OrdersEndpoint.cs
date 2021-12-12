namespace Apex.MinimalApi.Endpoints;

public class OrdersEndpoint : IEndpoint
{
    public void Map(WebApplication app)
    {
        app.MapGet("/orders", Get).WithTags("Orders");
        app.MapGet("/orders/{id}", GetById).WithTags("Orders");
    }

    private async Task<IResult> GetById(IOrdersRepository ordersRepository, int id)
    {
        try
        {
            var order = await ordersRepository.GetOrderByIdAsync(id);
            if (order == null) return Results.NotFound();
            return Results.Ok(order);
        }
        catch (Exception)
        {
            return Results.BadRequest();
        }
    }

    private async Task<IResult> Get(IOrdersRepository ordersRepository)
    {
        try
        {
            var orders = await ordersRepository.GetOrdersAsync();
            if (orders == null) return Results.NotFound();
            return Results.Ok(orders);
        }
        catch (Exception)
        {
            return Results.BadRequest();
        }
    }
}

