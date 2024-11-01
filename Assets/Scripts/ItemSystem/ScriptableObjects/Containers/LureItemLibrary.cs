using UnityEngine;

namespace ItemSystem.ScriptableObjects.Containers
{
    [CreateAssetMenu(fileName = "LureItemLibrary", menuName = "Item System/Lure Item Library")]
    public class LureItemLibrary : ScriptableObject
    {
        public LureItem[] lureItems;
        
        public LureItem GetRandomLureItem(float luck)
        { 
            var lure = lureItems[Random.Range(0, lureItems.Length)]; 
            return lure;
        }
    }
}
