using System.Collections.Generic;
using System.Linq;

namespace AntiAquarium
{
    public class FishFoodInventory
    {
        private readonly List<IFishFood> fishFoods;

        public FishFoodInventory(List<IFishFood> fishFoods)
        {
            this.fishFoods = fishFoods;
        }

        public void Add(IFishFood fishFood)
        {
            fishFoods.Add(fishFood);
        }

        public void Take<T>() where T : IFishFood
        {
            var food = fishFoods.First(f => f is T);
            fishFoods.Remove(food);
        }
    }
}