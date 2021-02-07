using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace PetitTournant.Lib.Implementation
{
    internal class CookBook : ICookBook, IAsyncInitialization
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string ImagePath { get; set; }

        public CultureInfo Culture { get; set; }

        public List<IRecipe> Recipes { get; } = new List<IRecipe>();

        private MetaFile _metaFile = null;
        public MetaFile MetaFile
        {
            get => _metaFile;
            internal set
            {
                IsMetaFileOutOfSync = ValidateMetaFileAgainstData(value);
                _metaFile = value;
            }
        }
        public bool IsMetaFileOutOfSync { get; internal set; }

        public Task Initialization { get; private set; }

        public void AddRecipe(IRecipe rep)
        {
            Recipes.Add(rep);
        }

        public CookBook(string Name, string path, CultureInfo culture)
        {
            this.Name = Name;
            Path = path;
            Culture = culture;
        }

        internal void AddRecipe(ICookBookFile f)
        {
            AddRecipe(new Recipe(f));
        }

        internal static async Task<CookBook> Load(Mediamanger mm, CancellationToken token)
        {
            await mm.Initialization.ConfigureAwait(false);

        }

        public CookBook()
        {
            Name = string.Empty;
            Path = string.Empty;
            ImagePath = string.Empty;
            Culture = null;
        }

        internal void AddKnowledge(ICookBookFile f)
        {
            throw new NotImplementedException();
        }

        private bool ValidateMetaFileAgainstData(MetaFile mf)
        {
            return false;
        }
    }
}
