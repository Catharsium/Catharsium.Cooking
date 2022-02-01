using Catharsium.Cooking.Entities.Models;
using Catharsium.Cooking.Terminal.ActionHandlers.Choosers;
using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.Steps;

public class QuantitySelectionStep : ISelectionStep<Quantity>
{
    private readonly IConsole console;


    public QuantitySelectionStep(IConsole console)
    {
        this.console = console;
    }


    public Task<Quantity> Select()
    {
        return Task.Run(() => {
            var selectedUnits = this.console.AskForDecimal("Enter the quantity value");
            var selectedType = this.console.AskForEnum<QuantityType>("Select the quantity type");
            Quantity quantity = null;
            if (selectedUnits != null && selectedType != null) {
                quantity = new Quantity {
                    Units = selectedUnits.Value,
                    Type = selectedType.Value
                };
            }

            return quantity;
        });
    }
}