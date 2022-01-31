using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.List;

public class ListActionHandler : IMenuActionHandler
{
    private readonly IEnumerable<IListActionHandler> actionHandlers;
    private readonly IConsole console;

    public string MenuName => "List";


    public ListActionHandler(IEnumerable<IListActionHandler> actionHandlers, IConsole console)
    {
        this.actionHandlers = actionHandlers;
        this.console = console;
    }


    public async Task Run()
    {
        var actionHandler = this.console.AskForItem(this.actionHandlers, "What would you like to see?");
        if (actionHandler != null) {
            await actionHandler.Run();
        }
    }
}