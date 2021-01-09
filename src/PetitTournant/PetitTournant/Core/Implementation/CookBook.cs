using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetitTournant.Core.Implementation
{
    internal class CookBook : ICookBook
    {
        public string Name { get;  set; }

        public string Path { get;  set; }

        public string ImagePath { get;  set; }

        public CultureInfo Culture { get;  set; }

        public List<IRecipe> Recipes { get; } = new List<IRecipe>();

        public void AddRecipe(IRecipe rep)
        {
            this.Recipes.Add(rep);
        }

        public CookBook(string Name, string path, CultureInfo culture)
        {
            this.Name = Name;
            this.Path = path;
            this.Culture = culture;
        }

        public CookBook()
        {
            this.Name = string.Empty;
            this.Path = string.Empty;
            this.ImagePath = string.Empty;
            this.Culture = null;
        }
    }
}
