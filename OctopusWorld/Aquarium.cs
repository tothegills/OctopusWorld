using System.Collections.Generic;
using OctopusWorld.Models.Fish;

namespace OctopusWorld
{
    public class Aquarium
    {
        private readonly IStingRay stingRay;
        private readonly IMarlin marlin;

        public Aquarium(IStingRay stingRay, IMarlin marlin)
        {
            this.stingRay = stingRay;
            this.marlin = marlin;
        }

        public List<IFish> GetFishes()
        {
            return new List<IFish>
            {
                stingRay, marlin
            };
        }
    }
}