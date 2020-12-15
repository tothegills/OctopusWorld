using System.Collections.Generic;
using System.Linq;

namespace AntiAquarium
{
    public class PacificThemedAquarium
    {
        public BadBlackMarlin BlackMarlin;
        public BadRoundStringRay RoundStringRay;

        public PacificThemedAquarium()
        {
            BlackMarlin = new BadBlackMarlin();
            RoundStringRay = new BadRoundStringRay();
        }
    }

    public class BadRoundStringRay
    {
    }

    public class BadBlackMarlin
    {
    }

    class AtlanticThemedAquarium
    {
        public BadWhiteMarlin WhiteMarlin;
        public BadAtlanticStingRay AtlanticStingRay;

        public AtlanticThemedAquarium()
        {
            WhiteMarlin = new BadWhiteMarlin();
            AtlanticStingRay = new BadAtlanticStingRay();
        }

    }

    class BadAquarium
    {
        private List<IFish> Fishes;
        private List<IFishFood> FishFoods;

        public void FeedTheFishes()
        {
            foreach (var fish in Fishes)
            {
                if (fish is IStingRay)
                {
                    var fishFood = FishFoods.First(food => food is Snail);
                    FishFoods.Remove(fishFood);
                }

                if (fish is IMarlin)
                {
                    var fishFood = FishFoods.First(food => food is Mackerel);
                    FishFoods.Remove(fishFood);
                }
            }
        }
    }

    public class Snail : IFishFood
    {
    }

    public class Mackerel : IFishFood
    {
    }

    internal class BadAtlanticStingRay
    {
    }

    internal class BadWhiteMarlin
    {
    }

    public class SeaWorld
    {
        public void MakeAquarium()
        {
            var aquarium = new AtlanticThemedAquarium();
        }
    }
}