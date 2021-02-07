using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PetitTournant.Lib.Implementation.MetaFileLoader
{
    class V1_0
    {
        private static string descriptionKey = "Description:";
        private static string displayImagePathKey = "Display-Image-Path:";
        private static string recipeKey = "Recipies:";
        private static string knowledgeKey = "Knowledge:";

        private void ParseMetaRecipes(IReadOnlyCollection<string> recipes, CancellationToken token)
        {
            foreach (var r in recipes)
            {
                token.ThrowIfCancellationRequested();

            }
        }
        private void ParseMetaKnowledge(IReadOnlyCollection<string> knowledge, CancellationToken token)
        {
            foreach (var k in knowledge)
            {
                token.ThrowIfCancellationRequested();

            }
        }
        public async Task ParseFileAsync(MetaFile mf, string[] lines, int index, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            //next block is the description
            string tmp;
            if (Utils.StringArray.ParseStringForKeyValue(lines, descriptionKey, ref index, out tmp) == false)
            {
                //no description;
                mf.Description = string.Empty;
            }
            else
            {
                //next empty line is the delimiter
                int nextEmpty = 0;
                if (!Utils.StringArray.FindNextEmptyIndex(lines, ref nextEmpty, token))
                {
                    throw new Exception("Malformed Metafile");
                }
                //delimiter found
                mf.Description = string.Join(Environment.NewLine, new ArraySegment<string>(lines, index, nextEmpty - index));
                index = nextEmpty;
            }

            token.ThrowIfCancellationRequested();
            if (Utils.StringArray.ParseStringForKeyValue(lines, displayImagePathKey, ref index, out tmp) == false)
            {
                mf.DisplayImagePath = null;
            }
            else
            {
                mf.DisplayImagePath = tmp;
            }

            token.ThrowIfCancellationRequested();
            Task[] parseTasks = new Task[2];
            //task1, recipes
            if (Utils.StringArray.ParseStringForKeyValue(lines, recipeKey, ref index, out tmp) == false)
            {
                parseTasks[0] = Task.CompletedTask;
            }
            else
            {
                //next empty line is the delimiter
                int nextEmpty = 0;
                if (!Utils.StringArray.FindNextEmptyIndex(lines, ref nextEmpty, token))
                {
                    throw new Exception("Malformed Metafile");
                }
                //delimiter found
                index++; //first line is the header
                parseTasks[0] = Task.Run(() => ParseMetaRecipes(new ArraySegment<string>(lines, index, nextEmpty - index), token));
                index = nextEmpty;
            }
            token.ThrowIfCancellationRequested();
            //task2, knowledge
            if (Utils.StringArray.ParseStringForKeyValue(lines, knowledgeKey, ref index, out tmp) == false)
            {
                parseTasks[1] = Task.CompletedTask;
            }
            else
            {
                //next empty line is the delimiter
                int nextEmpty = 0;
                if (!Utils.StringArray.FindNextEmptyIndex(lines, ref nextEmpty, token))
                {
                    throw new Exception("Malformed Metafile");
                }
                //delimiter found
                parseTasks[0] = Task.Run(() => ParseMetaKnowledge(new ArraySegment<string>(lines, index, nextEmpty - index), token));
                index = nextEmpty;
            }
            token.ThrowIfCancellationRequested();

            await Task.WhenAll(parseTasks).ConfigureAwait(false);
        }
    }
}
