using Catharsium.Cooking.Entities.Models;
using Catharsium.Cooking.Terminal.ActionHandlers.Steps;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;
namespace Catharsium.Cooking.Terminal.Tests.ActionHandlers.Steps;

[TestClass]
public class QuantitySelectionStepTests : TestFixture<QuantitySelectionStep>
{
    [TestMethod]
    public async Task Select_ValidInput_ReturnsQuantity()
    {
        var units = 123.456M;
        var type = QuantityType.Chefspoon;
        this.GetDependency<IConsole>().AskForDecimal(Arg.Any<string>()).Returns(units);
        this.GetDependency<IConsole>().AskForEnum<QuantityType>(Arg.Any<string>()).Returns(type);

        var actual = await this.Target.Select();
        Assert.IsNotNull(actual);
        Assert.AreEqual(units, actual.Units);
        Assert.AreEqual(type, actual.Type);
    }


    [TestMethod]
    public async Task Select_InvalidIUnits_ReturnsNull()
    {
        var type = QuantityType.Chefspoon;
        this.GetDependency<IConsole>().AskForDecimal(Arg.Any<string>()).Returns(null as decimal?);
        this.GetDependency<IConsole>().AskForEnum<QuantityType>(Arg.Any<string>()).Returns(type);

        var actual = await this.Target.Select();
        Assert.IsNull(actual);
    }


    [TestMethod]
    public async Task Select_InvalidIType_ReturnsNull()
    {
        var units = 123.456M;
        this.GetDependency<IConsole>().AskForDecimal(Arg.Any<string>()).Returns(units);
        this.GetDependency<IConsole>().AskForEnum<QuantityType>(Arg.Any<string>()).Returns(null as QuantityType?);

        var actual = await this.Target.Select();
        Assert.IsNull(actual);
    }
}