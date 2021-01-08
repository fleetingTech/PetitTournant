using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetitTournant.Core
{
    internal class CookBook : ICookBook
    {
        public string Name { get; internal set; }

        public string Path { get; internal set; }

        public string ImagePath { get; internal set; }

        public CultureInfo Culture { get; internal set; }

        public List<IRecipe> Recipes { get; internal set; }

        public void AddRecipe(IRecipe rep)
        {
            this.Recipes.Add(rep);
        }

        public CookBook(string Name, string path, CultureInfo culture)
        {
            this.Recipes = new List<IRecipe>();
            this.Name = Name;
            this.Path = path;
            this.Culture = culture;
        }
    }
}
