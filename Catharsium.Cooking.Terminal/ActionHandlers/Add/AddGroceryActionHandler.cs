using Catharsium.Cooking.Entities.Models;
using Catharsium.Cooking.Terminal.ActionHandlers.Choosers;
using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Files.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.Add;

public class AddGroceryActionHandler : BaseActionHandler, IAddActionHandler
{
    private readonly IJsonFileRepository<Grocery> groceryRepository;
    private readonly ISelectionStep<Quantity> quantitySelectionStep;
    private readonly ISelectionStep<Ingredient> ingredientSelectionStep;


    public AddGroceryActionHandler(
        IJsonFileRepository<Grocery> groceryRepository,
        ISelectionStep<Quantity> quantitySelectionStep,
        ISelectionStep<Ingredient> ingredientSelectionStep,
        IConsole console)
        : base(console, "Add grocery")
    {
        this.groceryRepository = groceryRepository;
        this.quantitySelectionStep = quantitySelectionStep;
        this.ingredientSelectionStep = ingredientSelectionStep;
    }


    public override async Task Run()
    {
        var ingredient = await this.ingredientSelectionStep.Select();
        var quantity = await this.quantitySelectionStep.Select();
        var selectedPrice = this.console.AskForDecimal("Enter the price");
        if (selectedPrice != null) { }
        await this.groceryRepository.Add(new Grocery {
            Id = Guid.NewGuid(),
            Quantity = quantity,
            Ingredient = ingredient,
            Price = selectedPrice.Value
        }, ingredient.Name);
    }
}