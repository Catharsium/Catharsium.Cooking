using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.Edit;

public class EditActionHandler : BaseMenuActionHandler<IEditActionHandler>
{
    public EditActionHandler(IEnumerable<IEditActionHandler> actionHandlers, IConsole console)
        : base(actionHandlers, console, "Edit")
    { }


    public override async Task Run()
    {
        var actionHandler = this.console.AskForItem(this.actionHandlers, "What would you like to edit?");
        if (actionHandler != null) {
            await actionHandler.Run();
        }
    }
}