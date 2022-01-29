namespace Catharsium.Cooking.Entities.Models;

public class Grocery
{
    public Guid Id { get; set; }
    public Ingredient Ingredient { get; set; }
    public Quantity Quantity { get; set; }
    public decimal Price { get; set; }
    public string Url { get; set; }
}