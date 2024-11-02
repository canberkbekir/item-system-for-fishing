using UnityEngine;

namespace InventorySystem.ScriptableObjects.Containers
{
    [CreateAssetMenu(fileName = "FishItemLibrary", menuName = "Item System/Fish Item Library")]
    public class FishItemLibrary : ScriptableObject
    {
        public FishData[] fishItems;

        public FishData GetRandomFishItem(float luck)
        {
            var fish = fishItems[Random.Range(0, fishItems.Length)];
            fish.GetRandomAttributesBasedOnLuck(luck);
            return fish;
        }
    }
}