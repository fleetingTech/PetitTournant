namespace PetitTournant.Lib.Implementation
{
    internal class Knowledge : IKnowledge
    {
        private ICookBookFile f;

        public Knowledge(ICookBookFile f)
        {
            this.f = f;
        }
    }
}