using UnityEngine;

namespace ItemSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewRod", menuName = "Items/Rod")]
    public class RodItem : BaseItem, IRod
    {
        [SerializeField] private float durability;
        [SerializeField] private float castingRange;
        [SerializeField] private int strength;

        public float Durability => durability;
        public float CastingRange => castingRange;
        public int Strength => strength;
    }
}
