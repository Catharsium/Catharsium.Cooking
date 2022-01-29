namespace Catharsium.Cooking.Entities.Models;

public class Instructions
{
    public string Name { get; set; }
    public int DurationInMinutes { get; set; }
    public List<Action> Steps { get; set; }
}