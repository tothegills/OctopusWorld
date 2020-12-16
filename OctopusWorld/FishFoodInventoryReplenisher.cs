using System.Linq;
using OctopusWorld.Models.FishFood;

namespace OctopusWorld
{
    public class FishFoodInventoryReplenisher : IReplenishFishFood, IHandleFishFoodInventoryEvents
    {
        private IFishFoodManufacturer fishFoodManufacturer;

        public FishFoodInventoryReplenisher(IFishFoodManufacturer fishFoodManufacturer)
        {
            this.fishFoodManufacturer = fishFoodManufacturer;

        }

        public void InventoryUpdated(object sender, InventoryUpdatedEventArgs e)
        {
            var inventory = e.FishFoodInventory;
            var inventoryItemsRunningLow = inventory.ShowInventoryContents()
                .GroupBy(fishFood => fishFood.GetType())
                .Where(group => group.Count() < 3);

            foreach (var inventoryType in inventoryItemsRunningLow)
            {
                var newFood = fishFoodManufacturer.CreateFishFood(5, new FishFoodType(inventoryType.Key));

                inventory.Add(newFood);
            }
        }
    }

    public interface IReplenishFishFood
    {
    }

    public interface IHandleFishFoodInventoryEvents
    {
        void InventoryUpdated(object sender, InventoryUpdatedEventArgs e);
    }
}