using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PetitTournant.Lib
{
    internal interface ICookBookFile
    {
        string FullName { get; }
        Stream Content { get; }
        string Extension { get; }
        void IncrementRefrence();
        int RefrenceCount { get; }
    }
}
