using UnityEngine;

namespace ItemSystem.ScriptableObjects.Containers
{
    [CreateAssetMenu(fileName = "FishItemLibrary", menuName = "Item System/Fish Item Library")]
    public class FishItemLibrary : ScriptableObject
    {
        public FishItem[] fishItems;
        
        public FishItem GetRandomFishItem(float luck)
        { 
            var fish = fishItems[Random.Range(0, fishItems.Length)];
            fish.GetRandomAttributesBasedOnLuck(luck);
            return fish;
        }
    }
}
