using Catharsium.Cooking.Entities.Models;
using Catharsium.Cooking.Terminal.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Files.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.Add;

public class AddRecipeActionHandler : IAddActionHandler
{
    private readonly IJsonFileRepository<Recipe> recipeRepository;
    private readonly IConsole console;

    public string MenuName => "Add recipe";


    public AddRecipeActionHandler(IJsonFileRepository<Recipe> recipeRepository, IConsole console)
    {
        this.recipeRepository = recipeRepository;
        this.console = console;
    }


    public async Task Run()
    {
        var key = "My recipe";
        await this.recipeRepository.Add(new Recipe {
            Id = Guid.NewGuid(),
            Name = key,
            Servings = 3,
            Instructions = new List<Instructions> {
                    new Instructions {
                        Name = "Cooking",
                        DurationInMinutes = 30,
                        Steps = new List<Entities.Models.Action> {
                            new Entities.Models.Action {
                                Description  = "Do something useful"
                            }
                        }
                    }
                }
        }, key);
    }


    public override string ToString()
    {
        return this.MenuName;
    }
}