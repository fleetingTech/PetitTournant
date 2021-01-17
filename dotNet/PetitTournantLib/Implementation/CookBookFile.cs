using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace PetitTournant.Lib.Implementation
{
    internal class CookBookFile : ICookBookFile
    {
        public string FullName { get; }
        public string Extension { get; }
        public Stream Content { get; }

        public CookBookFile(ZipArchiveEntry entry)
        {
            this.FullName = entry.FullName;
            this.Content = entry.Open();
            this.Extension = GetFileExtension();
        }
        public CookBookFile(string file)
        {
            this.Extension = GetFileExtension();
            this.FullName = Path.GetFileName(file);
            this.Content = File.Open(file, FileMode.Open);
        }
        private string GetFileExtension()
        {
            string ext = Path.GetExtension(this.FullName);
            return ext;
        }
    }
}
