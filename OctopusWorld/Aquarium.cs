using System.Collections.Generic;
using OctopusWorld.FishFactories;
using OctopusWorld.Models.Fish;

namespace OctopusWorld
{
    public class Aquarium : IAquarium
    {
        private readonly IStingRay stingRay;
        private readonly IMarlin marlin;

        public Aquarium(ICreateFish fishFactory)
        {
            stingRay = fishFactory.CreateStingRay();
            marlin = fishFactory.CreateMarlin();
        }

        public List<IFish> GetFishes()
        {
            return new List<IFish>
            {
                stingRay, marlin
            };
        }
    }

    public interface IAquarium
    {
        List<IFish> GetFishes();
    }
}