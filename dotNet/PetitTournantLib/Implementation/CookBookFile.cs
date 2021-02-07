using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace PetitTournant.Lib.Implementation
{
    internal class CookBookFile : ICookBookFile, IDisposable
    {
        public string FullName { get; }
        public string Extension { get; }
        private Stream _content;
        private string file;
        public Stream Content
        {
            get
            {
                if (_content == null)
                {
                    _content = GetStream();
                }
                return _content;
            }
        }

        private int _refrenceCount = 0;
        public int RefrenceCount => _refrenceCount;

        private ZipArchiveEntry Source;
        private bool disposedValue;

        private Stream GetStream()
        {
            if (Source != null)
            {
                return Source.Open();
            }
            else
            {
                return File.Open(file, FileMode.Open);
            }
        }
        public CookBookFile(ZipArchiveEntry entry)
        {
            this.FullName = entry.FullName;
            this.Extension = GetFileExtension();
            this.Source = entry;
        }
        public CookBookFile(string file)
        {
            this.Extension = GetFileExtension();
            this.FullName = Path.GetFileName(file);
            this.Source = null;
        }
        private string GetFileExtension()
        {
            string ext = Path.GetExtension(this.FullName);
            return ext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _content.Flush();
                    _content.Close();
                    _content = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CookBookFile()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void IncrementRefrence()
        {
            _refrenceCount++;
        }
    }
}
