using System;
using System.Threading;

namespace PetitTournant.Utils
{
    public static class StringArray
    {
        public static bool ParseStringForKeyValue(string[] src, string key, ref int index, out string value)
        {
            if (index >= src.Length || index < 0)
            {
                throw new ArgumentException("index is out of bounds");
            }
            for (int counter = index; counter < src.Length; counter++)
            {
                if (src[counter].Contains(key))
                {
                    value = src[counter].Substring(src[counter].IndexOf(key) + key.Length);
                    index = counter + 1;
                    return true;
                }
            }
            value = string.Empty;
            return false;
        }

        public static bool FindNextEmptyIndex(string[] src, ref int index, CancellationToken token)
        {
            for (int counter = index; counter <= src.Length; counter++)
            {
                token.ThrowIfCancellationRequested();
                if (string.IsNullOrWhiteSpace(src[counter]))
                {
                    index = counter;
                    return true;
                }
            }
            return false;
        }
    }
}
