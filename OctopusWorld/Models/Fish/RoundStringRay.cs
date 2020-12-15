using System.Collections.Generic;
using OctopusWorld.Models.FishFood;

namespace OctopusWorld.Models.Fish
{
    public class RoundStringRay : IStingRay
    {
        public void Feed(IFishFood fishFood)
        {
        }

        public IEnumerable<FavoriteFood> WhatTypeOfFoodDoYouEat()
        {
            yield return new FavoriteFood<Snail>();
        }
    }
}