using UnityEngine;

namespace InventorySystem.ScriptableObjects.Containers
{
    [CreateAssetMenu(fileName = "RodItemLibrary", menuName = "Item System/Rod Item Library")]
    public class RodItemLibrary : ScriptableObject
    {
        public RodData[] rodItems;

        public RodData GetRandomRodItem()
        {
            return rodItems[Random.Range(0, rodItems.Length)];
        }
    }
}