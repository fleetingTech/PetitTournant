using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetitTournant.Core
{
    public interface ICookBook
    {
        string Name { get; set; }
        string Path { get; set; }
        string ImagePath { get; set; }
        CultureInfo Culture { get; set; }
        List<IRecipe> Recipes { get; }
        void AddRecipe(IRecipe rep);
    }
}
