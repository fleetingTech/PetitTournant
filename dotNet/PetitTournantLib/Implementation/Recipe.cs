using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetitTournant.Lib.Implementation
{
    class Recipe : IRecipe
    {
        public Recipe(string name, CultureInfo culture, List<Tuple<decimal, string, string>> ingredients, List<IDiet> diets, string steps, TimeSpan preperation, TimeSpan cookingTime, TimeSpan restingTime)
        {
            this.Name = name;
            this.Culture = culture;
            this.Ingredients = Ingredients;
            this.Steps = steps;
            this.PreperationTime = preperation;
            this.CookingTime = cookingTime;
            this.RestingTime = restingTime;
        }
        public Recipe() { }

        public Recipe(ICookBookFile File)
        {

        }

        public string Name { get;  set; }

        public CultureInfo Culture { get; set; }

        public List<Tuple<decimal, string, string>> Ingredients { get; set; }

        public List<IDiet> Diets { get; set; }

        public string Steps { get; set; }

        public TimeSpan PreperationTime { get; set; }

        public TimeSpan CookingTime { get; set; }

        public TimeSpan RestingTime { get; set; }

        public TimeSpan TotalTime { get { return PreperationTime + CookingTime + RestingTime; } }

		public int Servings => throw new NotImplementedException();

		public string ServingName => throw new NotImplementedException();


		public ICookBook Parent { get;  set; }
        CultureInfo IRecipe.Culture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IRecipe.Servings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IRecipe.ServingName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
