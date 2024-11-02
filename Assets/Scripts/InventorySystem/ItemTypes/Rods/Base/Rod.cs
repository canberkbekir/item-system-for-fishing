using InventorySystem.ItemTypes.Base;
using InventorySystem.ScriptableObjects;
using UnityEngine;

namespace InventorySystem.ItemTypes.Rods.Base
{
    public class Rod : BaseItem, IRod
    {
        [SerializeField] private RodData rodData;

        public RodData RodData => rodData;
    }

    public interface IRod : IBaseItem
    {
        public RodData RodData { get; }
    }
}