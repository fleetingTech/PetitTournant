using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace PetitTournant.Lib.Implementation
{
    class Mediamanger : IAsyncInitialization
    {
        private ZipArchive archive = null;
        private string sourceFolder = null;

        public List<ICookBookFile> Files { get; private set; } = new List<ICookBookFile>();

        public Dictionary<string, IRecipe> Recipes { get; private set; } = new Dictionary<string, IRecipe>();
        public Dictionary<string, IKnowledge> Knowledge { get; private set; } = new Dictionary<string, IKnowledge>();
        public Dictionary<string, ICookBookFile> AllOtherFiles { get; private set; } = new Dictionary<string, ICookBookFile>();
        public MetaFile MF { get; private set; } = null;

        public Task Initialization { get; private set; }

        public Mediamanger(ZipArchive archive, CancellationToken token)
        {
            this.archive = archive;
            var list = new List<ICookBookFile>();

            List<ZipArchiveEntry> uae = new List<ZipArchiveEntry>(archive.Entries);

            
            Initialization = Initialize(uae, token);
        }

        public Mediamanger(string path, CancellationToken token)
        {
            this.sourceFolder = path;
            string[] files = Directory.GetFiles(path);

            List<string> fileList = new List<string>(files);
            Initialization = Initialize(fileList, token);

        }

        private async Task Initialize(List<string> paths, CancellationToken token)
        {
            Task[] inits = paths.Select(p => CreateSpecificType(new CookBookFile(p), token)).ToArray();



            await Task.WhenAll(inits).ConfigureAwait(false);
        }

        private async Task Initialize(List<ZipArchiveEntry> entries, CancellationToken token)
        {
            Task[] inits = entries.Select(p => CreateSpecificType(new CookBookFile(p), token)).ToArray();



            await Task.WhenAll(inits).ConfigureAwait(false);
        }
        private const string MetaExtension = ".bookmeta";
        private Task CreateSpecificType(CookBookFile file, CancellationToken token)
        {

                switch (file.Extension)
                {
                    case PetitTournantFacade.RecipeExtension:
                        {
                            Recipe r = new Recipe(file, token);
                            Recipes.Add(file.FullName, r);
                            return r.Initialization;
                        }
                    case PetitTournantFacade.KnowledgeExtension:
                        {
                            Knowledge k = new Knowledge(file, token);
                            Knowledge.Add(file.FullName, k);
                            return k.Initialization;
                        }
                    case MetaExtension:
                        {
                            if (this.MF != null)
                            {
                                throw new Exception("More then one metafile is present.");
                            }
                            this.MF = new MetaFile(file, token);
                            return this.MF.Initialization;
                        }
                    default:
                        {
                            AllOtherFiles.Add(file.FullName, file);
                            return null;
                        }
                }

            }
    }
}
