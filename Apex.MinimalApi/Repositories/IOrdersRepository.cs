namespace Apex.MinimalApi.Repositories;

public interface IOrdersRepository
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order?> GetOrderByIdAsync(int id);
}
