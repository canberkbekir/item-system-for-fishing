using ItemSystem.ScriptableObjects;
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
        RarityType Rarity { get; }
    }

    public interface IFish : IItem
    {
        float Weight { get; }
        float Length { get; } 
        float AveragePrice { get; } 
        float AverageLength { get; } 
        GameObject Prefab { get; }
    }

    public interface IRod: IItem
    {
        float Durability { get; }
        float CastingRange { get; }
        int Strength { get; }
    }

    public interface ILure: IItem
    {
        float AttractionRate { get; }
        float SinkSpeed { get; }
        bool IsFloating { get; }
    }

    public interface IUsable: IItem
    {
        int Quantity { get; }
        float EffectDuration { get; }
    }
}