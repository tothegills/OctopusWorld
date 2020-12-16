using System;
using System.Linq;
using System.Threading;
using Autofac;
using Autofac.Core;
using OctopusWorld.FishFactories;
using OctopusWorld.Models.FishFood;

namespace OctopusWorld
{
    class Program
    {
        static void Main()
        {

            // Create your builder.
            var builder = new ContainerBuilder();

            builder.RegisterType<PacificFishFactory>().As<ICreateFish>();

            builder.RegisterType<Aquarium>().As<IAquarium>();

            builder.RegisterType<FishFoodManufacturer>().As<IFishFoodManufacturer>();

            builder.Register((containerContext) =>
            {
                var fishFoodManufacturer = containerContext.Resolve<IFishFoodManufacturer>();

                var initialFishFoodInventory = fishFoodManufacturer.CreateFishFood<Snail>(3)
                    .Concat(fishFoodManufacturer.CreateFishFood<Mackerel>(5)).ToList();

                return initialFishFoodInventory;
            }).InstancePerLifetimeScope();

            builder.RegisterType<FishFoodInventory>().As<IFishFoodInventory>();
            builder.RegisterDecorator<ObservableFishFoodInventory, IFishFoodInventory>();



            builder.RegisterType<FishFeeder>().As<IFeedFish>();
            builder.RegisterType<FishFoodInventoryReplenisher>().As<IReplenishFishFood>().As<IHandleFishFoodInventoryEvents>();

            var container = builder.Build();

            var fishFeeder = container.Resolve<IFeedFish>();
            var aquarium = container.Resolve<IAquarium>();
            var fishFoodInventory = container.Resolve<IFishFoodInventory>();

            while (true)
            {
                var fishes = aquarium.GetFishes();
                fishFeeder.FeedFishes(fishes);
                Console.WriteLine(fishFoodInventory);
                Thread.Sleep(1000);
            }
        }
    }

    // builder.WithSnails(5).WithMackerel(5).Build();
    // builder.WithSnails(5).WithFishFoodType(type, num).build();
}