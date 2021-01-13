using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;

namespace PetitTournant.Lib
{
    public enum DietType
    {
        VeganType,
        VegetarianType,
        KetoType,
        OvoLactoType
    }

    public interface IDiet
    {
        DietType Type {get; }
        string GetLocalisedName(CultureInfo culture);
    }
}
