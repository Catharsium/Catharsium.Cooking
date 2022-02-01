using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.Edit;

public class EditIngredientActionHandler : BaseActionHandler, IEditActionHandler
{
    public EditIngredientActionHandler(IConsole console) : base(console, "Edit ingredient")
    {
    }


    public override async Task Run()
    {
        throw new NotImplementedException();
    }
}