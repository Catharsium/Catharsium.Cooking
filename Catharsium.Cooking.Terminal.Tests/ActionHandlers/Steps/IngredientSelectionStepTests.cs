using Catharsium.Cooking.Entities.Models;
using Catharsium.Cooking.Terminal.ActionHandlers.Steps;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Files.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Catharsium.Cooking.Terminal.Tests.ActionHandlers.Steps;

[TestClass]
public class IngredientSelectionStepTests : TestFixture<IngredientSelectionStep>
{
    [TestMethod]
    public async Task Select_ValidChoice_ReturnsIngredient()
    {
        var ingredients = new List<Ingredient> {
            new Ingredient()
        };
        this.GetDependency<IJsonFileRepository<Ingredient>>().Get().Returns(Task.FromResult(ingredients));
        this.GetDependency<IConsole>().AskForItem(ingredients).Returns(ingredients.ElementAt(0));

        var actual = await this.Target.Select();
        Assert.AreEqual(ingredients.ElementAt(0), actual);
    }


    [TestMethod]
    public async Task Select_NoSelectedIngredient_ReturnsNull()
    {
        var ingredients = new List<Ingredient> {
            new Ingredient()
        };
        this.GetDependency<IJsonFileRepository<Ingredient>>().Get().Returns(Task.FromResult(ingredients));
        this.GetDependency<IConsole>().AskForItem(ingredients).Returns(null as Ingredient);

        var actual = await this.Target.Select();
        Assert.IsNull(actual);
    }
}