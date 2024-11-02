using InventorySystem.ItemTypes.Base;
using InventorySystem.ScriptableObjects;
using UnityEngine;

namespace InventorySystem.ItemTypes.Lures.Base
{
    public abstract class Lure : BaseItem, ILure
    {
        [SerializeField] private LureData lureData;

        public LureData LureData => lureData;
    }

    public interface ILure : IBaseItem
    {
        LureData LureData { get; }
    }
}