using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.Cooking.Data._Configuration;

public static class Registration
{
    public static IServiceCollection AddCookingData(this IServiceCollection services, IConfiguration config)
    {
        var configuration = config.Load<CookingDataSettings>();
        services.AddSingleton<CookingDataSettings, CookingDataSettings>(provider => configuration);

        services.AddIoUtilities(config);

        return services;
    }
}