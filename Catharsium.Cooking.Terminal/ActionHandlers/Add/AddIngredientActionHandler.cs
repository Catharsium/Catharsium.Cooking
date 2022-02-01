using Catharsium.Cooking.Entities.Models;
using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Files.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.Add;

public class AddIngredientActionHandler : BaseActionHandler, IAddActionHandler
{
    private readonly IJsonFileRepository<Ingredient> ingredientRepository;


    public AddIngredientActionHandler(IJsonFileRepository<Ingredient> ingredientRepository, IConsole console)
        : base(console, "Add ingredient")
    {
        this.ingredientRepository = ingredientRepository;
    }


    public override async Task Run()
    {
        var name = this.console.AskForText("Enter the name");
        await this.ingredientRepository.Add(new Ingredient {
            Id = Guid.NewGuid(),
            Name = name
        },
        name);
    }
}