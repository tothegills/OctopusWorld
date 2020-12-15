using OctopusWorld.Models.Fish;

namespace OctopusWorld.FishFactories
{
    public class AtlanticFishFactory
    {
        public IStingRay CreateStingRay()
        {
            return new AtlanticStingRay();
        }

        public IMarlin CreateMarlin()
        {
            return new WhiteMarlin();
        }
    }
}