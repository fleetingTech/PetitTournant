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
    }
}
