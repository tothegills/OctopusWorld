using System.Collections.Generic;
using OctopusWorld.Models.Fish;
using OctopusWorld.Models.FishFood;

namespace OctopusWorld
{
    public class FishFeeder
    {
        private List<IFish> fishes;
        private IFishFoodInventory fishFoodInventory;

        public FishFeeder(List<IFish> fishes, IFishFoodInventory fishFoodInventory)
        {
            this.fishes = fishes;
            this.fishFoodInventory = fishFoodInventory;
        }

        public FishFeeder(Aquarium aquarium, IFishFoodInventory fishFoodInventory)
        {
            fishes = aquarium.GetFishes();
            this.fishFoodInventory = fishFoodInventory;
        }

        public void FeedFishes()
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
}