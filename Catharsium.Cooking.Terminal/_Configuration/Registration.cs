using Catharsium.Cooking.Data._Configuration;
using Catharsium.Cooking.Terminal.ActionHandlers.Add;
using Catharsium.Cooking.Terminal.ActionHandlers.List;
using Catharsium.Cooking.Terminal.Interfaces;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console._Configuration;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.Cooking.Terminal._Configuration;

public static class Registration
{
    public static IServiceCollection AddCookingTerminal(this IServiceCollection services, IConfiguration config)
    {
        var configuration = config.Load<CookingTerminalSettings>();
        services.AddSingleton<CookingTerminalSettings, CookingTerminalSettings>(provider => configuration);

        services.AddCookingData(config);
        services.AddConsoleIoUtilities(config);

        services.AddScoped<IMenuActionHandler, ListActionHandler>();
        services.AddScoped<IMenuActionHandler, AddActionHandler>();

        services.AddScoped<IListActionHandler, ListIngredientsActionHandler>();

        services.AddScoped<IAddActionHandler, AddIngredientActionHandler>();
        services.AddScoped<IAddActionHandler, AddGroceryActionHandler>();
        services.AddScoped<IAddActionHandler, AddRecipeActionHandler>();

        return services;
    }
}