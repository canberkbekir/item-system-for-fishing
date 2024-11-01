using UnityEngine;

namespace ItemSystem
{
    public enum ItemType
    {
        Fish,
        Rod,
        Lure,
        Usable
    }

    public interface IItem
    {
        string Name { get; }
        Sprite Icon { get; }
        string Description { get; }
        ItemType Type { get; }
    }

    public interface IFish
    {
        float Weight { get; }
        float Length { get; } 
        float AveragePrice { get; } 
        float AverageLength { get; }
        int Rarity { get; }
        GameObject Prefab { get; }
    }

    public interface IRod
    {
        float Durability { get; }
        float CastingRange { get; }
        int Strength { get; }
    }

    public interface ILure
    {
        float AttractionRate { get; }
        float SinkSpeed { get; }
        bool IsFloating { get; }
    }

    public interface IUsable
    {
        int Quantity { get; }
        float EffectDuration { get; }
    }
}