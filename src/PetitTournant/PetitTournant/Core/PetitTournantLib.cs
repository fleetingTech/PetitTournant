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
            return new Implementation.CookBook(name, path, culture);
        }
        public ICookBook GetEmptyCookBook()
        {
            return new Implementation.CookBook();
        }
        public IRecipe CreateNewRecipe(string name, CultureInfo culture, List<Tuple<decimal, string, string>> ingredients, List<DietType> diets, string steps, TimeSpan Preperation, TimeSpan CookingTime, TimeSpan RestingTime)
        {
            return new Recipe(name, culture, ingredients, diets, steps, Preperation, CookingTime, RestingTime);
        }
        private DietType getTypeFromString(string str, CultureInfo culture)
        {
            if (CultureInfo.CurrentCulture != culture)
            {
                throw new ArgumentException("differing cultures are not supported yet");
            }
            if (str == Localisation.StringLocalisation.VeganDietName)
            {
                return DietType.Vegan;
            }
            else if (str == Localisation.StringLocalisation.VegetarienDietName)
            {
                return DietType.Vegetarian;
            }
            else if (str == Localisation.StringLocalisation.KetoDietName)
            {
                return DietType.Keto;
            }
            else
            {
                throw new ArgumentException("Unknown Diet:" + str);
            }

        }
        public string GetStringForDietType(DietType type, CultureInfo culture)
        {
            if(CultureInfo.CurrentCulture != culture)
            {
                throw new ArgumentException("differing cultures are not supported yet");
            }
            switch (type)
            {
                case DietType.Vegan:
                    return Localisation.StringLocalisation.VeganDietName;
                case DietType.Vegetarian:
                    return Localisation.StringLocalisation.VegetarienDietName;
                case DietType.Keto:
                    return Localisation.StringLocalisation.KetoDietName;
                default:
                    throw new ArgumentException("The given enum value is not part of the switch case yet");
            }
        }
        public IRecipe GetEmptyRecipe() { return new Recipe(); }
    }
}
