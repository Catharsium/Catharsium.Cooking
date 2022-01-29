using Catharsium.Cooking.Terminal._Configuration;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.WhatsApp.Terminal;

class Program
{
    static async Task Main(string[] args)
    {
        var appsettingsFilePath = @"E:\Cloud\OneDrive\Software\Catharsium.Cooking\appsettings.json";
        if (args.Length > 0) {
            appsettingsFilePath = args[0];
        }

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(appsettingsFilePath, false, false);
        var configuration = builder.Build();

        var serviceProvider = new ServiceCollection()
            .AddCookingTerminal(configuration)
            .BuildServiceProvider();

        var chooseOperationActionHandler = serviceProvider.GetService<IMainMenuActionHandler>();
        await chooseOperationActionHandler.Run();
    }
}