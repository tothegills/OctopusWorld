using OctopusWorld.Models.Fish;

namespace OctopusWorld.FishFactories
{
    public interface ICreateFish
    {
        IStingRay CreateStingRay();
        IMarlin CreateMarlin();
    }
}