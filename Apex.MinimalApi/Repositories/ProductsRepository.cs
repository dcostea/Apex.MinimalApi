namespace Apex.MinimalApi.Repositories;

public class ProductsRepository : IProductsRepository
{
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await Task.FromResult(Product.SomeProducts.SingleOrDefault(a => a.Id.Equals(id)));
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await Task.FromResult(Product.SomeProducts);
    }
}
