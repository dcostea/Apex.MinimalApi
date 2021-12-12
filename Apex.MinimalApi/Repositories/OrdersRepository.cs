namespace Apex.MinimalApi.Repositories;

public class OrdersRepository : IOrdersRepository
{
    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await Task.FromResult(Order.SomeOrders.SingleOrDefault(a => a.Id.Equals(id)));
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await Task.FromResult(Order.SomeOrders);
    }
}
