using UnityEngine;

namespace ItemSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewUsableItem", menuName = "Items/Usable")]
    public class UsableItem : BaseItem, IUsable
    {
        [SerializeField] private int quantity;
        [SerializeField] private float effectDuration;

        public int Quantity => quantity;
        public float EffectDuration => effectDuration;
    }
}
