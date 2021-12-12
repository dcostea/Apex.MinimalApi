namespace Apex.MinimalApi.Repositories;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
}
