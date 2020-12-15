using System;
using System.Collections.Generic;
using System.Linq;
using OctopusWorld.Models.Fish;

namespace OctopusWorld.Models.FishFood
{
    public interface IFishFoodInventory
    {
        IFishFood Take(FavoriteFood typeOfFishFood);
        IReadOnlyCollection<IFishFood> ShowInventoryContents();
        void Add(List<IFishFood> fishFood);
    }

    public class FishFoodInventory : IFishFoodInventory
    {
        private List<IFishFood> fishFood;
        public List<IFishFood> FishFood
        {
            get => fishFood;
            set
            {
                if (fishFood == value)
                    return;
                fishFood = value;
            }
        }

        public FishFoodInventory(List<IFishFood> fishFoods)
        {
            FishFood = fishFoods;
        }

        public virtual IFishFood Take(FavoriteFood typeOfFishFood)
        {
            var food = FishFood.FirstOrDefault(f => f.GetType() == typeOfFishFood.Type);
            FishFood.Remove(food);
            return food;
        }

        public IReadOnlyCollection<IFishFood> ShowInventoryContents()
        {
            return fishFood;
        }

        public void Add(List<IFishFood> fishFood)
        {
            FishFood.AddRange(fishFood);
        }

        public override string ToString()
        {
            return string.Join(", ", fishFood.Select(food => food.GetType().Name));
        }
    }
}