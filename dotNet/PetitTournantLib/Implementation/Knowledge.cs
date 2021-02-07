using System.Threading.Tasks;

namespace PetitTournant.Lib.Implementation
{
    internal class Knowledge : IKnowledge, IAsyncInitialization
    {
        private ICookBookFile f;

        public Knowledge(ICookBookFile f, System.Threading.CancellationToken token)
        {
            this.f = f;
        }

        public Task Initialization { get; private set; }
    }
}