using UnityEngine;

namespace ItemSystem.ScriptableObjects.Containers
{
    [CreateAssetMenu(fileName = "UsableItemLibrary", menuName = "Item System/Usable Item Library")]
    public class UsableItemLibrary : ScriptableObject
    {
        public UsableItem[] usableItems;
        
        public UsableItem GetRandomUsableItem()
        { 
            return usableItems[Random.Range(0, usableItems.Length)];
        }
    }
}
