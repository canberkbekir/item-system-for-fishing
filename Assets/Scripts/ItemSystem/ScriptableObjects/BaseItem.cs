using UnityEngine;

namespace ItemSystem.ScriptableObjects
{
    public abstract class BaseItem : ScriptableObject, IItem
    {
        [SerializeField] private string itemName;
        [SerializeField] private Sprite icon;
        [SerializeField] private string description;
        [SerializeField] private ItemType itemType;

        public string Name => itemName;
        public Sprite Icon => icon;
        public string Description => description;
        public ItemType Type => itemType;
    }
}
