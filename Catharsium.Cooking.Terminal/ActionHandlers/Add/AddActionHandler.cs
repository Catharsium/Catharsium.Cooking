using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.Add;

public class AddActionHandler : IMenuActionHandler
{
    private readonly IEnumerable<IAddActionHandler> actionHandlers;
    private readonly IConsole console;

    public string MenuName => "Add";


    public AddActionHandler(IEnumerable<IAddActionHandler> actionHandlers, IConsole console)
    {
        this.actionHandlers = actionHandlers;
        this.console = console;
    }


    public async Task Run()
    {
        var actionHandler = this.console.AskForItem(this.actionHandlers, "What would you like to add?");
        if (actionHandler != null) {
            await actionHandler.Run();
        }
    }
}