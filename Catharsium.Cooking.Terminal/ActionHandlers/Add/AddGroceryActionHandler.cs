using Catharsium.Cooking.Terminal.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.Add;

public class AddGroceryActionHandler : IAddActionHandler
{
    public string MenuName => "Add grocery";


    public Task Run()
    {
        throw new NotImplementedException();
    }


    public override string ToString()
    {
        return this.MenuName;
    }
}