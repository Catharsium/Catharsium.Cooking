namespace Catharsium.Cooking.Entities.Models;

public class Recipe
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Notes { get; set; }
    public int Servings { get; set; }
    public Dictionary<Ingredient, Quantity> Ingredients { get; set; }
    public List<Instructions> Instructions { get; set; }
}