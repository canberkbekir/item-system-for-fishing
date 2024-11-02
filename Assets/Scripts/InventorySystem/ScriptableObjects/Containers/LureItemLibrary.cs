using UnityEngine;

namespace InventorySystem.ScriptableObjects.Containers
{
    [CreateAssetMenu(fileName = "LureItemLibrary", menuName = "Item System/Lure Item Library")]
    public class LureItemLibrary : ScriptableObject
    {
        public LureData[] lureItems;

        public LureData GetRandomLureItem(float luck)
        {
            var lure = lureItems[Random.Range(0, lureItems.Length)];
            return lure;
        }
    }
}