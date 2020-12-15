using System;
using System.Linq;
using System.Threading;
using OctopusWorld.FishFactories;
using OctopusWorld.Models.FishFood;

namespace OctopusWorld
{
    class Program
    {
        static void Main()
        {
            var pacificFishFactory = new PacificFishFactory();
            var pacificThemedAquarium = new Aquarium(pacificFishFactory.CreateStingRay(), pacificFishFactory.CreateMarlin());

            var fishFoodManufacturer = new FishFoodManufacturer();

            var initialFishFoodInventory = fishFoodManufacturer.CreateFishFood<Snail>(3)
                .Concat(fishFoodManufacturer.CreateFishFood<Mackerel>(5)).ToList();

            var fishFoodInventory = new FishFoodInventory(initialFishFoodInventory);

            var observableFishFoodInventory = new ObservableFishFoodInventory(fishFoodInventory);
            var pacificFishFeeder = new FishFeeder(pacificThemedAquarium, observableFishFoodInventory);
            var fishFoodReplenisher = new FishFoodInventoryReplenisher(fishFoodManufacturer);
            observableFishFoodInventory.InventoryChanged += fishFoodReplenisher.InventoryUpdated;

            while (true)
            {
                pacificFishFeeder.FeedFishes();
                Console.WriteLine(fishFoodInventory);
                Thread.Sleep(1000);
            }
        }
    }

    // builder.WithSnails(5).WithMackerel(5).Build();
}