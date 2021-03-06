﻿using PetitTournant.Lib.Implementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PetitTournant.Lib
{
    public class PetitTournantFacade
    {
        public const string RecipeExtension = ".recipe";
        public const string KnowledgeExtension = ".knowledge";
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

        public async Task<ICookBook> LoadCookBookFromFileStream(Stream File, CancellationToken token)
        {
            if(File == null)
            {
                throw new IOException("Invalid path (Directory not found)");
            }
            var archive = new System.IO.Compression.ZipArchive(File);

            Mediamanger mm = new Mediamanger(archive, token);

            return await CookBook.Load(mm, token);
        }
        public async Task<ICookBook> LoadCookBookFromFolder(string path, CancellationToken token)
        {
            if(!Directory.Exists(path))
            {
                throw new IOException("Invalid path (Directory not found)");
            }

            Mediamanger mm = new Mediamanger(path, token);
            return await CookBook.Load(mm, token);
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
