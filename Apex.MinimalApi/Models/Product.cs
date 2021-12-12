namespace Apex.MinimalApi.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }

    public Product(int id, string name, float price)
    {
        Id = id;
        Name = name;    
        Price = price; 
    }

    public static IEnumerable<Product> SomeProducts { get; set; } =
        new List<Product>
        {
            new Product(1, "Apple", 5),
            new Product(2, "Bread", 4),
            new Product(3, "Yogurt", 2)
        };
}
