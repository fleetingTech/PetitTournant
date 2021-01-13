using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetitTournant.Lib.Implementation
{
    class Diet : IDiet
    {
        public DietType Type { get; private set; }
        public string GetLocalisedName(CultureInfo culture)
        {
            return DietManager.LocalisedString(culture, this.Type);
        }
        public Diet(DietType type)
        {
            this.Type = type;
        }
    }
}
