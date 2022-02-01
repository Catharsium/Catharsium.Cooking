using Catharsium.Cooking.Entities.Models;
using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Files.Interfaces;
namespace Catharsium.Cooking.Terminal.ActionHandlers.Add;

public class AddRecipeActionHandler : BaseActionHandler, IAddActionHandler
{
    private readonly IJsonFileRepository<Recipe> recipeRepository;


    public AddRecipeActionHandler(IJsonFileRepository<Recipe> recipeRepository, IConsole console)
        : base(console, "Add recipe")
    {
        this.recipeRepository = recipeRepository;
    }


    public override async Task Run()
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
}