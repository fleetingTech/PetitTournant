using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetitTournant.Core
{
    public interface ICookBook
    {
        string Name { get; }
        string Path { get; }
        string ImagePath { get; }
        CultureInfo Culture { get; }
        List<IRecipe> Recipes {get;}
        void AddRecipe(IRecipe rep);
    }
}
