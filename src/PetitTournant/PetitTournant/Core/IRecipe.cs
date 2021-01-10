using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetitTournant.Core
{
    public interface IRecipe
    {
        ICookBook Parent { get; set; }
        string Name { get; set; }
        CultureInfo culture { get; }
        int servings { get; }
        string servingName { get; }
        List<Tuple<Decimal, string, string>> Ingredients { get; }
        List<DietType> Diets { get; }
        List<string> steps { get; }
        TimeSpan PreperationTime { get; }
        TimeSpan CookingTime { get; }
        TimeSpan RestingTime { get; }
        TimeSpan TotalTime { get; }
    }
}
