using System;
using System.Collections.Generic;
using System.Linq;
using OctopusWorld.Models.FishFood;

namespace OctopusWorld
{
    public class FishFoodManufacturer : IFishFoodManufacturer
    {

        public List<IFishFood> CreateFishFood<T>(int number) where T: IFishFood
        {
            return CreateFishFood(number, typeof(T));
        }

        public List<IFishFood> CreateFishFood(int number, FishFoodType foodType)
        {
            return CreateFishFood(number, foodType.Type);
        }

        private static List<IFishFood> CreateFishFood(int number, Type type)
        {
            IFishFood CreateFishFoodOfType()
            {
                return type switch
                {
                    var t when t == typeof(Snail) => new Snail(),
                    var t when t == typeof(Mackerel) => new Mackerel(),
                    _ => throw new Exception("Could not figure out the type of fish food to create")
                };
            }

            return Enumerable.Range(0, number).Select(i => CreateFishFoodOfType()).ToList();
        }
    }

    public interface IFishFoodManufacturer
    {
        List<IFishFood> CreateFishFood<T>(int number) where T : IFishFood;
        List<IFishFood> CreateFishFood(int number, FishFoodType foodType);
    }

    public class FishFoodType
    {
        public Type Type { get; }

        public FishFoodType(Type foodType)
        {
            if (!typeof(IFishFood).IsAssignableFrom(foodType))
            {
                throw new ArgumentException("Cannot construct a fish food type from a type that is not fish food!");
            }

            Type = foodType;
        }
    }
}