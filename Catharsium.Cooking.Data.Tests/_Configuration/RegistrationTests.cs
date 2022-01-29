using Catharsium.Cooking.Data._Configuration;
using Catharsium.Util.IO.Files.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.Cooking.Data.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddWhatsAppTerminal_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddCookingData(configuration);
    }


    [TestMethod]
    public void AddWhatsAppTerminal_RegistersPackages()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddCookingData(configuration);
        serviceCollection.ReceivedRegistration<IFileFactory>();
    }
}