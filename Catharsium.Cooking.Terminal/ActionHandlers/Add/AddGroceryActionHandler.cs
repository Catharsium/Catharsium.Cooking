using Catharsium.Cooking.Entities.Models;
using Catharsium.Cooking.Terminal.ActionHandlers.Choosers;
using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Files.Interfaces;

namespace Catharsium.Cooking.Terminal.ActionHandlers.Add;

public class AddGroceryActionHandler : IAddActionHandler
{
    private readonly IJsonFileRepository<Grocery> groceryRepository;
    private readonly ISelectionStep<Ingredient> ingredientSelectionStep;
    private readonly IConsole console;

    public string MenuName => "Add grocery";


    public AddGroceryActionHandler(IJsonFileRepository<Grocery> groceryRepository, ISelectionStep<Ingredient> ingredientSelectionStep, IConsole console)
    {
        this.groceryRepository = groceryRepository;
        this.ingredientSelectionStep = ingredientSelectionStep;
        this.console = console;
    }


    public async Task Run()
    {
        var ingredient = await this.ingredientSelectionStep.Select();
        var selectedUnits = this.console.AskForDecimal("Enter the quantity");
        var selectedType = this.console.AskForEnum<QuantityType>("Select the type");
        var selectedPrice = this.console.AskForDecimal("Enter the price");
        if (selectedUnits != null && selectedType != null && selectedPrice != null) {
            var quantity = new Quantity {
                Units = selectedUnits.Value,
                Type = selectedType.Value
            };
            await this.groceryRepository.Add(new Grocery {
                Id = Guid.NewGuid(),
                Quantity = quantity,
                Ingredient = ingredient,
                Price = selectedPrice.Value
            }, ingredient.Name);
        }
    }


    public override string ToString()
    {
        return this.MenuName;
    }
}