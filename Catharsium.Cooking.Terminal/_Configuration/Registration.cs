using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.Cooking.Terminal._Configuration;

public static class Registration
{
    public static IServiceCollection AddCookingTerminal(this IServiceCollection services, IConfiguration config)
    {
        var configuration = config.Load<CookingTerminalSettings>();
        services.AddSingleton<CookingTerminalSettings, CookingTerminalSettings>(provider => configuration);

        services.AddConsoleIoUtilities(config);

        return services;
    }
}