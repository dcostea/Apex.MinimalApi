namespace Apex.MinimalApi.Repositories;

public interface IProductsRepository : IEndpointDependency
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
}
