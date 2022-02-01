using Catharsium.Cooking.Data._Configuration;
using Catharsium.Cooking.Entities.Models;
using Catharsium.Cooking.Terminal._Configuration;
using Catharsium.Cooking.Terminal.ActionHandlers.Add;
using Catharsium.Cooking.Terminal.ActionHandlers.Edit;
using Catharsium.Cooking.Terminal.ActionHandlers.List;
using Catharsium.Cooking.Terminal.ActionHandlers.Steps;
using Catharsium.Cooking.Terminal.Interfaces.ActionHandlers;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.WhatsApp.Terminal.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddWhatsAppTerminal_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddCookingTerminal(configuration);

        serviceCollection.ReceivedRegistration<IMenuActionHandler, AddActionHandler>();
        serviceCollection.ReceivedRegistration<IMenuActionHandler, EditActionHandler>();
        serviceCollection.ReceivedRegistration<IMenuActionHandler, ListActionHandler>();

        serviceCollection.ReceivedRegistration<IListActionHandler, ListIngredientsActionHandler>();

        serviceCollection.ReceivedRegistration<IAddActionHandler, AddIngredientActionHandler>();
        serviceCollection.ReceivedRegistration<IAddActionHandler, AddGroceryActionHandler>();
        serviceCollection.ReceivedRegistration<IAddActionHandler, AddRecipeActionHandler>();

        serviceCollection.ReceivedRegistration<ISelectionActionStep<Ingredient>, IngredientSelectionStep>();
        serviceCollection.ReceivedRegistration<ISelectionActionStep<Quantity>, QuantitySelectionStep>();
    }


    [TestMethod]
    public void AddWhatsAppTerminal_RegistersPackages()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddCookingTerminal(configuration);
        serviceCollection.ReceivedRegistration<CookingDataSettings>();
        serviceCollection.ReceivedRegistration<IMainMenuActionHandler>();
    }
}