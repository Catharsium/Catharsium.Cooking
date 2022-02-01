using Catharsium.Cooking.Entities.Models;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Files.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.Steps;

public class IngredientSelectionStep : ISelectionStep<Ingredient>
{
    private readonly IJsonFileRepository<Ingredient> ingredientRepository;
    private readonly IConsole console;


    public IngredientSelectionStep(IJsonFileRepository<Ingredient> ingredientRepository, IConsole console)
    {
        this.ingredientRepository = ingredientRepository;
        this.console = console;
    }


    public async Task<Ingredient> Select()
    {
        var ingredients = await this.ingredientRepository.Get();
        return this.console.AskForItem(ingredients);
    }
}