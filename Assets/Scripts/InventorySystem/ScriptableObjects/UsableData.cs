using UnityEngine;

namespace InventorySystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewUsableItem", menuName = "Items/Usable")]
    public class UsableData : BaseItemData
    {
        [SerializeField] private int quantity;
        [SerializeField] private float effectDuration;

        public int Quantity => quantity;
        public float EffectDuration => effectDuration;
    }
}