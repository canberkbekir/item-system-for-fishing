using InventorySystem.ItemTypes.Base;
using InventorySystem.ScriptableObjects;
using UnityEngine;

namespace InventorySystem.ItemTypes.Miscs.Base
{
    public abstract class Misc : BaseItem, IMisc
    {
        [SerializeField] private MiscData miscData;

        public MiscData MiscData => miscData;
    }

    public interface IMisc : IBaseItem
    {
        public MiscData MiscData { get; }
    }
}