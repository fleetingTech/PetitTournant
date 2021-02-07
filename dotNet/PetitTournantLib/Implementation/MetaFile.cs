using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PetitTournant.Lib.Implementation
{
    class MetaFile : IAsyncInitialization
    {
        List<string> RecipeNames;
        string VersionString;
        internal  string Description;
        internal string DisplayImagePath;
        string CookBookname;
        ICookBookFile File;
        public MetaFile(ICookBookFile f, System.Threading.CancellationToken token)
        {
            this.Initialization = InitializeAsync(f, token);
        }
        private async Task InitializeAsync(ICookBookFile File, CancellationToken token)
        {
            this.File = File;
            token.ThrowIfCancellationRequested();

            string metaContent = null;
            using (StreamReader sr = new StreamReader(File.Content))
            {
                metaContent = await sr.ReadToEndAsync().ConfigureAwait(false);
            }
            token.ThrowIfCancellationRequested();

            await ParseFile(metaContent, token);
        }

        private static string versionKey = "format-version:";

        private async Task ParseFile(string fileContent, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            string[] lines = fileContent.Split(new [] { "\r\n", "\n" }, StringSplitOptions.None);

            //First line is the display name of the book
            this.CookBookname = lines[0];
            int index = 0;
            if(Utils.StringArray.ParseStringForKeyValue(lines, versionKey, ref index, out this.VersionString) == false)
            {
                throw new Exception("Malformed Metafile");
            }

            if(this.VersionString == "1.0")
            {
                MetaFileLoader.V1_0 loader = new MetaFileLoader.V1_0();
                await Task.Run(() => loader.ParseFileAsync(this, lines, index, token));
            }
            else
            {
                throw new Exception("Unknown Version:" + this.VersionString);
            }
        }
      
        public Task Initialization { get; private set; }
    }
}
