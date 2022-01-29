using Catharsium.Util.Reflection.Attributes;
namespace Catharsium.Cooking.Entities.Models;

public enum QuantityType
{
    [Alias("pc")]
    Piece,

    [Alias("pack")]
    Package,

    [Alias("g")]
    Gram,

    [Alias("kg")]
    Kilogram,

    [Alias("ml")]
    Milliliter,

    [Alias("l")]
    Liter,

    [Alias("tsp")]
    Teaspoon,

    [Alias("tbsp")]
    Tablespoon,

    [Alias("csp")]
    Chefspoon
}