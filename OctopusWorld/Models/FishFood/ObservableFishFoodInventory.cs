using System;
using System.Collections.Generic;
using OctopusWorld.Models.Fish;

namespace OctopusWorld.Models.FishFood
{
    public class InventoryUpdatedEventArgs
    {
        public IFishFoodInventory FishFoodInventory { get; }

        public InventoryUpdatedEventArgs(IFishFoodInventory fishFoodInventory)
        {
            FishFoodInventory = fishFoodInventory;
        }
    }
    public class ObservableFishFoodInventory : IFishFoodInventory
    {
        private readonly IFishFoodInventory decorated;

        public event EventHandler<InventoryUpdatedEventArgs> InventoryChanged;

        public ObservableFishFoodInventory(IFishFoodInventory decorated, IList<IHandleFishFoodInventoryEvents> observers)
        {
            this.decorated = decorated;

            foreach (var observer in observers)
            {
                InventoryChanged += observer.InventoryUpdated;
            }
        }

        public IFishFood Take(FavoriteFood typeOfFishFood)
        {
            var taken = decorated.Take(typeOfFishFood);
            InventoryChanged?.Invoke(this, new InventoryUpdatedEventArgs(this));
            return taken;
        }

        public IReadOnlyCollection<IFishFood> ShowInventoryContents()
        {
            return decorated.ShowInventoryContents();
        }

        public void Add(List<IFishFood> fishFood)
        {
            decorated.Add(fishFood);
        }

        public override string ToString()
        {
            return decorated.ToString();
        }
    }
}