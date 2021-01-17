using System;
using System.Collections.Generic;
using System.Text;

namespace PetitTournant.Lib
{
    interface ICookBookLoader
    {

        ICookBook loadICookBookFromFiles(List<ICookBookFile> Files);
        IRecipe LoadRecipeFromFile(ICookBookFile File);
        IKnowledge LoadKnowledgeFromFile(ICookBookFile File);
    }
}
