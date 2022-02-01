using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.List;

public class ListActionHandler : BaseMenuActionHandler<IListActionHandler>, IMenuActionHandler
{
    public ListActionHandler(IEnumerable<IListActionHandler> actionHandlers, IConsole console)
        : base(actionHandlers, console, "List")
    { }


    public override async Task Run()
    {
        var actionHandler = this.console.AskForItem(this.actionHandlers, "What would you like to see?");
        if (actionHandler != null) {
            await actionHandler.Run();
        }
    }
}