using Catharsium.Cooking.Entities.Models;
using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Files.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.List;

public class ListIngredientsActionHandler : BaseActionHandler, IListActionHandler
{
    private readonly IJsonFileRepository<Ingredient> ingredientRepository;


    public ListIngredientsActionHandler(IJsonFileRepository<Ingredient> ingredientRepository, IConsole console)
        : base(console, "List ingredients")
    {
        this.ingredientRepository = ingredientRepository;
    }


    public override async Task Run()
    {
        var ingredients = await this.ingredientRepository.Get();
        foreach (var ingredient in ingredients) {
            this.console.WriteLine(ingredient.ToString());
        }
    }
}