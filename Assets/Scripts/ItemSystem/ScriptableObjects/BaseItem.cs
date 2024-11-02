using UnityEngine;

namespace ItemSystem.ScriptableObjects
{
    public enum RarityType
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
    
    public abstract class BaseItem : ScriptableObject, IItem
    {
        [SerializeField] private string itemName;
        [SerializeField] private Sprite icon;
        [SerializeField] private string description;
        [SerializeField] private ItemType itemType;
        [SerializeField] private RarityType rarity = RarityType.Common;

        public string Name => itemName;
        public Sprite Icon => icon;
        public string Description => description;
        public ItemType Type => itemType; 
        public RarityType Rarity => rarity;
    }
}
