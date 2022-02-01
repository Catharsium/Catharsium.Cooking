using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.Add;

public class AddActionHandler : BaseMenuActionHandler<IAddActionHandler>
{
    public AddActionHandler(IEnumerable<IAddActionHandler> actionHandlers, IConsole console)
        : base(actionHandlers, console, "Add")
    { }


    public override async Task Run()
    {
        var actionHandler = this.console.AskForItem(this.actionHandlers, "What would you like to add?");
        if (actionHandler != null) {
            await actionHandler.Run();
        }
    }
}