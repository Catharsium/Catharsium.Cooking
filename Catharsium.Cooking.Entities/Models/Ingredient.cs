namespace Catharsium.Cooking.Entities.Models;

public class Ingredient
{
    public Guid Id { get; set; }
    public string Name { get; set; }


    public override string ToString()
    {
        return this.Name;
    }
}