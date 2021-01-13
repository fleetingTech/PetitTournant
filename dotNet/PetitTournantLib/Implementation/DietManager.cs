using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;

namespace PetitTournant.Lib.Implementation
{
    static class DietManager
    {

        private static Dictionary<string, Dictionary<string, DietType>> dietFromStringLookUp = new Dictionary<string, Dictionary<string, DietType>>();
        private static Dictionary<string, Dictionary<DietType, string>> stringFromDietLookUp = new Dictionary<string, Dictionary<DietType, string>>();
        private static List<string> culturesInLookUp = new List<string>();

        private static ResourceManager resourceManager = new ResourceManager("PetitTournant.Lib.Localisation.DietType", typeof(Diet).Assembly);

        private static string GetKeyFromCulture(CultureInfo culture)
        {
            return culture.ThreeLetterISOLanguageName;
        }
        private static bool LoadLanguage(CultureInfo culture)
        {
            string key = GetKeyFromCulture(culture);
            if (culturesInLookUp.Contains(key))
            {
                return true;
            }
            try
            {
                var localisedDiet = resourceManager.GetResourceSet(culture, true, false);
                Dictionary<string, DietType> strToType = new Dictionary<string, DietType>();
                Dictionary<DietType, string> typeToStr = new Dictionary<DietType, string>();

                foreach (var type in Diets)
                {
                    var localisedName = localisedDiet.GetString(type.ToString());

                    strToType.Add(localisedName, type);
                    typeToStr.Add(type, localisedName);
                }
                key = GetKeyFromCulture(culture);
                dietFromStringLookUp.Add(key, strToType);
                stringFromDietLookUp.Add(key, typeToStr);
            }
            catch (Exception)
            {
                return false;
            }
            culturesInLookUp.Add(key);
            return true;
        }
        public static string LocalisedString(CultureInfo culture, DietType type)
        {
            string langKey = GetKeyFromCulture(culture);
            string result = null;

            if (culturesInLookUp.Contains(langKey) == false)
            {
                if (LoadLanguage(culture))
                {
                    throw new ArgumentException("Language " + langKey + "not supported");
                }
            }
            Dictionary<DietType, string> lookUp = null;
            bool gotLang = stringFromDietLookUp.TryGetValue(langKey, out lookUp);
            if (gotLang == false)
            {
                //loader could load the lang, should not be reachable.
                throw new Exception("?");
            }
            bool gotString = lookUp.TryGetValue(type, out result);
            if (!gotString)
            {
                throw new ArgumentException("diet <" + type.ToString() + "> in lang:" + langKey + " not found");
            }
            return result;
        }
        public static DietType TypeFromString(string dietstring, CultureInfo culture)
        {
            string langKey = GetKeyFromCulture(culture);
            DietType result;

            if (culturesInLookUp.Contains(langKey) == false)
            {
                if (LoadLanguage(culture))
                {
                    throw new ArgumentException("Language " + langKey + "not supported");
                }
            }

            Dictionary<string, DietType> lookUp = null;
            bool gotLang = dietFromStringLookUp.TryGetValue(langKey, out lookUp);
            if (gotLang == false)
            {
                //loader could load the lang, should not be reachable.
                throw new Exception("?");
            }

            bool gotType = lookUp.TryGetValue(dietstring, out result);
            if (!gotType)
            {
                throw new ArgumentException("diet <" + dietstring + "> in lang:" + langKey + " not found");
            }
            return result;
        }

        public static DietType[] Diets { get => (DietType[])Enum.GetValues(typeof(DietType));}
    }
}
