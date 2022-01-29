using Catharsium.Cooking.Entities.Models;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Files._Configuration;
using Catharsium.Util.IO.Files.Interfaces;
using Catharsium.Util.IO.Files.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.Cooking.Data._Configuration;

public static class Registration
{
    public static IServiceCollection AddCookingData(this IServiceCollection services, IConfiguration config)
    {
        var configuration = config.Load<CookingDataSettings>();
        services.AddSingleton<CookingDataSettings, CookingDataSettings>(provider => configuration);
        services.AddFilesIoUtilities(config);

        services.AddScoped<IJsonFileRepository<Ingredient>>(s => new JsonFileRepository<Ingredient>(
            s.GetService<IFileFactory>(),
            s.GetService<IJsonFileReader>(),
            s.GetService<IJsonFileWriter>(),
            s.GetService<CookingDataSettings>().FileSystemRepository["IngredientsFolder"]));
        services.AddScoped<IJsonFileRepository<Grocery>>(s => new JsonFileRepository<Grocery>(
            s.GetService<IFileFactory>(),
            s.GetService<IJsonFileReader>(),
            s.GetService<IJsonFileWriter>(),
            s.GetService<CookingDataSettings>().FileSystemRepository["GroceriesFolder"]));
        services.AddScoped<IJsonFileRepository<Recipe>>(s => new JsonFileRepository<Recipe>(
            s.GetService<IFileFactory>(),
            s.GetService<IJsonFileReader>(),
            s.GetService<IJsonFileWriter>(),
            s.GetService<CookingDataSettings>().FileSystemRepository["RecipesFolder"]));

        return services;
    }
}