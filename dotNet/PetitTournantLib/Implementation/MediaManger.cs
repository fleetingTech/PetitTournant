using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace PetitTournant.Lib.Implementation
{
    class Mediamanger
    {
        private ZipArchive archive = null;
        private string sourceFolder = null;

        public List<ICookBookFile> Files { get; private set; } = new List<ICookBookFile>();

        public List<IRecipe> Recipes { get; private set; } = new List<IRecipe>();
        public List<IKnowledge> Knowledge { get; private set; } = new List<IKnowledge>();
        public Dictionary<string, ICookBookFile> AllOtherFiles { get; private set; } = new Dictionary<string, ICookBookFile>();
        public MetaFile MF { get; private set; } = null;

        public Mediamanger(ZipArchive archive)
        {
            this.archive = archive;
            var list = new List<ICookBookFile>();

            List<ZipArchiveEntry> uae = new List<ZipArchiveEntry>(archive.Entries);

            uae.ForEach(e => { list.Add(new CookBookFile(e)); });
            BuildIndex();
        }

        public Mediamanger(string path)
        {
            this.sourceFolder = path;
            string[] files = Directory.GetFiles(path);

            List<string> fileList = new List<string>(files);
            fileList.ForEach(e => { SortFile(new CookBookFile(e)); });
            BuildIndex();
        }

        private void BuildIndex()
        {
            foreach(var r in Recipes)
            {
                List<string> refs = r.GetRefrences();
                foreach(var rf in refs)
                {
                    AllOtherFiles[rf].IncrementRefrence();
                }
            }
            foreach (var k in Knowledge)
            {
                List<string> refs = k.GetRefrences();
                foreach (var rf in refs)
                {
                    AllOtherFiles[rf].IncrementRefrence();
                }
            }
        }


        private const string MetaExtension = ".bookmeta";

        private void SortFile(ICookBookFile File)
        {
            this.Files.Add(File);

            switch (File.Extension)
            {
                case PetitTournantFacade.RecipeExtension:
                    {
                        Recipes.Add(new Recipe(File));
                        break;
                    }
                case PetitTournantFacade.KnowledgeExtension:
                    {
                        Knowledge.Add(new Knowledge(File));
                        break;
                    }
                case MetaExtension:
                    {
                        if (this.MF != null)
                        {
                            throw new Exception("More then one metafile is present.");
                        }
                        this.MF = new MetaFile(File);
                        break;
                    }
                default:
                    {
                        AllOtherFiles.Add(File.FullName, File);
                        break;
                    }
            }
        }
    }
}
