using Catharsium.Cooking.Entities.Models;
using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Files.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.Add;

public class AddIngredientActionHandler : IAddActionHandler
{
    private readonly IJsonFileRepository<Ingredient> ingredientRepository;
    private readonly IConsole console;

    public string MenuName => "Add ingredient";


    public AddIngredientActionHandler(IJsonFileRepository<Ingredient> ingredientRepository, IConsole console)
    {
        this.ingredientRepository = ingredientRepository;
        this.console = console;
    }


    public async Task Run()
    {
        var name = this.console.AskForText("Enter the name");
        await this.ingredientRepository.Add(new Ingredient {
            Id = Guid.NewGuid(),
            Name = name
        },
        name);
    }


    public override string ToString()
    {
        return this.MenuName;
    }
}