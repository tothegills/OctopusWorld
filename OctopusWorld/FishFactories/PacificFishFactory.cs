using OctopusWorld.Models.Fish;

namespace OctopusWorld.FishFactories
{
    public class PacificFishFactory : ICreateFish
    {
        public IStingRay CreateStingRay()
        {
            return new RoundStringRay();
        }

        public IMarlin CreateMarlin()
        {
            return new BlackMarlin();
        }
    }
}