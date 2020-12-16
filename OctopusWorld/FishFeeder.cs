using System.Collections.Generic;
using OctopusWorld.Models.Fish;
using OctopusWorld.Models.FishFood;

namespace OctopusWorld
{
    public class FishFeeder : IFeedFish
    {

        private IFishFoodInventory fishFoodInventory;

        public FishFeeder(IFishFoodInventory fishFoodInventory)
        {
            this.fishFoodInventory = fishFoodInventory;
        }

        public void FeedFishes(List<IFish> fishes)
        {
            foreach (var fish in fishes)
            {
                var favoriteFoods = fish.WhatTypeOfFoodDoYouEat();
                foreach (var favoriteFood in favoriteFoods)
                {
                    var foodFromInventory = fishFoodInventory.Take(favoriteFood);
                    fish.Feed(foodFromInventory);
                }
            }
        }
    }

    public interface IFeedFish
    {
        void FeedFishes(List<IFish> fishes);
    }
}