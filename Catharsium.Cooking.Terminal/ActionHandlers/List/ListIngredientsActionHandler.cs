using Catharsium.Cooking.Entities.Models;
using Catharsium.Cooking.Terminal.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Files.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.List;

public class ListIngredientsActionHandler : IListActionHandler
{
    private readonly IJsonFileRepository<Ingredient> ingredientRepository;
    private readonly IConsole console;

    public string MenuName => "List ingredients";


    public ListIngredientsActionHandler(IJsonFileRepository<Ingredient> ingredientRepository, IConsole console)
    {
        this.ingredientRepository = ingredientRepository;
        this.console = console;
    }


    public async Task Run()
    {
        var ingredients = await this.ingredientRepository.Get();
        foreach (var ingredient in ingredients) {
            this.console.WriteLine(ingredient.ToString());
        }
    }
}