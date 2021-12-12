namespace Apex.MinimalApi.Models;

public class Order
{
    public int Id { get; set; }
    public int Quantity { get; set; }

    public Order(int id, int quantity)
    {
        Id = id;
        Quantity = quantity;    
    }

    public static IEnumerable<Order> SomeOrders { get; set; } =
        new List<Order>
        {
            new Order(1, 3),
            new Order(2, 11),
            new Order(3, 2)
        };
}
