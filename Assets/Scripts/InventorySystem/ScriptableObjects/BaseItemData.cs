using UnityEngine;

namespace InventorySystem.ScriptableObjects
{
    public enum RarityType
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }

    public enum ItemType
    {
        Fish,
        Rod,
        Lure,
        Usable,
        Misc
    }

    public abstract class BaseItemData : ScriptableObject
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