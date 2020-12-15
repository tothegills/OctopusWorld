using System.Collections.Generic;
using OctopusWorld.Models.FishFood;

namespace OctopusWorld.Models.Fish
{
    public class BlackMarlin : IMarlin
    {
        public void Feed(IFishFood fishFood)
        {
        }

        public IEnumerable<FavoriteFood> WhatTypeOfFoodDoYouEat()
        {
            yield return new FavoriteFood<Mackerel>();
        }
    }
}