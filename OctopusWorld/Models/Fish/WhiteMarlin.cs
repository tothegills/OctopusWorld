using System;
using System.Collections.Generic;
using OctopusWorld.Models.FishFood;

namespace OctopusWorld.Models.Fish
{
    [Eats(typeof(Mackerel))]
    public class WhiteMarlin : IMarlin
    {
        public void Feed(IFishFood fishFood)
        {
        }

        public IEnumerable<FavoriteFood> WhatTypeOfFoodDoYouEat()
        {
            yield return new FavoriteFood<Mackerel>();
        }
    }

    public abstract class FavoriteFood
    {
        public abstract Type Type { get; }
    }

    public class FavoriteFood<T> : FavoriteFood where T : IFishFood
    {
        public override Type Type => typeof(T);
    }


    public class EatsAttribute : Attribute
    {
        public EatsAttribute(Type type)
        {
            if (!typeof(IFishFood).IsAssignableFrom(type))
            {
                throw new ArgumentException("Can't eat things are aren't fish food!");
            }
            throw new NotImplementedException();
        }
    }
}