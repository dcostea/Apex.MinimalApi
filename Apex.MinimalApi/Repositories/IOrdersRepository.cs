namespace Apex.MinimalApi.Repositories;

public interface IOrdersRepository : IEndpointDependency
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order?> GetOrderByIdAsync(int id);
}
