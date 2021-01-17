using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetitTournant.Lib.Implementation
{
    internal class CookBook : ICookBook
    {
        public string Name { get;  set; }

        public string Path { get;  set; }

        public string ImagePath { get;  set; }

        public CultureInfo Culture { get;  set; }

        public List<IRecipe> Recipes { get; } = new List<IRecipe>();

        private MetaFile _metaFile = null;
        public MetaFile MetaFile 
        { 
            get { return this._metaFile; }
            internal set 
            { 
                this.IsMetaFileOutOfSync = ValidateMetaFileAgainstData(value);
                this._metaFile= value;
            }
        }
        public bool IsMetaFileOutOfSync { get; internal set; }


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

        internal void AddRecipe(ICookBookFile f)
        {
            AddRecipe(new Recipe(f));
        }

        internal static CookBook Load(Mediamanger mm)
        {
            throw new NotImplementedException();
        }

        public CookBook()
        {
            this.Name = string.Empty;
            this.Path = string.Empty;
            this.ImagePath = string.Empty;
            this.Culture = null;
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
