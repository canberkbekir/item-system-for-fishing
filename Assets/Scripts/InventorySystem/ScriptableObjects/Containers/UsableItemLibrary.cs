using UnityEngine;

namespace InventorySystem.ScriptableObjects.Containers
{
    [CreateAssetMenu(fileName = "UsableItemLibrary", menuName = "Item System/Usable Item Library")]
    public class UsableItemLibrary : ScriptableObject
    {
        public UsableData[] usableItems;

        public UsableData GetRandomUsableItem()
        {
            return usableItems[Random.Range(0, usableItems.Length)];
        }
    }
}