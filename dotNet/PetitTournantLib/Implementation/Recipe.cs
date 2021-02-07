using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PetitTournant.Lib.Implementation
{
    class Recipe : IRecipe, IAsyncInitialization, IPathRefrencer
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

        public Task Initialization { get; private set; }
        private async Task InitializeAsync(ICookBookFile File, CancellationToken token)
        {
            if (!File.Content.CanSeek)
            {
                throw new Exception("");
            }
            string recipeFile = null;
            using (StreamReader sr = new StreamReader(File.Content))
            {
                recipeFile = await sr.ReadToEndAsync().ConfigureAwait(false);
            }
            if(recipeFile == null)
            {
                throw new IOException("File content was null:" + File.FullName);
            }
            token.ThrowIfCancellationRequested();

            await ParseFile(recipeFile);
        }
        private async Task ParseFile(string fileContent)
        {

        }
        public Recipe(ICookBookFile File, CancellationToken token) => this.Initialization = InitializeAsync(File, token);

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

        public List<string> RefrencedPaths => throw new NotImplementedException();

        public List<string> GetRefrences()
        {
            throw new NotImplementedException();
        }
    }
}
