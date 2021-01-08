using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace PetitTournant.Core
{
    class PetitTournantLib
    {
        public List<string> SupportedCookBookFormats { get; private set; }

        public PetitTournantLib()
        {
            this.SupportedCookBookFormats = new List<string> { "cookbook" };
        }

        public ICookBook LoadCookBookFromStream(Stream File)
        {
            var archive = new System.IO.Compression.ZipArchive(File);
            return null;
        }
        public ICookBook CreateCookBook(string name, CultureInfo culture, string path)
        {
            return new CookBook(name, path, culture);
        }
        public IRecipe CreateNewRecipe(string name, CultureInfo culture, List<string> ingredients, List<DietType> diets, List<string> steps, TimeSpan Preperation, TimeSpan CookingTime, TimeSpan RestingTime)
        {

            return new Recipe(name, culture, ingredients, diets, steps, Preperation, CookingTime, RestingTime);
        }
        public DietType getTypeFromString(string str, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public string GetStringForDietType(DietType type, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
