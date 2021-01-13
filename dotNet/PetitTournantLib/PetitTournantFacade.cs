using PetitTournant.Lib.Implementation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace PetitTournant.Lib
{
    public class PetitTournantFacade
    {
        public List<string> SupportedCookBookFormats { get; private set; }

        public PetitTournantFacade()
        {
            this.SupportedCookBookFormats = new List<string> { "cookbook" };

            List<IDiet> knownDiets = new List<IDiet>();
            foreach(var d in DietManager.Diets)
            {
                knownDiets.Add(new Diet(d));
            }
            this.KnownDiets = knownDiets;
        }

        public ICookBook LoadCookBookFromFileStream(Stream File)
        {
            var archive = new System.IO.Compression.ZipArchive(File);
            return null;
        }
        public ICookBook LoadCookBookFromFolder(string path)
        {
            return null;
        }
        public ICookBook CreateCookBook(string name, CultureInfo culture, string path)
        {
            return new Implementation.CookBook(name, path, culture);
        }
        public ICookBook GetEmptyCookBook()
        {
            return new Implementation.CookBook();
        }
        public IRecipe CreateNewRecipe(string name, CultureInfo culture, List<Tuple<decimal, string, string>> ingredients, List<IDiet> diets, string steps, TimeSpan Preperation, TimeSpan CookingTime, TimeSpan RestingTime)
        {
            return new Implementation.Recipe(name, culture, ingredients, diets, steps, Preperation, CookingTime, RestingTime);
        }

        public List<IDiet> KnownDiets { get; private set; }
        public IRecipe GetEmptyRecipe() { return new Recipe(); }
    }
}
