using System;
using System.Collections.Generic;
using System.Text;

namespace PetitTournant.Core
{
    public interface ICookBook
    {
        string Name { get; }
        string Path { get; }
        string ImagePath { get; }
    }
}
