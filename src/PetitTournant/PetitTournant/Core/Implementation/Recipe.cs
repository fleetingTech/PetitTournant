using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetitTournant.Core
{
    class Recipe : IRecipe
    {
        public Recipe(string name, CultureInfo culture, List<string> ingredients, List<DietType> diets, List<string> steps, TimeSpan preperation, TimeSpan cookingTime, TimeSpan restingTime)
        {
            this.Name = name;
            this.culture = culture;
            this.Ingredients = Ingredients;
            this.steps = steps;
            this.PreperationTime = preperation;
            this.CookingTime = cookingTime;
            this.RestingTime = restingTime;
        }
        public Recipe() { }

        public string Name { get;  set; }

        public CultureInfo culture { get; private set; }

        public List<string> Ingredients { get; private set; }

        public List<DietType> Diets { get; private set; }

        public List<string> steps { get; private set; }

        public TimeSpan PreperationTime { get; private set; }

        public TimeSpan CookingTime { get; private set; }

        public TimeSpan RestingTime { get; private set; }

        public TimeSpan TotalTime { get { return PreperationTime + CookingTime + RestingTime; } }

		public int servings => throw new NotImplementedException();

		public string servingName => throw new NotImplementedException();

		List<Tuple<decimal, string, string>> IRecipe.Ingredients => throw new NotImplementedException();

		public ICookBook Parent { get;  set; }
	}
}
