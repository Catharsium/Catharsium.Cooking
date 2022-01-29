using Catharsium.Cooking.Entities.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.Cooking.Entities.Tests.Models;

[TestClass]
public class IngredientTests : TestFixture<Ingredient>
{
    #region ToString

    [TestMethod]
    public void ToString_ReturnsName()
    {
        var expected = "My name";
        this.Target.Name = expected;

        var actual = this.Target.ToString();
        Assert.AreEqual(expected, actual);
    }

    #endregion
}