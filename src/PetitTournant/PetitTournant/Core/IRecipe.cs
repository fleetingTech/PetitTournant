using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetitTournant.Core
{
    public interface IRecipe
    {
        string Name { get; }
        CultureInfo culture { get; }
        List<string> Ingredients { get; }
        List<DietType> Diets { get; }
        List<string> steps { get; }
        TimeSpan PreperationTime { get; }
        TimeSpan CookingTime { get; }
        TimeSpan RestingTime { get; }
        TimeSpan TotalTime { get; }
    }
}
