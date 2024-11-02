using InventorySystem.ItemTypes.Base;
using InventorySystem.ScriptableObjects;
using UnityEngine;

namespace InventorySystem.ItemTypes.Usables.Base
{
    public abstract class Usable : BaseItem, IUsable
    {
        [SerializeField] private UsableData usableData;
        public UsableData UsableData => usableData;
    }

    public interface IUsable : IBaseItem
    {
        public UsableData UsableData { get; }
    }
}