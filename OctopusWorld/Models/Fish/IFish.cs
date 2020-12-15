using System;
using System.Collections.Generic;
using OctopusWorld.Models.FishFood;

namespace OctopusWorld.Models.Fish
{
    public interface IFish
    {
        void Feed(IFishFood fishFood);
        IEnumerable<FavoriteFood> WhatTypeOfFoodDoYouEat();
    }
}