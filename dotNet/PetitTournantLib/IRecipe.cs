using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetitTournant.Lib
{
    public interface IRecipe
    {
        ICookBook Parent { get; set; }
        string Name { get; set; }
        CultureInfo Culture { get; set; }
        int Servings { get; set; }
        string ServingName { get; set; }
        List<Tuple<Decimal, string, string>> Ingredients { get; set; }
        List<IDiet> Diets { get; set; }
        string Steps { get; set; }
        TimeSpan PreperationTime { get; set; }
        TimeSpan CookingTime { get; set; }
        TimeSpan RestingTime { get; set; }
        TimeSpan TotalTime { get; }

        List<string> GetRefrences();
    }
}
