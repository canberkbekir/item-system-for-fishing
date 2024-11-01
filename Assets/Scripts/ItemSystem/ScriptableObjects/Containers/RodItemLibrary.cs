using UnityEngine;

namespace ItemSystem.ScriptableObjects.Containers
{
    [CreateAssetMenu(fileName = "RodItemLibrary", menuName = "Item System/Rod Item Library")]
    public class RodItemLibrary : ScriptableObject
    {
        public RodItem[] rodItems;
        
        public RodItem GetRandomRodItem()
        { 
            return rodItems[Random.Range(0, rodItems.Length)];
        }
    }
}
