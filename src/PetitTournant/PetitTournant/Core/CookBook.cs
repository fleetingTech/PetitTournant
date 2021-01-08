using System;
using System.Collections.Generic;
using System.Text;

namespace PetitTournant.Core
{
    class CookBook : ICookBook
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string ImagePath { get; set; }
    }
}
