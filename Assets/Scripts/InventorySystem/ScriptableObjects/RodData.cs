using UnityEngine;

namespace InventorySystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewRod", menuName = "Items/Rod")]
    public class RodData : BaseItemData
    {
        [SerializeField] private float durability;
        [SerializeField] private float castingRange;
        [SerializeField] private int strength;

        public float Durability => durability;
        public float CastingRange => castingRange;
        public int Strength => strength;
    }
}